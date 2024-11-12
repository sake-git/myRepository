namespace Movie_DB
{
    internal class Program
    {
        //Enum to convert index used by user to input choice.
        enum TYPE {scifi =1, horror, romantic, fantasy, action, comedy, biographical,animated, drama };
        static void Main(string[] args)
        {
            List<Movie> MovieDb = new List<Movie>() //Movie DB
            {
                new("SciFi", "ET", 1982, 115),
                new("SciFi", "2001:A Space Odyssey", 1968, 149),
                new("Horror", "Alien", 1979, 117),
                new("Horror", "Resident Evil", 2002, 100 ),
                new("Horror", "Cabin Fever", 2002, 94),
                new("Romantic", "Walk to Remember", 2002, 102),
                new("Romantic", "Pretty Women", 1990, 125),
                new("Action", "John Wick", 2014, 101),
                new("Action", "Mission Impossible", 1996 , 110),
                new("Fantasy", "Lord of the rings", 2001, 178),
                new("Fantasy", "Stardust", 2007, 127),
                new("Comedy", "White Chicks", 2004, 109),
                new("Comedy", "Hangover", 2009, 96),
                new("Biographical", "Goodfellas", 1990, 146),
                new("Biographical", "Hidden Figures", 2016, 127 ),
                new("Animated", "Moana", 2016, 103),
                new("Animated", "Ratatouille", 2007, 101),
                new("Animated", "The Nightmare Before Christmas", 1993, 76),
                new("Drama", "Little Woman", 2019, 135),
                new("Drama", "The Shawshank Redemption", 1994, 142),
                new("Drama", "Forest Gump", 1994, 144)
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
                    List<Movie> resultList = MovieDb.Where(x => x.Category.ToLower() == category.ToLower()).OrderBy(x => x.Title).ToList();
                    Console.WriteLine("\nAvailable movies:");
                    Console.ForegroundColor = ConsoleColor.Green;

                    //Display Results
                    Console.WriteLine("\nMovie Title \t\t Year of Release  Runtime");
                    Console.WriteLine("=====================================================");
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
            Console.WriteLine("8. Animated");
            Console.WriteLine("9. Drama");
            Console.WriteLine("***********************************************");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
