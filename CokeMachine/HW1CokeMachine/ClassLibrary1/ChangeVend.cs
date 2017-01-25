using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class ChangeVend
    {
        private int _AccountBalance;

        public void DisplayMenu()

        {
            Console.ForegroundColor = ConsoleColor.White; string[] array = new string[4] { "\n Please type: P to enter a dollar,", "\n B for Buy a coke,", "\n R for Refund,", "\n or Q to Quit." };
            Console.Write("\n\n\n Welcome to the Bellevue Coke Machine!");
            for (int i = 0; i < array.Length; ++i) { Console.Write(array[i]); }
            return;
        }

        public void Buy(int amount)
        {
            _AccountBalance = _AccountBalance - amount;
            return;
        }

        public int PurchaseBalance
        {
            get
            {
                return _AccountBalance;
            }
        }
        public bool CheckPurchase(int amount)   // Method to allow Purchasing.
        {
            bool ok = true;
            if (_AccountBalance <= 1)
            {
                ok = false;
            }
            else
            {
                _AccountBalance = _AccountBalance - amount;
                Dispense(amount);
            }
            return ok;
        }



        //================Works====================

        //Constructor or directive.
        public ChangeVend()
        {
            _AccountBalance = 0;
        }

        //=================Works====================
        //***Check your balance.
        public int Balance
        {
            get
            {
                return _AccountBalance;
            }
        }
        //===========================================

        //======================Works====================================
        //Deposit Money.
        public void Deposit(int amount)   // Method to accept a deposit 

        {

            _AccountBalance = _AccountBalance + amount;
            return;
        }
        //===============================================================


        //==========================Works===============================
        //***When you press R for Refund!
        public bool Withdrawal(int amount)   // Method to allow a withdrawal
        {
            bool ok = true;
            if (_AccountBalance < amount)
            {
                ok = false;
            }
            else
            {
                _AccountBalance = _AccountBalance - amount;
                //_AccountBalance++;
                Dispense(amount);
                //amount = 0;
            }
            return ok;
            
        }
        //===============================================================

        private void Dispense(int cashOut) // private method can only be seen from inside this class
        {
            _AccountBalance = 0;
        }


    }




}




