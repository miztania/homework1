using System;
using System.IO;

namespace homework1
{
    class Program
    {
        
        static void Main(string[] args)
        {
         
           //get inputs from user 

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();
            Console.Write("Enter agency: ");
            string agency = Console.ReadLine();

            Console.WriteLine(CheckPassword(password,agency));

        }

        static bool CheckPassword(string password,string agency){
            
          
            string[] stringAgent = {"FBI","CIA","NSA"};
        

            if(password.Length == 6 && stringAgent.Any(agency.Contains) && password != null && agency != null) //Check size of password, Agency name, Null
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

            bool condition1CIA =  getDigitNumber(password,6) % 3 == 0; //ตัวเลขหลักหน่วยของรหัสผ่านต้องหารด้วย 3 ลงตัว
            bool condition2CIA = !checkNumCIA.Any(getDigitNumber(password,5).ToString().Contains); //ตัวเลขหลักสิบของรหัสผ่านต้องไม่ใช่ 1, 3, และ 5
            bool condition3CIA = getDigitNumber(password,4) != 6 && getDigitNumber(password,4) != 8; //ตัวเลขหลักพันของรหัสผ่านต้องไม่น้อยกว่า 6 และไม่เท่ากับ 8

            return ( agency == "CIA" && condition1CIA && condition2CIA && condition3CIA );
        }

        static bool CheckIfFBI(string password,string agency)
        {

            bool condition1FBI = getDigitNumber(password,1) >= 4 && getDigitNumber(password,1) <= 7; //ตัวเลขหลักแสนของรหัสผ่านต้องอยู่ในช่วงตั้งแต่ 4-7 เท่านั้น
            bool condition2FBI = getDigitNumber(password,4) % 2 == 0 && getDigitNumber(password,4) != 6; //ตัวเลขหลักร้อยของรหัสผ่านต้องหารด้วย 2 ลงตัว และไม่เท่ากับ 6
            bool condition3FBI = getDigitNumber(password,2) % 2 != 0; //ตัวเลขหลักหมื่นของรหัสผ่านต้องเป็นเลขคี่

            return (agency == "FBI" && condition1FBI && condition2FBI && condition3FBI );
        }

        static bool CheckIfNSA(string password,string agency)
        {
            
            bool condition1NSA = 30 % getDigitNumber(password,6) == 0 ; //ตัวเลขหลักหน่วยของรหัสผ่านต้องเป็นตัวประกอบของ 30
            bool condition2NSA = getDigitNumber(password,4) % 3 == 0 && getDigitNumber(password,4) % 2 != 0; //ตัวเลขหลักร้อยของรหัสผ่านต้องหารด้วย 3 ลงตัว แต่หารด้วย 2 ไม่ลงตัว
            bool condition3NSA = password.Any("7".Contains); //ตัวเลขในรหัสผ่าน 6 ตัวต้องมีเลข 7 อย่างน้อย 1 ตัว

            return (agency == "NSA" && condition1NSA && condition2NSA && condition3NSA );
        }

        static int getDigitNumber(string Number,int digit) //get nth digit from Number
        {
           return int.Parse(Number[digit-1].ToString());
        }


    }
}