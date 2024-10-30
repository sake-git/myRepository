using System;
using System.Threading.Channels;

namespace Room_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the length of room in meters: ");
            double length = getInput(); // Get Length

            Console.WriteLine("Enter the width of room in meters: ");
            double width = getInput(); //Get Width

            Console.WriteLine("Enter the height of room in meters: ");
            double height = getInput(); // Get Height

            double area = length * width; //Area calculation 
            double perimeter = 2 * length + 2 * width; //Perimeter calculation
            double volume = length * width * height; // Volume  calculation
            double surfaceArea = 2 * length * width + 2 * length * height + 2 * width * height; //Surface Area

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nRoom Specification as Below:");
            Console.WriteLine($"\tArea  = {area} sq m");
            Console.WriteLine($"\tPerimeter = { perimeter} m");
            Console.WriteLine($"\tVolume = {volume} cubic m");
            Console.WriteLine($"\tSurface Area = { surfaceArea} sq m");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\tIt's a { GetRoomClassification(area) } room"); //Get the room Classification
            Console.ForegroundColor = ConsoleColor.Gray;
        }


        //Function to get the user input & to convert input string into double.
        static double getInput()
        {
            bool isValid = false;
            double userInput = 0.0;
            do
            {
                isValid = double.TryParse(Console.ReadLine(), out userInput);
                if (!isValid)
                {
                    Console.WriteLine("Invalid number. Please try again");
                }
            } while (!isValid);

            return userInput;
        }


        //This function classifies the room as small, medium & large based on total area.
        static string GetRoomClassification(double area)
        {
            if(area <= 250)
            {
                return "Small";
            }
            else if( area > 250 && area < 650)
            {
                return "Medium";
            }
            else
            {
                return "Large";
            }
        }
    }
}
