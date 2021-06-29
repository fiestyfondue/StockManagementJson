using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StockManagement
{
    class Stock
    {
        // Each Stock has properties like name, number of shares and share price.
        // this stocks are stored in StockAccountData.json file.
        // GetStockDetails() method is used to access the stock details inside the json file.
        public void GetStockDetails()
        {
            //Variables
            int ValueOfStock, totalValueOfStock = 0;
            //json FilePath
            string filepath = @"C:\Users\HP\Desktop\desktop\C#\StockManagement\StockManagementJson\StockAccountData.json";
            var jsonOutput = File.ReadAllText(filepath);
            var jObject = JObject.Parse(jsonOutput);
            var stockArray = (JArray)jObject["stock account"];
            try
            {
                if(jObject !=null)
                {
                    Console.WriteLine();
                    foreach(var item in stockArray)
                    {
                        ValueOfStock = GetValueOfStock(item["numberofstocks"], item["stockprice"]);
                        totalValueOfStock += ValueOfStock;
                        Console.WriteLine();
                        Console.WriteLine($"{item["stockname"]}\n{item["numberofstock"]}\n{item["stockPrice"]}\n{ValueOfStock}");
                        
                    }
                    Console.WriteLine();
                    Console.WriteLine($"Total Value of Stocks:{totalValueOfStock}");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        // Calculation of value of each stock from json file
        /// </summary>
        /// <param name="numOfShares"></param>
        /// <param name="stockPrice"></param>
        
        internal int GetValueOfStock(JToken numOfShares,JToken stockPrice)
        {
            int convNumOfShares = numOfShares.ToObject<int>();
            int convStockPrice = stockPrice.ToObject<int>();
            int valueOfStock = 0;
            try
            {
                valueOfStock = convNumOfShares * convStockPrice;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return valueOfStock;
        }

    }
}
