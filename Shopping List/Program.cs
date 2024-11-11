
namespace Shopping_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> catalogue = new Dictionary<string, double>() // Main Dictionary
            {
                { "apple", 0.99 },
                { "banana", 0.59 },
                { "cauliflower", 1.59 },
                { "dragonfruit", 2.19 },
                { "Elderberry", 1.79 },
                { "figs", 2.09 },
                { "grapefruit", 1.99 },
                { "honeydew", 3.49 }
            };
            Dictionary<string,string> catalogueIndex = new Dictionary<string,string>() //Dictionary to Index items by number
            {
                { "1","apple" },
                { "2","banana" },
                { "3","cauliflower" },
                { "4","dragonfruit" },
                { "5","Elderberry" },
                { "6","figs" },
                { "7","grapefruit" },
                { "8","honeydew" }
            };
            
            Dictionary<string,double> shoppingList = new Dictionary<string,double>(); //Save item in shopping cart
            Console.WriteLine("Item Catalogue");
            do
            {
                
                int count = 0;
                Console.ForegroundColor = ConsoleColor.Red;
                //Display the items and price
                Console.WriteLine("************************************");
                Console.WriteLine("\tItem\t\tPrice");
                Console.WriteLine("************************************");
                foreach (KeyValuePair<string, double> kvp in catalogue)
                {
                    Console.WriteLine($"{++count}. {kvp.Key} \t\t{kvp.Value:C}");
                }
                Console.WriteLine("************************************\n");
                Console.ForegroundColor = ConsoleColor.Gray;

                //Get the user choice
                Console.WriteLine("What item would you like to order?");
                string? item = Console.ReadLine().Trim();
                
                if (catalogue.ContainsKey(item)) // Item name has entered
                {
                    shoppingList.Add(item, catalogue[item]);
                    Console.WriteLine($"Adding {item} to cart at ${catalogue[item]}");

                }else if (catalogueIndex.ContainsKey(item)) // Item index has entered
                {
                    item = catalogueIndex.GetValueOrDefault(item); //Get the item based on Index
                    shoppingList.Add(item, catalogue[item]);
                    Console.WriteLine($"Adding {item} to cart at ${catalogue[item]}");
                }
                else
                {
                    Console.WriteLine("Sorry, we don't have those.  Please try again. ");
                }
                Console.WriteLine("\nWould you like to order anything else (y/n)?"); // Loop until user wants to add items
            }while(Console.ReadLine().ToLower() == "y");

            Console.WriteLine("\nThanks for your order!\n");
            Console.WriteLine("Here's what you got:");
            Console.ForegroundColor = ConsoleColor.Green;
            double sum = 0.0;
            //Display the items in Shopping list
            Console.WriteLine("*****************************");
            Console.WriteLine("Item\t\tPrice");
            Console.WriteLine("*****************************");
            //Sort the Shopping Cart based on Item Price & then display
            Dictionary<string, double> SL = shoppingList.OrderBy(x => x.Value).ToDictionary<string,double>();
            foreach (var item in SL)
            {
                Console.WriteLine($"{item.Key,-10}\t${item.Value,-5}");  
            }
            Console.WriteLine("*****************************");
            Console.WriteLine($"Total: \t\t {shoppingList.Sum(x=> x.Value):C}"); //Display the total amount
            double average = (sum / shoppingList.Count);
            Console.WriteLine($"\nAverage price per item in order was {shoppingList.Average(x => x.Value)}"); //Display Average amount
            Console.WriteLine($"Most Expensive item in your order is {shoppingList.MaxBy(x => x.Value).Key}"); // Most expensive item
            Console.WriteLine($"Least Expensive item in your order is {shoppingList.MinBy(x => x.Value).Key}"); // Least expensive item
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
