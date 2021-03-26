using System;
using System.Collections.Generic;
using System.Text;

namespace CarStockConsoleApp
{
    class Processor
    {
        public static bool LoginCheck(string systemUserName, string systemPassword)
        {
            // Initialize user credential variables

            var usernameInput = "";
            var passwordInput = "";

            // Application banner
            Console.WriteLine("Please provide credentials to access BrandX system, note. backspacing when entering password is not supported");

            // Read username in one line
            Console.Write("Enter username: ");
            usernameInput = Console.ReadLine();

            // Read password one char at a time, and print * instead of char
            Console.Write("Enter password ");

            // While is used to mask char input, a simple input could have been like username input oneliner
            while (true)
            {
                // Read key, and return void
                var key = Console.ReadKey(true);

                // Register when Enter has been hit to complete password input
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }

                // Add input char to passwordInput string
                passwordInput += key.KeyChar;
                // Indicate a key has been read, by returning a *
                Console.Write("*");
            }

            // Check if credentials are valid
            if (systemUserName == usernameInput && systemPassword == passwordInput)
            {
                return true;
            }
            // Exit application, if credentials are invalid
            else
            {
                return false;
            }
        }

        public static int CalculateTotalStock(CarStock carstock)
        {
            var totalStockCount = carstock.TotalInStockAlpha + carstock.TotalInStockBravo + carstock.TotalInStockCharlie;
            return totalStockCount;
        }
        public static int CalculateTotalValue(CarStock carstock)
        {
            var totalStockValue = carstock.TotalInStockAlpha * carstock.AlphaPrice + carstock.TotalInStockBravo * carstock.BravoPrice + carstock.TotalInStockCharlie * carstock.CharliePrice;
            return totalStockValue;
        }

        public static string GetStockStatus(CarStock carStock)
        {
            var stockStatusText = "";
            var stockCount = carStock.TotalInStockAlpha + carStock.TotalInStockBravo + carStock.TotalInStockCharlie;

            if (stockCount <= 10)
                stockStatusText = "Very Low";
            if (stockCount > 10 && stockCount <= 25)
                stockStatusText = "Low";
            if (stockCount > 25 && stockCount <= 100)
                stockStatusText = "Normal";
            if (stockCount > 100)
                stockStatusText = "Over";

            return stockStatusText;
        }
        public static CarStock OneCarSold(CarStock carstock)
        {
            Console.Clear();
            Console.WriteLine("1. Sell an Alpha car ");
            Console.WriteLine("2. Sell a Bravo car");
            Console.WriteLine("3. Sell a Charlie car");
            Console.WriteLine("Press any other key to not register a sold car");

            // Read input key
            var inputChoice = Console.ReadKey(true);

            // switch statement to catch menu option selected
            switch (inputChoice.KeyChar.ToString())
            {
                case "1":
                    // Subtract car from stock
                    carstock.TotalInStockAlpha--;
                    Console.WriteLine("Sold one Alpha Car");
                    break;
                case "2":
                    // Subtract car from stock
                    carstock.TotalInStockBravo--;
                    Console.WriteLine("Sold one Bravo Car");
                    break;
                case "3":
                    // Subtract car from stock
                    carstock.TotalInStockCharlie--;
                    Console.WriteLine("Sold one Charlie Car");
                    break;
                default:
                    break;
            }
            return carstock;
        }
    }
}
