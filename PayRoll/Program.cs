using System;
using System.Collections.Generic;
namespace PayRoll;
class Program
{
    static List<EmployeeDetails> EmployeeList = new List<EmployeeDetails>();
    public static void Main(string[] args)
    {

        bool isRunning = true;
        Console.WriteLine("---------------------Welcome ---------------------");
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
        EmployeeDetails details = new EmployeeDetails();
        Console.Write("Enter your Name: ");
        details.EmployeeName = Console.ReadLine();
        Console.Write("Enter your Role: ");
        details.Role = Console.ReadLine();
        Console.Write("Choose your work Location(AnnaNagar/Kilpauk): ");
        bool isValidPlace = Enum.TryParse<Location>(Console.ReadLine(), true, out Location location);
        while (!isValidPlace)
        {
            Console.WriteLine("Invalid! please Enter a valid Option");
            Console.Write("Choose your work Location(AnnaNagar/Kilpauk): ");
            isValidPlace = Enum.TryParse<Location>(Console.ReadLine(), true, out location);
        }
        details.WorkLocation = location;
        Console.Write("Enter your Team Name: ");
        details.TeamName = Console.ReadLine();
        Console.Write("Enter Date Of Joining(dd/MM/yyyy): ");
        details.DateOfJoining = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
        Console.Write("Enter Number of Working Days in Month: ");
        details.WorkingDays = int.Parse(Console.ReadLine());
        Console.Write("Enter Number of Leave Taken: ");
        details.LeaveTaken = int.Parse(Console.ReadLine());
        Console.Write("Choose your Gender(Male/Female/Others): ");
        bool validGender = Enum.TryParse<Gender>(Console.ReadLine(), true, out Gender gender);
        while (!validGender)
        {
            Console.WriteLine("Invalid! Please Enter a valid Option");
            Console.Write("Choose your Gender(Male/Female/Others): ");
            validGender = Enum.TryParse<Gender>(Console.ReadLine(), true, out gender);
        }
        details.Gender = gender;
        Console.WriteLine("Resgistration Successful:-)");
        Console.WriteLine($"Your Employee Id is {details.EmployeeId}\n(note: Remember your Employee Id. Your able to Login only using Employee Id)");
        EmployeeList.Add(details);
        Console.WriteLine("Press any key to continue");
        Console.WriteLine("------------------------------------------------");
        Console.ReadKey();
    }

    //Method for Login
    static void Login()
    {
        Console.WriteLine("------------------WELCOME---------------------");
        Console.Write("Enter your Employee Id: ");
        string id = Console.ReadLine();
        bool isPresent = false;
        foreach (EmployeeDetails employee in EmployeeList)
        {
            if (employee.EmployeeId == id)
            {
                isPresent = true;
                Console.WriteLine($"---------------- WELCOME {employee.EmployeeName}:-) --------------");
                bool flag = true;
                while (flag)
                {
                    Console.WriteLine("Choose the Option You want");
                    Console.WriteLine("1. Calculate Salary\n2. Display details\n3. Exit");
                    string option = Console.ReadLine();
                    switch (option)
                    {
                        case "1":
                            {
                                employee.CalculateSalary();
                                break;
                            }
                        case "2":
                            {
                                employee.ShowDetails();
                                break;
                            }
                        case "3":
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
            Console.WriteLine("User Invalid Id:-(");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}