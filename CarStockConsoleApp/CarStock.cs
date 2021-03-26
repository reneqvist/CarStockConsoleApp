using System;
using System.Collections.Generic;
using System.Text;

namespace CarStockConsoleApp
{
    class CarStock
    {
        public int TotalInStockAlpha { get; set; }
        public int TotalInStockBravo { get; set; }
        public int TotalInStockCharlie { get; set; }

        public int AlphaPrice { get; set; }
        public int BravoPrice { get; set; }
        public int CharliePrice { get; set; }

        public CarStock(int totalInStockAlpha, int totalInStockBravo, int totalInStockCharlie)
        {
            TotalInStockAlpha = totalInStockAlpha;
            TotalInStockBravo = totalInStockBravo;
            TotalInStockCharlie = totalInStockCharlie;
            AlphaPrice = 60000;
            BravoPrice = 75000;
            CharliePrice = 95000;
        }
        
    }
}
