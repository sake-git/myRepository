using System.Text.RegularExpressions;

namespace Data_Structure_Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a word you would like to reverse: ");
            string sentence = Console.ReadLine(); //Read user input

            if (Regex.IsMatch(sentence, @"[^a-zA-Z\s]")) // Check if input contains special char other than space
            { 
                Console.WriteLine("Sentence contains special character or number. Can't reverse!");
                Console.ReadKey();
                Environment.Exit(0);
            }
            Console.WriteLine("Reverse string:");
            Console.WriteLine( Reverse(sentence)); //Call string reverse function
        }
        
        //function to reverse string
        public static string Reverse(string sentence)
        {
            string[] words = sentence.Split(" "); //split input to get words
            List<string> result = new List<string>(); // Create a list to store reversed words.
            foreach (string word in words) //Reverse one word at a time
            { 
                Stack<char> stack = new Stack<char>(); // instantiate stack (LIFO)

                foreach (char character in word) //Push each character in word into the stack
                {
                    stack.Push(character);
                }

                List<char> chars = new List<char>(); // List of char to store characters
                while (stack.Count > 0)
                {
                    // Now Pop characters from Stack and store them in list.
                    // Since Stack is 'Last In First Out(LIFO)', The word order will be reversed
                    chars.Add(stack.Pop()); 
                }

                //Join all the characters to form the string(word) and add it to string list
                result.Add(string.Join("", chars.ToArray()));
            }

            //All the words in the given sentence are reversed. Join the strings(words) in list to form sentence. 
            sentence = string.Join(" ", result.ToArray());

            return sentence;
        }
    }
}
