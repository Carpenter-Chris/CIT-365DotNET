using System;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //variables
            string userName = "Chris", userLocation = "Los Angeles, CA";
            DateTime christmas = new DateTime(2020, 12, 25);
            double christmasCountdown = christmas.Subtract(DateTime.Today).TotalDays;

            //display name and location 
            Console.WriteLine($"My name is {userName}");
            Console.WriteLine($"I am from {userLocation}");

            //display date
            Console.WriteLine("Today is: " + DateTime.Now.ToString("dddd, MMMM dd yyyy"));

            //display number of days until christmas
            Console.WriteLine($"Days until Christmas: {christmasCountdown}");

            //Program example from section 2.1 of C# Programming Yellow Book
            double width, height, woodLength, glassArea; 
            string widthString, heightString;

            Console.WriteLine("To calculate the amount of wood and glass needed to make a window.");

            //takes user input for width of the wood and converts it to a double
            Console.WriteLine("Please enter the width of the window.");
            widthString = Console.ReadLine(); 
            width = double.Parse(widthString);

            //take the user input for height of the wood and converts it to a double
            Console.WriteLine("Please enter the hight of the window.");
            heightString = Console.ReadLine(); 
            height = double.Parse(heightString); 

            //calc the length
            woodLength = 2 * (width + height) * 3.25; 

            //calc the area
            glassArea = 2 * (width * height); 

            //output the results
            Console.WriteLine("The length of the wood is " + woodLength + " feet"); 
            Console.WriteLine("The area of the glass is " + glassArea + " square metres");

            Console.ReadLine();
        }
    }
}
