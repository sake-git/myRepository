using System;
using System.Collections.Generic;
using System.Linq;

namespace Roshambo_Project
{
    //Abstract Player class
    internal abstract class Player
    {
        //Properties
        public string Name { get; set; } 
        public Roshambo roshambo { get; set; }
        public int Score { get; set; }

        public Player(string name) //Parameterized Constructor
        {
            Name = name;
            Score = 0;
        }

        public abstract Roshambo GenerateRoshambo(); //abstract method to Generate Roshambo
    }
}
