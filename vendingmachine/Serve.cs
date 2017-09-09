using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Threading;

namespace vendingmachine
{
    public partial class Program
    {
        public string flavor { get; set; }
        public static int Soda { get; set; }
        public static string ErrorMs { get; set; }
        public static string DisplayMs { get; set; }
        
        class Serve
        {
            public Serve()
            {
                sodas = new List<Sodas>();

                for (int i = 0; i < 20; i++)
                {
                    sodas.Add(new Sodas() { Soda = "Coca Cola", SodaId = 5000, SodaCost = 20});
                    sodas.Add(new Sodas() { Soda = "Urge", SodaId = 5001, SodaCost = 20});     
                    sodas.Add(new Sodas() { Soda = "Sprite", SodaId = 5002, SodaCost = 20 });   
                    sodas.Add(new Sodas() { Soda = "Fanta", SodaId = 5003, SodaCost = 20});    
                    sodas.Add(new Sodas() { Soda = "Dr Pepper", SodaId = 5004, SodaCost = 20});
                    sodas.Add(new Sodas() { Soda = "Monster", SodaId = 5005, SodaCost = 30}); ;
                    
                }                  
                                
            }

            public void Validate(int soda)
            {
                Soda = soda;
                string sodaOptn;
                int sodaID;
                int sodaCost;
                switch (Soda)
                {
                    case 1:
                        sodaOptn = "Coca Cola";
                        sodaID = 5000;
                        sodaCost = 20;
                        break;
                    case 2:
                        sodaOptn = "Urge";
                        sodaID = 5001;
                        sodaCost = 20;
                        break;
                    case 3: 
                        sodaOptn = "Sprite";
                        sodaID = 5002;
                        sodaCost = 20;
                        break;
                    case 4: 
                        sodaOptn = "Fanta";
                        sodaID = 5003;
                        sodaCost = 20;
                        break;
                    case 5: 
                        sodaOptn = "Dr Pepper";
                        sodaID = 5004;
                        sodaCost = 20;
                        break;
                    case 6: 
                        sodaOptn = "Monster";
                        sodaID = 5005;
                        sodaCost = 30;
                        break;
                    default:
                        sodaOptn = "Unknown";
                        sodaID = 0000;
                        sodaCost = 0;
                        break;
                    
                        
                }


                if (sodas.Exists(x => x.SodaId.Equals(sodaID)))
                {
                    ErrorMs = $"The soda {sodaOptn} is in storage";
                    DisplayMs =  $"Would you like to continue with buying the selected item: {sodaOptn} \n Type 0 for yes and 1 for no?";

                }
                else
                {
                   ErrorMs = $"The soda {sodaOptn} is not in storage";
                }
       
                Console.WriteLine($"\nChecking if Soda {sodaOptn} exists \n Please wait...");
                int milliseconds = 2000;
                Thread.Sleep(milliseconds);
                
                Console.WriteLine($"{ErrorMs} \n {DisplayMs}");

                int userSel = int.Parse(Console.ReadLine());
                if (userSel == 0)
                {
                    DeliverSoda(sodaOptn, sodaCost);

                }
                else
                {
                    int userConf = 0;
                    Console.WriteLine("Would you like to start over, or exit the application? \n type 0 for start over and 1 for exit");
                    userConf = int.Parse(Console.ReadLine());
                    if (userConf == 0)
                    {
                        Console.WriteLine("Starting over... \n please stand by");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Main(null);
                    }
                    else if (userConf == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Exiting...");
                        Environment.Exit(0);

                    }
                    
                }
                

            }

            public void DeliverSoda(string sel, int sodaCost)
            {
                Console.WriteLine($"You have selected soda: {sel}");
                Console.WriteLine("Would you like to pay with cash or visa");
                Console.WriteLine("Type 0 for cash and 1 for Visa");
                int userval = int.Parse(Console.ReadLine());
                if (userval == 0)
                {
                    Console.WriteLine("You are paying with cash0");
                    Console.WriteLine($"This soda cost {sodaCost}");
                    Console.WriteLine("Type in your amount of money");
                    int userAmount = int.Parse(Console.ReadLine());   
                    Exchange(userAmount, sodaCost);            
                    
                }
                else if (userval == 1)
                {
                    Console.WriteLine("You are paying with visa");
                    Console.WriteLine($"This soda cost {sodaCost}");
                    Console.WriteLine("Type in your amount of money");
                    int userAmount = int.Parse(Console.ReadLine());   
                    Exchange(userAmount, sodaCost);            
                }
                
                
            }

            public void Exchange(float userAmount, int sodaCost)
            {
                float userExch = userAmount - sodaCost;
                Console.WriteLine(
                    $"Thank you for your business \n Your payed {userAmount}");
                Console.WriteLine("Stand by for exchange ...");
                Thread.Sleep(2000);
                Console.WriteLine($"Your exchange is {userExch} ");
                Console.WriteLine("Delivering Soda");
                int millsec = 2000;
                Thread.Sleep(millsec);
                Console.WriteLine("Thank you");
                Console.WriteLine("Please come back anytime");
            }


            private List<Sodas> sodas;
        }
    }
}