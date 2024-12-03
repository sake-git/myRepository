using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Roshambo_Project
{
    //HumanPlayer inherits from player 
    internal class HumanPlayer : Player
    {
        public HumanPlayer(string name): base(name) //Parameterized constructor
        {
        }
        public override Roshambo GenerateRoshambo() //Method overriden to return a value entered by user
        {
            bool isValid = false;
            string userChoice = "";
            do
            {
                //Get the Roshambo value from user. 
                Console.WriteLine("\nRock, paper, or scissors? (R/P/S): "); 
                userChoice = Console.ReadLine();

                //Validate using Validator class Validate Roshambo function
                isValid = Validator.ValidateRoshambo(userChoice);

                if (!isValid) //If invalid, display error message and loop until user enters correct value.
                {
                    Console.WriteLine("Invalid input. Try again!");
                }

            } while (!isValid); 

            switch (userChoice.ToUpper())//Convert user input to Roshambo value
            {
                case "R":
                case "ROCK": 
                    return Roshambo.rock;    
                    
                case "P": 
                case "PAPER":
                    return Roshambo.paper;

                case "S":
                case "SCISSORS":
                    return Roshambo.scissors;

                default: //This should not happen as we already validated the value. But if it did, throw an exception!
                    throw new InvalidDataException("Invalid input");
                    break;
            }
        }
    }
}
