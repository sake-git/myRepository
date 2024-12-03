using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Car_Inventory
{
    internal class Cars
    {
        public string Make {  get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public static List<Cars> carList = new List<Cars>();

        public Cars() //default constructor
        {
            Make = string.Empty;
            Model = string.Empty;
            Year = 0;
            Price = 0;
        }

        //Parameterized constructor
        public Cars(string make, string model, int year, double price)
        {
            Make = make;
            Model = model;
            Year = year;
            Price = price;
        }

        //To string method overriden
        public override string ToString()
        {
            return $"{Make,-12} {Model,-10} {Year,6} {Price,12:C}";
        }

        //method to List cars from the car list stored in class
        public static void ListCars()
        {
            Console.WriteLine("\n********************************************************************");
            Console.WriteLine("   Make\t\tModel\t     Year\tPrice\t\t Mileage");
            Console.WriteLine("********************************************************************");
            for (int i = 0; i < carList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {carList[i]}");
            }
        }

        //method to List cars from the given list
        public static void ListCars(List<Cars> cars)
        {
            Console.WriteLine("\n********************************************************************");
            Console.WriteLine("   Make\t\tModel\t     Year\tPrice\t\t Mileage");
            Console.WriteLine("********************************************************************");
            for (int i = 0; i < cars.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {cars[i]}");
                Console.WriteLine(cars[i].GetType());
            }
        }

        //method to remove car at given index and return car details
        public static Cars RemoveCar(int index)
        {
            if (index >= carList.Count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Index out of range: " + (index + 1));
            }
            Cars myCar = carList[index];
            carList.RemoveAt(index);
            return myCar;
        }
    }
}
