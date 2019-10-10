using System;
using System.Collections.Generic;
using System.Linq;

namespace linqPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            // Find the words in the collection that start with the letter 'L'
            List<string> fruits = new List<string>() { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };

            List<string> LFruits = fruits.Where(fruit => fruit.StartsWith("L")).ToList();

            foreach (string fruit in LFruits)
            {
                Console.WriteLine(fruit);
            }

            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");

            // Which of the following numbers are multiples of 4 or 6
            List<int> numbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            List<int> fourSixMultiples = numbers.Where(number => number % 4 == 0 || number % 6 == 0).ToList();

            foreach (int number in fourSixMultiples)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");

            // Order these student names alphabetically, in descending order (Z to A)
            List<string> names = new List<string>()
{
    "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
    "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
    "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
    "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
    "Francisco", "Tre"
};

            List<string> descend = names.OrderByDescending(name => name).ToList();

            foreach (string name in descend)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");

            // Build a collection of these numbers sorted in ascending order
            List<int> ascendingNums = numbers.OrderBy(num => num).ToList();

            foreach (int num in ascendingNums)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");

            // Output how many numbers are in this list
            int numListLength = numbers.Count();

            Console.WriteLine(numListLength);
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");

            List<double> purchases = new List<double>()
{
    2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
};
            double totalMoney = purchases.Sum();
            Console.WriteLine(totalMoney);
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");

            // What is our most expensive product?
            List<double> prices = new List<double>()
{
    879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
};

            double mostExpensive = prices.Max();
            Console.WriteLine(mostExpensive);
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");

            /*
    Store each number in the following List until a perfect square
    is detected.

    Ref: https://msdn.microsoft.com/en-us/library/system.math.sqrt(v=vs.110).aspx
*/
            List<int> wheresSquaredo = new List<int>()
{
    66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14
};
            List<int> square = wheresSquaredo.TakeWhile(num => Math.Sqrt(num) % 1 != 0).ToList();
            foreach (int num in square)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");

            List<Customer> customers = new List<Customer>() {
            new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
            new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
            new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
            new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
            new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
            new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
            new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
            new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
            new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
            new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
            };

            List<Customer> millionaires = customers.Where(customer => customer.Balance >= 1000000).ToList();
            // List<string> banks = new List<string>();
            // foreach (Customer customer in millionaires)
            // {
            //     string currentBank = banks.Find(bank => customer.Bank == bank);
            //     if (currentBank == null)
            //     {
            //         List<Customer> currentCustomerList = millionaires.Where(millionaire => millionaire.Bank == customer.Bank).ToList();
            //         List<string> currentBanks = currentCustomerList.Select(customer => customer.Bank).ToList();
            //         int bankCount = currentBanks.Count();
            //         banks.Add(customer.Bank);
            //         Console.WriteLine($"{customer.Bank} {bankCount}");
            //     }
            //     else
            //     {
            //         Console.Write("");
            //     }
            // }

            var millionairesByBank = millionaires.GroupBy(customer => customer.Bank, (key, value) => new
            {
                bankName = key,
                count = value.Count()
            });

            foreach (var kvp in millionairesByBank)
            {
                Console.WriteLine($"{kvp.bankName} {kvp.count}");
            }
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
            List<Bank> banks = new List<Bank>() {
            new Bank(){ Name="First Tennessee", Symbol="FTB"},
            new Bank(){ Name="Wells Fargo", Symbol="WF"},
            new Bank(){ Name="Bank of America", Symbol="BOA"},
            new Bank(){ Name="Citibank", Symbol="CITI"},
        };
            List<ReportItem> millionaireReport = millionaires.Where(customer => customer.Balance >= 1000000).Select(customer => new ReportItem
            {
                CustomerName = customer.Name,
                BankName = banks.Find(bank => bank.Symbol == customer.Bank).Name
            }).OrderBy(customer => customer.CustomerName.Split(" ")[1]).ToList();

            foreach (var item in millionaireReport)
            {
                Console.WriteLine($"{item.CustomerName} at {item.BankName}");
            }
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
        }
    }
}
