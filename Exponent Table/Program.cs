namespace Exponent_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Learn your squares and cubes!");
            string userChoice = "";
            do //Loop to check if user wants to continue
            {
                int inputNumber = 0;
                bool isValidNumber = false;
                do  // Program will loop until user inputs a valid number
                {
                    Console.WriteLine("Please enter a number: ");                    
                    isValidNumber = int.TryParse(Console.ReadLine(), out inputNumber); //exponents will be displayed till the number entered.

                    //Any non-numeric value or value less than or equal to 0 will be considered as invalid input
                    // Also highest value integer can hold is 2147483647, hence any input greater than this will be considered as invalid
                    if (!isValidNumber || inputNumber <= 0 || inputNumber > 2147483647) 
                    { 
                        Console.WriteLine("Invalid number!\n");
                        isValidNumber = false;
                    }

                } while (!isValidNumber);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nNumber\t\tSquared\t\tCubed");

                
                for(int counter = 1; counter  <= inputNumber; counter++) //Loop until all the exponents are displayed.
                {
                    //display the square and cube of a number using Math.Pow() function.
                    //Formatter is used to align numbers to right
                    Console.WriteLine($"{counter,6}\t\t{Math.Pow(counter,2),6}\t\t{Math.Pow(counter, 3),6}");  
                }
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.WriteLine("\nContinue? (y/n)");

            } while (Console.ReadLine().ToLower() == "y");
        }
    }
}
