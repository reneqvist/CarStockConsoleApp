using System;

namespace CarStockConsoleApp
{
    class Program
    {
        // Initial stock count
        private const int StartStockCountAlpha = 10;
        private const int StartStockCountBravo = 15;
        private const int StartStockCountCharlie = 40;

        // System username and password
        private const string systemUserName = "admin";
        private const string systemPassword = "password";

        static void Main(string[] args)
        {
            // Check username and password
            var loginCheck = Processor.LoginCheck(systemUserName, systemPassword);

            if (loginCheck)
            {
                Console.WriteLine("Username and password accepted.");
            }
            else
            {
                Console.WriteLine("You are not authorized to access this service");
                Environment.Exit(1);
            }

            // Initialize carstock from start stock values
            var carstock = new CarStock(StartStockCountAlpha, StartStockCountBravo, StartStockCountCharlie);

            // Usermenu
            var menuActive = true;
            while (menuActive)
            {
                // clear console screen
                Console.Clear();
                // Menu information
                Console.WriteLine("****** Here are your options ******");
                Console.WriteLine("Please select the action.");
                Console.WriteLine("1. Show stock count ");
                Console.WriteLine("2. Show total value of all cars in stock");
                Console.WriteLine("3. Register one car sold");
                Console.WriteLine("4. Get stock status");
                Console.WriteLine("Press any other key to end application");

                // Read input key
                var inputChoice = Console.ReadKey();

                // switch statement to catch menu option selected
                switch (inputChoice.KeyChar.ToString())
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Total Alpha stock: " + carstock.TotalInStockAlpha);
                        Console.WriteLine("Total Bravo stock: " + carstock.TotalInStockBravo);
                        Console.WriteLine("Total Charlie stock: " + carstock.TotalInStockCharlie);
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Total value in stock: " + Processor.CalculateTotalValue(carstock));
                        break;
                    case "3":
                        carstock = Processor.OneCarSold(carstock);
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Stock status: " + Processor.CalculateTotalStock(carstock) + " / " + Processor.GetStockStatus(carstock));
                        break;

                    default:
                        menuActive = false;
                        break;
                }
                if (menuActive)
                {
                    Console.WriteLine("Press any key...");
                    Console.ReadKey();
                }
            }
            // Exit message
            Console.WriteLine("Application ended...");
        }
    }
}
