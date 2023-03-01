using System;
using System.IO;

namespace homework1
{
    class Program
    {
        
        static void Main(string[] args)
        {
         
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();
            Console.Write("Enter agency: ");
            string agency = Console.ReadLine();

            Console.WriteLine(CheckPassword(password,agency));

        }

        static bool CheckPassword(string password,string agency){
            
          
            string[] stringAgent = {"FBI","CIA","NSA"};
        

            if(password.Length == 6 && stringAgent.Any(agency.Contains) && password != null && agency != null)
            {
                return CheckIfCIA(password,agency) || CheckIfFBI(password,agency) || CheckIfNSA(password,agency) ;
            }
            else
            {
                return false;
            } 
                
                
        }
        
        static bool CheckIfCIA(string password,string agency)
        {
            string[] checkNumCIA = {"1","3","5"};

            bool condition1CIA =  getDigitNumber(password,6) % 3 == 0;
            bool condition2CIA = !checkNumCIA.Any(getDigitNumber(password,5).ToString().Contains);
            bool condition3CIA = getDigitNumber(password,4) != 6 && getDigitNumber(password,4) != 8;
            
            return ( agency == "CIA" && condition1CIA && condition2CIA && condition3CIA );
        }

        static bool CheckIfFBI(string password,string agency)
        {

            bool condition1FBI = getDigitNumber(password,1) >= 4 && getDigitNumber(password,1) <= 7;
            bool condition2FBI = getDigitNumber(password,4) % 2 == 0 && getDigitNumber(password,4) != 6;
            bool condition3FBI = getDigitNumber(password,2) % 2 != 0;

            return (agency == "FBI" && condition1FBI && condition2FBI && condition3FBI );
        }

        static bool CheckIfNSA(string password,string agency)
        {
            
            bool condition1NSA = 30 % getDigitNumber(password,6) == 0 ;
            bool condition2NSA = getDigitNumber(password,4) % 3 == 0 && getDigitNumber(password,4) % 2 != 0;
            bool condition3NSA = password.Any("7".Contains);

            return (agency == "NSA" && condition1NSA && condition2NSA && condition3NSA );
        }

        static int getDigitNumber(string Number,int digit) //get nth digit from Number
        {
           return int.Parse(Number[digit-1].ToString());
        }


    }
}