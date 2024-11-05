namespace String_Processing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n***************************************");
            Console.WriteLine("Split statement into words");
            Console.WriteLine("***************************************\n");
            do
            {
                Console.WriteLine("Enter a sentence:");
                string sentence = Console.ReadLine().Trim();
                string[] words = sentence.Split([' ', '\t']);
                foreach (string word in words)
                {
                    Console.WriteLine(word);
                }

                Console.WriteLine("Would you like to continue (y/n)?");
            } while (Console.ReadLine().ToLower() == "y");


            Console.WriteLine("\n***************************************");
            Console.WriteLine("Save the input words");
            Console.WriteLine("***************************************\n");

            List<string> wordList = new List<string>();
            do
            {
                Console.WriteLine("\nEnter some text:");
                string input = Console.ReadLine().Trim();

                wordList.Add(input);
                Console.WriteLine("You have entered ");
                foreach (string word in wordList)
                {
                    Console.Write(word + " ");
                }
                Console.WriteLine("\n Would you like to continue (y/n)?");
            } while (Console.ReadLine().ToLower() == "y") ;
        }
    }
}
