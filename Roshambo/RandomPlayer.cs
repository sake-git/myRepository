using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshambo_Project
{
    //RandomPlayer inherits from player 
    internal class RandomPlayer : Player
    {
        public RandomPlayer(string name) : base(name)//Parameterized constructor
        {
        }
        public override Roshambo GenerateRoshambo() //Method overriden to return a random generated value
        {
            Random random = new Random(); //Create an object of random class
            int num = random.Next(0, 3); // Generate a random value from 0-2
            Roshambo roshamboValue = (Roshambo)num; //Convert it to Roshambo value and return
            return roshamboValue;
        }
    }
}
