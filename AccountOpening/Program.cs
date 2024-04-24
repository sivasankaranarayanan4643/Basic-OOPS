using System;
using System.Collections.Generic;
namespace AccountOpening;
class Program
{
    static List<CustomerDetails> CustomerList = new List<CustomerDetails>();
    public static void Main(string[] args)
    {

        bool isRunning = true;
        Console.WriteLine("---------------------Welcome to the Bank---------------------");
        while (isRunning)
        {
            Console.WriteLine("Select the Service you want");

            Console.WriteLine("1.Registration");
            Console.WriteLine("2.Login");
            Console.WriteLine("3.Exit");
            Console.Write("Select an Option: ");

            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    {
                        Registration();
                        break;
                    }
                case 2:
                    {
                        Login();
                        break;
                    }
                case 3:
                    {
                        isRunning = false;
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid Option! ");
                        Console.WriteLine("-------------------------------------------------------");
                        Console.WriteLine("Select the service you want");
                        break;
                    }
            }
        }
    }
    //Method for Registration
    static void Registration()
    {
        CustomerDetails details = new CustomerDetails();
        Console.Write("Enter Name: ");
        details.Name = Console.ReadLine();
        Console.Write("Enter Account Balance(in Rupees): ");
        details.Balance = double.Parse(Console.ReadLine());
        Console.Write("Choose your Gender(Male/Female/Others): ");
        bool validGender = Enum.TryParse<Gender>(Console.ReadLine(), true, out Gender gender);
        while (!validGender)
        {
            Console.WriteLine("Invalid! Please select a valid Option");
            Console.Write("Choose your Gender(Male/Female/Others): ");
            validGender = Enum.TryParse<Gender>(Console.ReadLine(), true, out gender);
        }
        details.Gender = gender;
        Console.Write("Enter your Phone Number: ");
        details.Phone = Console.ReadLine();
        Console.Write("Enter your Mail Id: ");
        details.Mail = Console.ReadLine();
        Console.Write("Enter your Date Of Birth(dd/MM/yyyy): ");
        details.DOB = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
        Console.WriteLine("Resgistration Successful:-)");
        Console.WriteLine($"Your CustomerId is {details.CustomerId}\n(note: Remember your Customer Id. Your able to Login only using Customer Id)");
        CustomerList.Add(details);
        Console.WriteLine("Press any key to continue");
        Console.WriteLine("------------------------------------------------");
        Console.ReadKey();
    }

    //Method for Login
    static void Login()
    {
        Console.WriteLine("------------------WELCOME---------------------");
        Console.Write("Enter your Customer Id: ");
        string id = Console.ReadLine();
        bool isPresent = false;
        foreach (CustomerDetails customer in CustomerList)
        {
            if (customer.CustomerId == id)
            {
                isPresent = true;
                Console.WriteLine($"---------------- WELCOME {customer.Name}:-) --------------");
                bool flag = true;
                while (flag)
                {
                    Console.WriteLine("Choose the Operation You want");
                    Console.WriteLine("1. Deposit\n2. Withdraw\n3. Balance Check\n4.Exit");
                    string option = Console.ReadLine();
                    switch (option)
                    {
                        case "1":
                            {
                                customer.Deposit();
                                break;
                            }
                        case "2":
                            {
                                customer.Withdraw();
                                break;
                            }
                        case "3":
                            {
                                customer.BalanceCheck();
                                break;
                            }
                        case "4":
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