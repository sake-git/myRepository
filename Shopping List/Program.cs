namespace Shopping_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,double> catalogue = new Dictionary<string, double>()
            {
                {"KitKat", 1.0 },
                {"Water", 2.0 },
                {"Coke",1.5 },
                {"Lays",2.0 },
                {"Pepsi",1.0 },
                {"Mint", 0.5 }
            };

            List<string> shoppingList = new List<string>();
            Console.WriteLine("Item Catalogue");
            do
            {
                
                int count = 0;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nItem\t\tPrice");
                Console.WriteLine("************************************");
                foreach (KeyValuePair<string, double> kvp in catalogue)
                {
                    Console.WriteLine($"{++count}. {kvp.Key}  ${kvp.Value}");
                }
                Console.WriteLine("************************************\n");
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.WriteLine("What item would you like to order?");
                string item = Console.ReadLine();
                bool isValid = catalogue.ContainsKey(item.Trim());
                if (isValid)
                {
                    shoppingList.Add(item.Trim());
                    Console.WriteLine($"Adding {item} to cart at ${catalogue[item]}");

                }
                else
                {
                    Console.WriteLine("Sorry, we don't have those.  Please try again. ");
                }
                Console.WriteLine("\nWould you like to order anything else (y/n)?");
            }while(Console.ReadLine().ToLower() == "y");

            Console.WriteLine("\nThanks for your order!");
            Console.WriteLine("Here's what you got:");
            Console.ForegroundColor = ConsoleColor.Green;
            double sum = 0.0;
            foreach (string item in shoppingList)
            {
                Console.WriteLine($"{item} \t\t ${catalogue[item]}");
                sum = sum + catalogue[item];
            }

            double average = sum / shoppingList.Count;
            Console.WriteLine($"\nAverage price per item in order was ${average}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
