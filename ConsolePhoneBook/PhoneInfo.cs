using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePhoneBook
{
    public class PhoneInfo
    {
        string name;   //필수
        string phoneNumber;  //필수
        string birth;  //선택

        public string Name 
        {
            get { return name; }
        }

        public PhoneInfo(string name, string phoneNumber)
        {
            this.name = name;
            this.phoneNumber = phoneNumber;
        }

        public PhoneInfo(string name, string phoneNumber, string birth)
        {
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.birth = birth;
        }

        

        public void ShowPhoneInfo()
        {
            Console.Write("name: " + this.name);
            Console.Write("\t phone: " + this.phoneNumber);
            if (birth != null)
                Console.Write("\t birth: " + this.birth);
            Console.WriteLine();
        }
        
    }
}
