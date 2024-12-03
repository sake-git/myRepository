
namespace Roshambo_Project
{
    //RockPlayer inherits from player 
    internal class RockPlayer : Player
    {
        public RockPlayer(string name) : base(name) //Parameterized constructor
        {
        }
        public override Roshambo GenerateRoshambo() //Method overriden to always return value as Rock
        {
            return Roshambo.rock;
        }
    }
}
