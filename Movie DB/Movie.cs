using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Movie_DB
{
    internal class Movie
    {
        //fields
        public string Title { get; set; }
        public string Category { get; set; }

        //Constructor
        internal Movie( string category, string title)
        {
            Title = title;
            Category = category; 
        }

        //Display Title
        internal void DisplayMovie()
        {
            Console.WriteLine($"{Title}");
        }

    }
    
}
