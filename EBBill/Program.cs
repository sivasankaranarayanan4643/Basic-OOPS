using System;
using System.Collections.Generic;
namespace EBBill;
class Program
{
    static List<UserDetails> userList = new List<UserDetails>();
    public static void Main(string[] args)
    {
        bool isRunning = true;
        Console.WriteLine("---------------WELCOME----------------");
        while (isRunning)
        {
            Console.WriteLine("Choose the Service you want");
            Console.WriteLine("1. Registration\n2. Login\n3. Exit");
            string choice = Console.ReadLine();
            switch (choice)
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
                        Console.WriteLine("------------- THANK YOU:-) --------------");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid! Option");
                        Console.WriteLine("-----------------------------------------");
                        break;
                    }
            }
        }
    }
    //Method for Registration

    static void Registration()
    {
        UserDetails details = new UserDetails();
        Console.Write("Enter your Name: ");
        details.UserName = Console.ReadLine();
        Console.Write("Enter your Phone Number: ");
        details.Phone = Console.ReadLine();
        Console.Write("Enter your Mail Id: ");
        details.MailId = Console.ReadLine();
        userList.Add(details);
        Console.WriteLine("      Registration Successful       ");
        Console.WriteLine($"Your Meter ID is {details.UserId}");
        Console.WriteLine("(Note: Please remember the MeterId For Login puposes)");
        Console.WriteLine("Press any key to Continue");
        Console.WriteLine("--------------------------------------------------------");
        Console.ReadKey();

    }

    //Method for Login
    static void Login()
    {
        Console.WriteLine("----------Welcome---------");
        Console.Write("Enter your Meter ID: ");
        string meterId = Console.ReadLine();
        bool isPresent = false;
        foreach (UserDetails user in userList)
        {
            if (user.UserId == meterId)
            {
                isPresent = true;
                Console.WriteLine($"-------- WELCOME {user.UserName}:-) ---------");
                bool isLogin = true;
                while (isLogin)
                {
                    Console.WriteLine("1. Calculate Amount\n2. Display details\n3. Exit");
                    string option = Console.ReadLine();
                    switch (option)
                    {
                        case "1":
                            {
                                user.CalculateAmount();
                                break;
                            }
                        case "2":
                            {
                                user.ShowDetails();
                                break;
                            }
                        case "3":
                            {
                                isLogin = false;
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Invalid Option");
                                Console.WriteLine("----------------------------------");
                                break;
                            }

                    }
                }
            }
        }
        if (!isPresent)
        {
            Console.WriteLine("Invalid User ID:-()");
            Console.WriteLine("Press Any key to Continue");
            Console.ReadKey();
        }
    }
}
