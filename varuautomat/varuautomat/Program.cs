using System.Runtime.CompilerServices;

namespace vendingmachine
{
    public class Program
    {
        static void Main(string[] args)
        {
            RunMachine();
        }

        static Menu[] InitMenuList()
        {
            return new Menu[]
            {
                new MainMenu("Main Menu"),
                new ProductMenu("Product Menu"),
                new MoneyMenu("Money Menu")
            };
        }

        static Product[] InitProductList()
        {
            return new Product[]
            {
                //Creates objects of the class Food.cs
                //Includes attribute values via parameters
                //Food Products here
                new Food("Tuna Sandwich", "Triangle sandwich with tuna in it.", 11, 1),
                new Food("Ham and Cheese Sandwich", "Triangle sandwich with ham and cheese in it.", 10, 2),
                new Food("Chocolate bar", "Milk chocolate bar. 18% Cocoa.", 5, 3),

                //Drink Products here
                new Drink("Bebsi", "Carbonated cola drink. 33cl.", 6, 4),
                new Drink("Zpraite", "Carbonated lemon drink. 33cl.", 6, 5),
                new Drink("Sipton", "Non carbonated peach tea. 50cl.", 15, 6)
            };
        }

        static int MenuChoice(string message)
        {
            Console.Write(message);
            var choice = int.Parse(Console.ReadLine() ?? string.Empty);
            return choice - 1;
        }

        static void MainMenu(Product[] products)
        {
            Console.WriteLine("|=============================================|");
            Console.WriteLine("|===============Vending Machine===============|");
            Console.WriteLine("|=============================================|");
            Console.WriteLine("|ID\tProduct\t\t\t\t      |");
            Console.WriteLine("|=============================================|");

            for (int i = 0; i < products.Length; i++)
                Console.WriteLine($"|{products[i].Id}\t" +
                    $"{products[i].Name}\t\t\t\t"
                    );

            Console.WriteLine("|=============================================|");
            Console.WriteLine("");
        }

        static int ReadMenuChoice(string message)
        {
            Console.Write(message);

            //returns the first argument. If its null, return second argument
            var rmchoice = int.Parse(Console.ReadLine() ?? string.Empty);
            return rmchoice;
        }


        static void RunMachine()
        {
            //Inititate product list & menu list
            Product[] products = InitProductList();
            Menu[] menus = InitMenuList();
            Wallet wallet = new Wallet(0);

            //declare variables for the child/inherited menus 'Display' method
            var mmDisplay = menus[0].Display;
            var pmDisplay = menus[1].Display;
            var monDisplay = menus[2].Display;

            //declare menu boolean
            bool runMainMenu = true;

            //start the loop
            while (runMainMenu == true)
            {
                Console.Clear();

                //display all products
                MainMenu(products);

                //calls MainMenu class & its override 'Display' method
                //waits for user to choose a menu
                //Main menu is "disabled/false" for now
                mmDisplay();
                var menuChoice = ReadMenuChoice("Please enter menu number\n:");
                runMainMenu = false;

                //Product selection menu
                while(menuChoice == 1)
                {
                    Console.Clear();

                    MainMenu(products);

                    //user selects product via inputting product ID
                    Console.WriteLine("");
                    Console.WriteLine("Welcome to the Product selection menu");
                    Console.WriteLine("");
                    var productID = MenuChoice("Please enter product ID for product description\n:");

                    var chosenProductID = products[productID];

                    Console.Clear();

                    chosenProductID.Description();

                    wallet.PrintWallet();
                    //user decides whether to buy product or return to main menu
                    pmDisplay();
                    var pmInput = ReadMenuChoice("Select an option\n:");

                    //user decides to buy and use product
                    if (pmInput == 1)
                    {
                        if (chosenProductID.Price > wallet.balance)
                        {
                            Console.WriteLine("Not enough money.");
                            Console.WriteLine("Press any key to return to main menu.");
                            Console.ReadKey(true);
                            runMainMenu = true;
                            break;
                        }
                        else
                        {
                            chosenProductID.Buy();
                            chosenProductID.Use();
                            wallet.Withdraw(chosenProductID.Price);
                            wallet.PrintWallet();
                            Console.WriteLine("");
                            Console.WriteLine("Press any key to return to main menu.");
                            Console.ReadKey(true);
                            runMainMenu = true;
                            break;
                        }
                    }

                    //user decides to return to main menu
                    if (pmInput == 2)
                    {
                        runMainMenu = true;
                        break;
                    }
                }

                //Money menu
                while(menuChoice == 2)
                {
                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine("Welcome to the Money menu");
                    Console.WriteLine("");
                    wallet.PrintWallet();

                    monDisplay();

                    var menuChoiceTwo = ReadMenuChoice("Select an option\n:");

                    if (menuChoiceTwo == 1)
                    {
                        var monDeposit = ReadMenuChoice("Please enter the amount of money you want to deposit.\n:");
                        wallet.Deposit(monDeposit);

                        if(monDeposit < 0)
                        {
                            Console.WriteLine("Press any key to continue");
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine(monDeposit + " KR has been deposited into your wallet.");
                            Console.WriteLine("");
                            Console.WriteLine("Press any key to continue");
                        }

                    }
                    else
                    {
                        runMainMenu = true;
                        break;
                    }

                    Console.ReadKey(true);
                }

                //Exit menu
                while(menuChoice == 3)
                {
                    Environment.Exit(0);
                }

            }


        }



    }
}
