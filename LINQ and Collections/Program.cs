namespace LINQ_and_Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 10, 2330, 112233, 12, 949, 3764, 2942, 523863 };            
            
            Console.WriteLine("Array Content:  \t");
            foreach( int num in nums)
            {
                Console.Write(num + " ");
            }
            do
            {
                Console.WriteLine("\n\n*************************************************");
                Console.WriteLine("\t\tMenu");
                Console.WriteLine("*************************************************");
                Console.WriteLine("1. Find the Minimum value");
                Console.WriteLine("2. Find the Maximum value");
                Console.WriteLine("3. Find the Maximum value less than 10000");
                Console.WriteLine("4. Find all the values between 10 and 100");
                Console.WriteLine("5. Find all the Values between 100000 and 999999 inclusive");
                Console.WriteLine("6. Count all the even numbers");
                Console.WriteLine("*************************************************\n");
                Console.WriteLine("Enter your choice");
                string choice = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Green;
                switch (choice)
                {
                    case "1":
                        int min = nums.Min();
                        Console.WriteLine("Minimum value is {0}", min);
                        break;
                    case "2":
                        int? max = nums.Max();
                        Console.WriteLine("Maximum value is {0}", max);
                        break;
                    case "3":
                        max = nums.Max(x => x < 10000? x: null);
                        Console.WriteLine("Maximum value less than 10000 is {0}", max);
                        break;
                    case "4":
                        IEnumerable<int> filteredNums = nums.Where(x => x > 10 && x < 100);
                        foreach(int num in filteredNums)
                        {
                            Console.Write(num + " ");
                        }
                        break;
                    case "5":
                        filteredNums = nums.Where(x => x >= 100000 && x <= 999999);
                        foreach (int num in filteredNums)
                        {
                            Console.Write(num + " ");
                        }
                        break;
                    case "6":
                        filteredNums = nums.Where(x => x % 2 == 0);
                        foreach (int num in filteredNums)
                        {
                            Console.Write(num + " ");
                        }
                        break;
                    case "0":
                        Console.WriteLine("Goodbye!");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please select a correct option:");
                        break;
                }
                Console.ForegroundColor = ConsoleColor.Gray;
            } while (true);
        }
    }
}
