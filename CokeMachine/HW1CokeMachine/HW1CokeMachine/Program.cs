using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendCoke
{
    class Program
    {
        static void Main(string[] args)
        {
            string customerCommand;       // used to hold customer's command
            int customerAmt = 1;          // used to hold deposit or withdrawal amount
            Boolean fundsAvailable;       // used to catch result of withdrawal
            
            ChangeVend BellevueVendCoke;  //name and create a new variable of type ChangeVend, then <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            BellevueVendCoke = new ChangeVend(); //instantiate an object instance of a new object, call constructor, new returns reference to object <<<<<<<

            Console.WriteLine("\n\t    Welcome to the Bellevue Coke Machine!");
            Console.Write("\n\t    Please type: P to enter a dollar,");
            Console.Write("\n\t\t\t B for Buy a coke,");
            Console.Write("\n\t\t\t R for Refund,");
            Console.Write("\n\t\t\t or Q to Quit.");

            customerCommand = Console.ReadLine();
            customerCommand = customerCommand.ToUpper();    // Allow user to type upper or lower case
            while (customerCommand != "Q")                  // Loop until user is done
            {
                switch (customerCommand)
                {
                    case "P": //Deposit a dollar.
                        Console.Clear();
                        BellevueVendCoke.Deposit(customerAmt);
                        Console.WriteLine("Thank you! You now have ${0}.00 ", BellevueVendCoke.Balance);
                        BellevueVendCoke.DisplayMenu();
                        break;

                    case "B": //Buy a coke.
                        fundsAvailable = BellevueVendCoke.CheckPurchase(customerAmt);
                        if (fundsAvailable)
                        {
                            Console.WriteLine("Thank you for your purchase! You have ${0}.00", BellevueVendCoke.PurchaseBalance);
                            BellevueVendCoke.DisplayMenu();
                            
                        }
                        else
                            Console.WriteLine("Sorry, you have to insert more money.");
                        BellevueVendCoke.DisplayMenu();
                        break;

                    case "R": //Get your money back.
                        fundsAvailable = BellevueVendCoke.Withdrawal(customerAmt); //Call object method.
                        if (fundsAvailable)
                        {
                            Console.WriteLine("Here is your ${0}.00", BellevueVendCoke.Balance);
                            BellevueVendCoke.DisplayMenu();
                        }
                        else
                            Console.WriteLine("Sorry, you need to insert a dollar.");
                        BellevueVendCoke.DisplayMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid selection.");
                        break;
                } // End of switch

                //Console.WriteLine("Please enter a B for Balance, D for Deposit, W for Withdrawal or Q to Quit");
                
                customerCommand = Console.ReadLine();
                customerCommand = customerCommand.ToUpper();    // Allow user to type upper or lower case
            } // End of while

            Console.WriteLine("Please take your card and have a good day.");
            Console.ReadKey(); //Pause before ending.
            Console.Clear(); 

        }


    }
}
