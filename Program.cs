using System;

namespace StockManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello From stock Management!");
            Stock stock = new Stock();
            stock.GetStockDetails();
        }
    }
}
