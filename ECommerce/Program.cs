using System;
using System.Collections.Generic;
namespace ECommerce;
class Program
{
    public static List<CustomerDetails> customerList = new List<CustomerDetails>();
    public static void Main(string[] args)
    {
        ProductDetails.Products("Mobile(Samsung)", 10, 10000, 3);
        ProductDetails.Products("Tablet(Lenovo)", 5, 15000, 2);
        ProductDetails.Products("Camera(Sony)", 3, 20000, 4);
        ProductDetails.Products("iphone", 5, 50000, 6);
        ProductDetails.Products("Laptop(Lenovo I3)", 3, 40000, 3);
        ProductDetails.Products("HeadPhone(Boat)", 5, 1000, 2);
        ProductDetails.Products("Speakers(Boat)", 4, 500, 2);
        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("--------------SynCart---------------");
            Console.WriteLine("Choose the Option you want");

            Console.WriteLine("1. Customer Registration");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit");
            Console.Write("Select an Option: ");

            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    {
                        Registration();
                        break;
                    }
                case "2":
                    {
                        Login();
                        break;
                    }
                case "3":
                    {

                        isRunning = false;
                        break;

                    }
                default:
                    {
                        Console.WriteLine("Invalid Option! ");
                        break;
                    }
            }
        }
    }

    //Method for Registration
    static void Registration()
    {
        Console.WriteLine("---------------------Registration--------------------");
        CustomerDetails customer = new CustomerDetails();
        Console.Write("Enter Your Name: ");
        customer.Name = Console.ReadLine();
        Console.Write("Enter your Residing City : ");
        customer.City = Console.ReadLine();


        Console.Write("Enter your Phone Number: ");

        //for vaalidating input
        bool isValidPhone = long.TryParse(Console.ReadLine(), out long phone);
        while (!isValidPhone)
        {
            Console.WriteLine("Invalid Phone Number");
            Console.Write("Enter your Phone Number: ");
            isValidPhone = long.TryParse(Console.ReadLine(), out phone);
        }
        customer.Phone = phone;

        Console.Write("Enter your Mail Id: ");
        customer.Mail = Console.ReadLine();

        Console.Write("Enter the Initial amount to deposit in your Wallet(in Rupees)");
        customer.Balance = double.Parse(Console.ReadLine());

        customerList.Add(customer);
        Console.WriteLine($"Customer Registered Successfully and  Customer ID is {customer.CustomerId}");
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }

    //Method for List
    static void Login()
    {
        Console.WriteLine("------------------WELCOME---------------------");
        Console.Write("Enter your Customer Id: ");
        string id = Console.ReadLine();
        bool isPresent = false;
        foreach (CustomerDetails customer in customerList)
        {
            if (customer.CustomerId == id)
            {
                isPresent = true;
                Console.WriteLine($"---------------- WELCOME {customer.Name}:-) --------------");
                bool flag = true;
                while (flag)
                {
                    Console.WriteLine("Choose the Operation You want");
                    Console.WriteLine("a. Purchase\nb. Order History\nc. Cancel Order\nd. Wallet Balance\ne. Wallet Recharge\nf. Exit");
                    string option = Console.ReadLine();
                    switch (option)
                    {
                        case "a":
                            {
                                customer.Purchase();
                                break;
                            }
                        case "b":
                            {
                                OrderDetails.OrderHistory(customer.CustomerId, "ALL");
                                break;
                            }
                        case "c":
                            {
                                customer.CancelOrder();
                                break;
                            }
                        case "d":
                            {
                                Console.WriteLine($"Your Current Wallet Balance is {customer.Balance}");
                                break;
                            }
                        case "e":
                            {
                                Console.Write("Enter the Recharge Amount: ");
                                double amount = double.Parse(Console.ReadLine());
                                customer.WalletRecharge(amount);
                                Console.WriteLine($"Your current wallet balance is {customer.Balance}");
                                break;
                            }
                        case "f":
                            {
                                flag = false;
                                Console.WriteLine("--------------- THANK YOU:-) ---------------");
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Invalid Option");
                                break;
                            }
                    }
                }
            }
        }
        if (!isPresent)
        {
            Console.WriteLine("Invalid Customer Id:-(");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}