namespace Circle_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string growCircle;

            Console.WriteLine("************************************************");
            Console.WriteLine("\tWelcome to the Circle Tester");
            Console.WriteLine("************************************************\n");
            bool isValid = false;
            double radius = 0.0;
            do
            {
                Console.WriteLine("Enter radius:");
                string radiusText = Console.ReadLine();
                //Validate input using validator class's validateNumber method
                isValid = Validator.ValidateNumber(radiusText, out radius); 
            } while (!isValid);

            //We are here which means radius is a valid input number. Create Circle instance.
            Circle circle = new Circle(radius);

            do
            {   
                Console.Write($"\nDiameter: {circle.CalculateDiameter(),0:0.00}"); //Calculate diameter
                Console.Write($"\nCircumference: {circle.CalculateCircumference(),0:0.000}"); // calculate circumference
                Console.Write($"\nArea: {circle.CalculateArea(),0:0.000}"); // calculate area

                Console.WriteLine("\nShould the circle grow? (y/n):"); //Check if circle should grow?
                growCircle = Console.ReadLine().ToLower();
                if (growCircle == "y")
                {
                    circle.Grow();         //User wants to grow circle call Grow method of Cicle class           
                }
                else
                {
                    break;
                }

            } while (true);

            //Display final radius after processing
            Console.WriteLine($"\nGoodbye! The circle’s final radius is {circle.GetRadius()}."); 
        }        
    }
}
