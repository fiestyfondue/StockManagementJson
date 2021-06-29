using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StockManagement
{
    interface IStockAccount
    {
        double ValueOf();
        void Buy(int amount, String symbol);
        void Sell(int amount, String symbol);
        void Save(String filename);
        void PrintReport();
    }
    public class StockAccount
    {
        string filepath = @"C:\Users\HP\Desktop\desktop\C#\StockManagement\StockManagementJson\StockAccountData.json";
        
        public void Buy(int amount ,string symbol)
        {
            var jsonOutput = File.ReadAllText(filepath);
            var jObject = JObject.Parse(jsonOutput);
            var stockArray = (JArray)jObject["stock account"];

            if(jObject!= null)
            {
                Console.WriteLine("Stock Report");
                Console.WriteLine();
                Console.WriteLine("Stock Name    Symbol  Number of Shares    Share Price $");
                foreach(var item in stockArray)
                {
                    bool stockFound = SearchStock(item["symbol"], symbol);
                    if(stockFound==true)
                    {
                        Console.WriteLine($"{item["stockname"]}\t{item["symbol"]} \t{item["numberofstocks"]}\t\t\t${item["stockprice"]}");
                        Console.WriteLine($"Press 'Y' to confirm stock(s) buy of Amount ${amount}");
                        Console.WriteLine("Press 'N' to cancel");
                        char inp = Convert.ToChar(Console.ReadLine());
                        char input = Char.ToUpper(inp);
                        if(input=='Y')
                        {
                            //Allot stock and deduct stocks in numberof shares
                            float sharesAlloted = AllotStock(amount, item["stockprice"]);
                            Console.WriteLine("Transaction successfull");
                            Console.WriteLine($"You're alloted ,{sharesAlloted} shares of {item["stockname"]}");
                        }
                        if(input=='N')
                        {
                            break;
                        }
                    }
                }
            }
        }
        internal float AllotStock(int amount,JToken stockPrice)  //Jtoken is an abstract class
        {
            float stocks = 0;
            int convstockPrice = stockPrice.ToObject<int>();

            try
            {
                if(convstockPrice!=0)
                {
                    stocks = amount / convstockPrice;
                    return stocks;
                }
                else
                {
                    Console.WriteLine("Stock price is 0.Cannot perform transaction");
                    return stocks;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return stocks;
        }
        internal bool SearchStock(JToken stockSymbol, string symbol)
        {
            string convSymbol = stockSymbol.ToObject<string>();
            if (convSymbol.Equals(symbol))
                return true;
            else
                return false;
        }

    }
   
}
