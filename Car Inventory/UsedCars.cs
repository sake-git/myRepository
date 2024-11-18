

namespace Car_Inventory
{
    internal class UsedCars: Cars
    {
        public double Mileage { get; set; } //Mileage 
        public UsedCars():base() //default constructor
        {
            Mileage = 0;
        }

        //Parameterized constructor
        public UsedCars(string make, string model, int year, double price, double mileage): base( make, model, year, price)
        {
            Mileage = mileage;
        }

        //To string method overridden
        public override string ToString() 
        {
            return $"{Make,-12} {Model,-10} {Year,6} {Price,12:C} (Used) {Mileage,9} miles";
        }      
        
    }
}
