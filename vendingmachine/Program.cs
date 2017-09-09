using System;
using System.Collections.Generic;

namespace vendingmachine
{
    public partial class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the soda machine");
            Console.WriteLine("Type 0 for Soda and 1 for exit");
            int userSelect = int.Parse(Console.ReadLine());

            if (userSelect == 0)
            {
                Console.WriteLine("Which type of soda do you want?");
                Console.WriteLine("You can choose \n 1 for Cola \n 2 for Urge \n 3 for sprite \n 4 for Fanta \n 5 for Dr Pepper \n 6 for Monster ");
                int sodaselect = int.Parse(Console.ReadLine());
                Serve sodaCstr1 = new Serve();
                sodaCstr1.Validate(sodaselect);

            } 
        }
    }
}