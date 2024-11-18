using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle_Demo
{
    public class Circle
    {
        private double _radius; //private member variable

        public Circle(double radius)  //parameterized constructor
        {
            _radius = radius;
        }

        public double CalculateDiameter() //Calculate diameter. Formula = 2 * radius
        {
            return 2 * _radius;
        }

        public double CalculateCircumference() //Calculate circumference. Formula = 2 * 3.14 * radius
        {
            return 2 * Math.PI * _radius;
        }

        public double CalculateArea() //Calculate Area. Formula = 3.14 * radius * radius
        {
            return Math.PI * Math.Pow(_radius, 2);
        }
        public void Grow() // Double the radius
        {
            _radius *= 2;
            Console.WriteLine("The circle is magically growing.");
        }
        public double GetRadius() //return radius
        {
            return _radius;
        }

    }
}
