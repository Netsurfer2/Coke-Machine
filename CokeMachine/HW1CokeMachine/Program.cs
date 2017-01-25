/*******************************************************************************************
 * Class: Programming 120  (Classes and Objects)                                           *
 * Project: HW1 Coke Machine                                                               *
 * Professor: Kurt Friedrich                                                               *
 * Name: Chris Singleton                                                                   *
 * Date: 09/24/2016                                                                        *
 *******************************************************************************************
 * Summary: 1. Coke machine where you put in a dollar and it gives you a coke.             *
 *          2. Machine only holds 5 cokes. (You can only buy up to 5 cokes)                *
 *          3. The machine will give you back all your money less the cokes you buy.       *
 *          4. If the machine runs out of coke, lets you know and you cannot buy anymore.  *
 *          5. If the machine runs out of money, lets you know and you cannot buy anymore. *
 *          6. You can put in as much money as you want. (1 dollar at a time)              *
 ******************************************************************************************/


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
            string customerCommand;  // used to hold customer's command
            int customerAmt = 1;     // used to hold deposit or withdrawal amount
            int cokeAmt = 5;        // used to hold coke amount.

            Boolean fundsAvailable; // used to catch result of funds availability.
            Boolean cokeAvailable;  // used to catch result of coke availability.
            
            ChangeVend BellevueVendCoke;  // name and create a new variable of type ChangeVend, then.
            BellevueVendCoke = new ChangeVend(); //instantiate an object instance of a new object, call constructor, new returns reference to object.
        
            Console.Write("\n\t    Welcome to the Bellevue Coke Machine! \n"); //Give a welcome to the customer.
            BellevueVendCoke.DisplayMenu(); // Display the menu.
            
            customerCommand = Console.ReadLine();           // Allows user input.
            customerCommand = customerCommand.ToUpper();    // Allow user to type upper or lower case.
            while (customerCommand != "Q")                  // Loop until user is done.
            {
                switch (customerCommand)
                {
                    case "P": // Deposit a dollar.
                        Console.Clear();
                        BellevueVendCoke.AcceptCash(customerAmt); // Add funds using the AcceptCash method.
                        Console.Write("Thank you! You now have ${0}.00 \n", BellevueVendCoke.Balance); //Call the balance method.
                        BellevueVendCoke.DisplayMenu();
                        break;

                    case "B": // Buy a coke.
                        /* Check true or false if funds and/or coke is available by calling both methods.*/
                        fundsAvailable = BellevueVendCoke.CheckPurchase(customerAmt);
                        cokeAvailable = BellevueVendCoke.BuyCoke(cokeAmt);

                        if (fundsAvailable == true && cokeAvailable == true)
                        {
                            Console.Clear();
                            Console.Write("Thank you for your purchase! You have ${0}.00 \n", BellevueVendCoke.PurchaseBalance);
                            BellevueVendCoke.DisplayMenu();
                        }
                        else if (cokeAvailable == false) // If coke is not available.
                        {
                            Console.Clear();
                            Console.Write("Sorry, the machine is empty, enter an R to get your money back. \n");
                            BellevueVendCoke.DisplayMenu();
                        }
                        else // None of the conditions apply.
                        {
                            Console.Clear();
                            Console.Write("Sorry, you have to insert more money. \n");
                            BellevueVendCoke.DisplayMenu();
                        }
                        break;

                    case "R": // Get your money back.
                        Console.Clear();
                        fundsAvailable = BellevueVendCoke.GiveRefund(customerAmt); // Call the GiveRefund method.
                        if (fundsAvailable == true) // If funds are available allow the refund.
                        {
                            Console.Write("Here is your ${0}.00 \n", BellevueVendCoke.Balance);
                            BellevueVendCoke.DisplayMenu();
                            BellevueVendCoke.ZeroWithdrawlAcct(); // Zero the account upon refund.
                        }
                        else // You have no money in the machine.
                        {
                            Console.Clear();
                            Console.Write("Sorry, you need to insert a dollar. \n");
                            BellevueVendCoke.DisplayMenu();
                        }
                        break;
                    default:
                        Console.Write("Invalid selection. \n");
                        BellevueVendCoke.DisplayMenu();
                        break;
                } //End of switch.
                customerCommand = Console.ReadLine();
                customerCommand = customerCommand.ToUpper(); // Allow user to type upper or lower case
            } //End of while.
            Console.Write("\n Thank you for purchasing our products.\n Please press any key to end this program. ");
            Console.ReadKey(); // Pause before ending.
            Console.Clear(); 
        }
    }
}
