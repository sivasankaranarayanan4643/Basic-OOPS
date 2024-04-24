using System;

namespace AccountOpening
{
    public enum Gender { Male, Female, Others }
    public class CustomerDetails
    {
        private static int s_customerIdInfo = 1000;
        public string CustomerId { get; }
        public string Name { get; set; }
        public double Balance { get; set; }
        public Gender Gender { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public DateTime DOB { get; set; }

        public CustomerDetails()
        {
            s_customerIdInfo++;
            CustomerId = "HDFC" + s_customerIdInfo;
        }
        //Deposit
        public void Deposit()
        {
            Console.Write("Enter the Amount to Deposit(in Rupees): ");
            double amount = double.Parse(Console.ReadLine());
            Balance += amount;
            Console.WriteLine($"Your Current Balance is Rs.{Balance}");
            Console.WriteLine("Press any key to continue");
            Console.WriteLine("-----------------------------");
            Console.ReadKey();
        }
        //Withdraw
        public void Withdraw()
        {
            Console.Write("Enter the Amount to Withdraw(in Rupees): ");
            double amount = double.Parse(Console.ReadLine());
            if (amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"Your Current Balance is Rs.{Balance}");
            }
            else
            {
                Console.WriteLine("Insufficient Balance");
            }
            Console.WriteLine("Press any key to continue");
            Console.WriteLine("-----------------------------");
            Console.ReadKey();

        }
        //Balance Check
        public void BalanceCheck()
        {
            Console.WriteLine($"Your Account Balance is Rs.{Balance}");
            Console.WriteLine("Press any key to continue");
            Console.WriteLine("-----------------------------");
            Console.ReadKey();
        }
    }
}
