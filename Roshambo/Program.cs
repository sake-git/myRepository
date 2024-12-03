using System.Numerics;
using System.Security.Cryptography;

namespace Roshambo_Project
{

    //Enum Roshambo
    public enum Roshambo
    {
        rock, paper, scissors
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("\n*****************************************************");
            Console.WriteLine("\tWelcome to Rock Paper Scissors!");
            Console.WriteLine("*****************************************************\n");
            Console.WriteLine("Enter your name:"); // Get user name
            string name = Console.ReadLine();

            Player player = null;
            bool isValidPlayer = false;

            //This loop gets the valid opponent
            do {
                try
                {
                    string opponent = Validator.GetOpponent();

                    if (opponent == "j") //User entered The Jests. It's a RockPlayer
                    {
                        player = new RockPlayer("The Jets"); 
                    }
                    else //User entered The Sharks. It's a RandomPlayer
                    {
                        player = new RandomPlayer("The Sharks"); 
                    }
                    isValidPlayer = true;
                }
                catch (Exception ex) {
                    //User entered invalid value. Display message and loop again until user enters valid value
                    Console.WriteLine("Exception occured: " + ex.Message);
                    isValidPlayer = false;
                }
            } while (!isValidPlayer);

            //Create a human player
            HumanPlayer human = new HumanPlayer(name);
            do
            {
                human.roshambo = human.GenerateRoshambo(); // Get Roshambo value for human
                player.roshambo = player.GenerateRoshambo();   // Generate Roshambo value for other player
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n***********************Results***********************"); //Display roshambo value
                Console.WriteLine($"{player.Name}: {player.roshambo}");
                Console.WriteLine($"{human.Name}: {human.roshambo}");
                Console.WriteLine("*****************************************************");
                GetResults(player, human); //Display results
                Console.WriteLine("*****************************************************\n");
                Console.ForegroundColor = ConsoleColor.Gray;

                bool isValidInput = false;
                do
                {
                    string message = "Play again? (y/n)"; //Check if user wants to play again
                    string continueGame = "";
                    try
                    {
                        continueGame = Validator.GetYN(message);
                        isValidInput = true;
                        if (continueGame == "y")
                        {
                           //continue playing
                        }
                        else
                        { //User had enough fun for the day. Display final score and exit
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nFinal Score:");
                            Console.WriteLine($"{human.Name} = {human.Score} wins");
                            Console.WriteLine($"{player.Name} = {player.Score} wins");
                            Console.ForegroundColor = ConsoleColor.Gray;

                            Console.WriteLine("\nGoodBye!");
                            Console.ReadKey();
                            return;
                        }
                    }
                    catch (Exception ex) {
                        //Invalid input, display error message
                        Console.WriteLine("Exception occured: "+ ex.Message);
                    }
                } while (!isValidInput);              

            } while (true);
        }


        //Function to display result of Roshambo
        public static void GetResults(Player player, HumanPlayer human)
        {
            if (player.roshambo == human.roshambo) 
            {
                // If player roshambo value is same as human, it's a draw. Give 1 point each.
                Console.WriteLine("Draw");
                player.Score++;
                human.Score++;
            }
            else if (player.roshambo == Roshambo.rock)
            {
                //Player thew rock. If we are here human can only throw scissor or paper
                if (human.roshambo == Roshambo.scissors)
                {
                    //human threw Scissor, Rock crushed Scissor. Player wins!
                    Console.WriteLine($"{player.Name} wins");
                    player.Score++;
                }
                else 
                {
                    //We are here which means human thew Paper. Paper covers rock. Human wins!
                    Console.WriteLine($"{human.Name} wins");
                    human.Score++;
                }
            }
            else if (player.roshambo == Roshambo.paper) 
            {
                //Player threw Paper. If we are here human can only throw scissor or rock
                if (human.roshambo == Roshambo.scissors)
                {
                    //human has threw Scissor, Scissor cut paper. Human wins!
                    Console.WriteLine($"{human.Name} wins");
                    human.Score++;
                }
                else //Rock
                {
                    //We are here which means human thew Rock. Paper covers Rock. Player wins!
                    Console.WriteLine($"{player.Name} wins");
                    player.Score++;
                }
            }
            else if (player.roshambo == Roshambo.scissors) 
            {
                //Player threw Scissors. If we are here human can only throw rock or paper
                if (human.roshambo == Roshambo.rock)
                {
                    //human has threw Rock, Rock crushed Scissors. Human wins!
                    Console.WriteLine($"{human.Name} wins");
                    human.Score++;
                }
                else //paper
                {
                    //We are here which means human thew Paper. Scissors cuts Paper. Player wins!
                    Console.WriteLine($"{player.Name} wins");
                    player.Score++;
                }
            }
        }
    }
}
