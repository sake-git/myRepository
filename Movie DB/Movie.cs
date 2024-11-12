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
        public int YearOfRelease {  get; set; }
        public int RunTime { get; set; }

        //Constructor
        internal Movie( string category, string title, int yearOfRelease, int runTime )
        {
            Title = title;
            Category = category; 
            YearOfRelease = yearOfRelease;
            RunTime = runTime;

        }

        //Display Title
        internal void DisplayMovie()
        {
            Console.WriteLine($"{Title,-22}\t {YearOfRelease, 5} \t\t {RunTime,5} mins");
        }

    }
    
}
