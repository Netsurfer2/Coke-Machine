using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class ChangeVend
    {
        // Private class fields to be used.
        private int _AccountBalance;
        private int _cokeBalance;
       

        // Display Menu Method.
        public void DisplayMenu()

        {   // Shows the menu using an array with strings.
            Console.ForegroundColor = ConsoleColor.White; string[] array = new string[5] {
                "\n Please type: P to insert a dollar,",
                      "\n\t      B for Buy a coke,",
                      "\n\t      R for Refund, or",
                      "\n\t      Q to Quit.\n",
                      "\n\t      Select your option: " };
            for (int i = 0; i < array.Length; ++i) { Console.Write(array[i]); }
            return;
        }

        // Constructor, starts the account balance at zero, coke balance to five.
        public ChangeVend()
        {
            _AccountBalance = 0;
            _cokeBalance = 5;
        }

        //========================Regulates the coke=================================
        //===========================================================================

        // Check the coke balance. (Property)
        public int CokeBalance
        {
            get
            {
                return _cokeBalance;
            }
        }

        // Check to see if there is no coke in the machine. (Purchased 5 times)
        public bool BuyCoke(int coke)   // Method to allow coke Purchasing.
        {
           
            bool ok = true;
            if (_cokeBalance < 1) // If condition is true, there is no coke left.
            {
                
                coke = 0;
                ok = false;
            }
            else // There is still coke in the machine.
            {
                coke = 1; //Sets coke to minus 1 each time.
                _cokeBalance = _cokeBalance - coke; // Calculate how many coke are left.
                Dispense(coke); 
            }
            return ok;
        }

        //===========================Regulates the Money====================================
        //==================================================================================

        // Get the money balance from the machine. (Property)
        public int PurchaseBalance
        {
            get
            {
                return _AccountBalance;
            }
        }

        // Check if there is any money in the machine.
        public bool CheckPurchase(int amount)   // Method to allow Purchasing.
        {
            bool ok = true;
            if (_AccountBalance < 1 || _cokeBalance == 0) // Check to see if there is no money in the account or no coke.
            {
                ok = false;
            }
            else
            {
                _AccountBalance = _AccountBalance - amount; // Calculate: Balance minus amount. (Note: amount = 1)
                Dispense(amount);
            }
            return ok;
        }

        //Returns the money balance value.
        public int Balance
        {
            get
            {
                return _AccountBalance;
            }
        }
 
        //Deposit Money.
        public void AcceptCash(int amount) 

        {
            _AccountBalance = _AccountBalance + amount; // Accept a deposit of 1 dollar each time.
            return;
        }

        // See if there is any money in the account, if so get the refund.
        public bool GiveRefund(int amount)   // Allow a full refund of the account balance.
        {
            bool ok = true;
            if (_AccountBalance < amount)
            {
                ok = false;
            }
            else
            {
                amount = 0; // Just get the account balance without amount.  
                _AccountBalance = _AccountBalance - amount; 
                Dispense(amount);
            }
            return ok;
        }

        // Make the account balance back to zero upon refund.
        public void ZeroWithdrawlAcct()
        {
            _AccountBalance = 0;
        }

        // Dispenses the cash and the coke out. 
        private void Dispense(int cashOut) // private method can only be seen from inside this class
        {

        }
    }
}




