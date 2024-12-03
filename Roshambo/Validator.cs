using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Roshambo_Project
{
    internal class Validator
    {
        //Function to validate Roshambo value entered by user. Returns true if valid else false
        public static bool ValidateRoshambo(string userChoice) 
        {
            userChoice = userChoice.ToUpper();
            if (userChoice == "R" || userChoice == "ROCK" || userChoice == "P" || userChoice == "PAPER" || userChoice == "S" ||
                userChoice == "SCISSORS")
            {
                return true;
            }      
            
            return false;
        }

        //This function get "y" or "n" input from user and returns it. If anything apart from "y/Y,n/N" is entered, it throws an exception
        public static string GetYN(string message)
        {
            Console.WriteLine("\n"+ message);
            string userChoice = Console.ReadLine().ToLower();            
            if (userChoice == "y" || userChoice == "n")
            {
                return userChoice;
            }
            else
            {
                throw new InvalidDataException("Invalid input. Try again!");
            }
        }

        //This function gets Opponent to play against. 
        public static string GetOpponent()
        {
            Console.WriteLine("\nWould you like to play against The Jets or The Sharks  (j/s)?");
            string opponent = Console.ReadLine().ToLower();

            if (opponent == "j" || opponent == "s") 
            {
                return opponent; //Valid opponent
            }            
            else
            {
                throw new InvalidDataException("Invalid input. Try again!"); //Invalid value, throw an exception
            }
        }


    }
}
