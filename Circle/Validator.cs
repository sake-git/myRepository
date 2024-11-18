namespace Circle_Demo
{
    internal class Validator //Validator class to validate input
    {
        public static bool ValidateNumber(string input, out double number) //Validate and parse the string to double
        {
            try //If input is not a number, parse method will throw and exception.
            {
                number = double.Parse(input);
		if(number < -1){
		}
                return true;
            }
            catch(Exception ex) 
            {
                //Exception occured. Input can't be parsed. (System.FormatException)
                Console.WriteLine("Invalid Number. Please try again");
                number = 0;
                return false;
            }
        }
    }
}
