using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBBill
{
    public class UserDetails
    {
        private static int s_IdInfo = 1000;

        public string UserId { get; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string MailId { get; set; }
        public double Unit { get; set; }
        public UserDetails()
        {
            s_IdInfo++;
            UserId = "EB" + s_IdInfo;
            Unit = 0;
        }
        //Generate Bill
        public void CalculateAmount()
        {
            Console.Write("Enter the Unit Used: ");
            Unit = double.Parse(Console.ReadLine());
            Console.WriteLine("-----------Bill-----------");
            Console.WriteLine($"User ID: {UserId}\nUser Name: {UserName}\nUnit Used: {Unit}\nAmount: {Unit * 5}");
            Console.WriteLine("Press Any key to Continue");
            Console.WriteLine("----------------------------");
            Console.ReadKey();
        }

        //Show details
        public void ShowDetails()
        {
            Console.WriteLine("------------User Details-----------");
            Console.WriteLine($"User ID: {UserId}\nUser Name: {UserName}\nPhone Number: {Phone}\nMail ID:{MailId}");
            Console.WriteLine("Press Any key to Continue");
            Console.WriteLine("------------------------------------");
            Console.ReadKey();
        }
    }
}