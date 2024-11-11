namespace Movie_DB
{
    internal class Program
    {
        //Enum to convert index used by user to input choice.
        enum TYPE {scifi =1, horror, romantic, fantasy, action, comedy, biographical };
        static void Main(string[] args)
        {
            List<Movie> MovieDb = new List<Movie>() //Movie DB
            {
                new("SciFi","ET"),
                new("SciFi","Space Odyssey"),
                new("Horror","Alien"),
                new("Horror","Resident Evil"),
                new("Horror","Cabin Fever"),
                new("Romantic","Walk to Remember"),
                new("Romantic","Pretty Women"),
                new("Action","John Wick"),
                new("Action","Mission Impossible"),
                new("Fantasy","Lord of the rings"),
                new("Fantasy","Stardust"),
                new("Comedy","White Chicks"),
                new("Comedy","Hangover"),
                new("Biographical","Goodfellas"),
                new("Biographical","Hidden Figures")
            };

            do
            {
                DisplayMenu(); //Display Movie categories
                Console.WriteLine("What category are you interested in?");
                string category = Console.ReadLine().Trim();
                int value;
                bool isValid = Int32.TryParse(category, out value); //Check if user has entered index
                TYPE catEnum;
                if (isValid) 
                {
                    //If we are here, user has entered the index number for the category.
                    //Convert it to string to search in DB
                    catEnum = (TYPE) value;
                    category = catEnum.ToString();
                }

                //Check if category entered is valid
                isValid = Enum.IsDefined(typeof(TYPE), category.ToLower());

                if (isValid) //Category is valid
                {   //Filter the results which qualifies
                    List<Movie> resultList = MovieDb.Where(x => x.Category.ToLower() == category.ToLower()).ToList();
                    Console.WriteLine("\nAvailable movies:");
                    Console.ForegroundColor = ConsoleColor.Green;

                    //Display Results
                    foreach (Movie movie in resultList)
                    {
                        movie.DisplayMovie();
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                }else //Category is invalid
                {
                    Console.WriteLine("Invalid category");
                }
                Console.WriteLine("\nContinue? (y/n):"); //Check if user would like to continue?
            } while (Console.ReadLine().ToLower() == "y");
        }

        //Function to display the Menu.
        public static void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("***********************************************");
            Console.WriteLine("\t\t Movie Catalogue");
            Console.WriteLine("***********************************************");
            Console.WriteLine("1. SciFi");
            Console.WriteLine("2. Horror");
            Console.WriteLine("3. Romantic");
            Console.WriteLine("4. Fantasy");
            Console.WriteLine("5. Action");
            Console.WriteLine("6. Comedy");
            Console.WriteLine("7. Biographical");
            Console.WriteLine("***********************************************");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
