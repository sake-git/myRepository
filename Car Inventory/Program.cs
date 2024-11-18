

namespace Car_Inventory
{
    internal class Program
    {
        static void Main(string[] args)
        {

            CreateCarDB(); //Creates car DB

            Console.WriteLine("\nWelcome to Grant Chirpus’ Used Car Emporium!\n");
            string userInput="";

            //Check if user wants to login in admin mode
            Console.WriteLine("Login in Admin Mode (y/n)");
            string isAdminMode = Console.ReadLine().ToLower();

            if (isAdminMode == "y") 
            {
                Console.WriteLine("You have logged in Admin Mode and can modify stock details");
            }

            //Display the Options menu until users choose to exit
            do
            {
                DisplayMenu(); //Display menu
                Console.WriteLine("Enter your choice");
                userInput = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Green;
                switch (userInput) 
                {
                    case "1": // List Cars 
                        Cars.ListCars();
                        break;
                    case "2": //Sell Car
                        int choice;
                        bool isValid = false;
                        Cars soldCar = null;
                        while (!isValid)
                        {
                            Console.WriteLine("\nWhich car would you like? ");
                            isValid = int.TryParse(Console.ReadLine(), out choice);
                            if (isValid)
                            {
                                try
                                {
                                    soldCar = Cars.RemoveCar(choice - 1); //Car exists and successfully sold
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    isValid = false;
                                }
                            }
                        }

                        Console.WriteLine(soldCar.ToString()); //Display the details
                        Console.WriteLine("Excellent!  Our finance department will be in touch shortly.\n");
                        break;
                    case "3":
                        BuyBack(); //Buyback used car
                        break;
                    case "4":
                        SearchBy(); // Display by given filter
                        break;
                    case "5": //Edit car..Valid only for Admin Mode
                        if(isAdminMode != "y")
                        {
                            Console.WriteLine("You are not authorized to Modify stock!");
                            break;
                        }
                        ModifyCar();
                        break;
                    case "0":
                        Console.WriteLine("Goodbye!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid input. Try again!");
                        break;
                }
                Console.ForegroundColor = ConsoleColor.Gray;

            } while(true);              
        }
       
        //Function to Buy back used cars
        public static void BuyBack()
        {
            try
            {
                Console.WriteLine("Enter below details for Car:");
                Console.Write("\nMake: ");
                string make = Console.ReadLine(); //get make
                Console.Write("\nModel: ");
                string model = Console.ReadLine();//get model
                Console.Write("\nYear: ");
                int year = int.Parse(Console.ReadLine());//get manufacturing year
                Console.Write("\nPrice: ");
                double price = double.Parse(Console.ReadLine());//get price
                Console.Write("\nMileage ");
                double mileage = double.Parse(Console.ReadLine()); //get mileage
                Cars.carList.Add(new UsedCars(make,model,year,price,mileage)); //Add to the list
                Console.WriteLine("Car bought and added to stock");

            }catch(Exception ex)
            {
                Console.WriteLine("Invalid input. Try again!");
            }
        }

        public static void SearchBy()
        {
            Console.WriteLine("Search by \n1. Make \n2. Model \n3. Price \n4. Used Cars \n5. new Cars");
            Console.WriteLine("Enter you choice");
            string searchChoice = Console.ReadLine();
            List<Cars> cars = null;
            switch (searchChoice)
            {
                case "1": //search by make
                    Console.WriteLine("Enter the Make of car you would like to search");
                    string make = Console.ReadLine();
                    cars = Cars.carList.Where( x=> x.Make.ToLower() == make.ToLower() ).ToList();
                    break;
                case "2": // search by model
                    Console.WriteLine("Enter the Model of car you would like to search");
                    string model = Console.ReadLine();
                    cars = Cars.carList.Where(x => x.Make.ToLower() == model.ToLower()).ToList();
                    break;
                case "3": // search by price
                    Console.WriteLine("Enter the Price");
                    try
                    {
                        double price = double.Parse(Console.ReadLine());
                        cars = Cars.carList.Where(x => x.Price <= price).ToList();
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("Invalid Price entered: "+ ex.Message);
                    }                    
                    break;
                case "4": // display new cars 
                    cars = Cars.carList.Where(x => x.GetType() == typeof(Cars)).ToList();
                    break;
                case "5": //display used cars
                    cars = Cars.carList.Where(x => x.GetType() == typeof(UsedCars)).ToList();
                    break;
                default:
                    Console.WriteLine("Invalid Search criteria!");
                    break;
            }

            if (cars != null) { 
                Cars.ListCars(cars); //Display results
            }
        }

        public static void ModifyCar()
        {
            Cars.ListCars(); //Display all the cars
            int choice;
            bool isValid = false;
            Cars soldCar = null;
            while (!isValid)
            {
                Console.WriteLine("\nWhich car would you like to modify? "); //Check which car details user would like to modify
                isValid = int.TryParse(Console.ReadLine(), out choice);
                if (isValid)
                {
                    try
                    {
                        Cars car = Cars.carList[choice - 1];
                        //User can modify price and mileage of the car
                        Console.WriteLine("Enter new details for Car:"); 
                        Console.Write("\nPrice: "); //get price
                        double price = double.Parse(Console.ReadLine());
                        car.Price = price;
                        if (car.GetType() == typeof(UsedCars)) // If used car, get mileage
                        {
                            UsedCars usedcar = (UsedCars)car;
                            Console.Write("\nMileage ");
                            double mileage = double.Parse(Console.ReadLine());
                            usedcar.Mileage = mileage;
                        }  
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        isValid = false;
                    }
                }
            }
        }

        //This function creates Car Database
        public static void CreateCarDB() 
        {
            Cars.carList.Add(new Cars("Nikolai", "Model S", 2017, 54999.90));
            Cars.carList.Add(new Cars("Fourd", "Escapade", 2017, 31999.90));
            Cars.carList.Add(new Cars("Chewie", "Vette", 2017, 44989.95));
            Cars.carList.Add(new UsedCars("Hyonda", "Prior", 2015, 14795.50, 35987.6));
            Cars.carList.Add(new UsedCars("GC", "Chirpus", 2013, 8500.00, 12345.0));
            Cars.carList.Add(new UsedCars("GC", "Witherell", 2016, 14450.00, 3500.3));
        }

        //Function to Display Menu
        public static void DisplayMenu() 
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("********************************************************************");
            Console.WriteLine("\t\tMenu");
            Console.WriteLine("********************************************************************");
            Console.WriteLine("1. Display Cars");
            Console.WriteLine("2. Buy a Car");
            Console.WriteLine("3. Buyback Car");
            Console.WriteLine("4. Search car by Filter criteria");
            Console.WriteLine("5. Edit Car details. (Admin Only)");
            Console.WriteLine("0. Exit");
            Console.WriteLine("********************************************************************");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
