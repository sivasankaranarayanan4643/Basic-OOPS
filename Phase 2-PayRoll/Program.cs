using System;
using System.Collections.Generic;
namespace PayRoll;
class Program
{
    public static List<EmployeeDetails> employeeList = new List<EmployeeDetails>();
    public static void Main(string[] args)
    {
        EmployeeDetails employee1=new EmployeeDetails("Ravi",9958858888,Gender.Male,Branch.Eymard,Team.Developer);
        employeeList.Add(employee1);
        bool isRunning = true;
        while (isRunning)
        {
        Console.WriteLine("--------------Syncfusion Software Private Limited---------------");
            Console.WriteLine("Choose the Option you want");

            Console.WriteLine("1. Employee Registration");
            Console.WriteLine("2. Employee Login");
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


    //Registration

    public static void Registration()
    {
        Console.WriteLine("-----------------------Registration-------------------------");
        EmployeeDetails employee = new EmployeeDetails();
        Console.Write("Enter Your Full Name: ");
        employee.Name = Console.ReadLine();
        Console.Write("Enter your Date Of Birth dd/MM/yyyy: ");
        bool isValidDOB = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime DOB);
        //for validating user input
        while (!isValidDOB)
        {
            Console.WriteLine("Invalid Format");
            Console.Write("Enter your Date Of Birth dd/MM/yyyy: ");
            isValidDOB = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DOB);
        }
        employee.DOB = DOB.ToString("dd/MM/yyyy");
        Console.Write("Enter your Phone Number: ");

        //for vaalidating input
        bool isValidPhone = long.TryParse(Console.ReadLine(), out long phone);
        while (!isValidPhone)
        {
            Console.WriteLine("Invalid Phone Number");
            Console.Write("Enter your Phone Number: ");
            isValidPhone = long.TryParse(Console.ReadLine(), out phone);
        }
        employee.Phone = phone;
        Console.Write("Choose your Gender(Male/Female/Transgender): ");
        bool validGender = Enum.TryParse<Gender>(Console.ReadLine(), true, out Gender gender);
        //for validating user input
        while (!validGender)
        {
            Console.WriteLine("Invalid! Please Enter a valid Option");
            Console.Write("Choose your Gender(Male/Female/Transgender): ");
            validGender = Enum.TryParse<Gender>(Console.ReadLine(), true, out gender);
        }
        employee.Gender = gender;
        Console.Write("Enter your Branch Name ( Eymard/ Karuna/ Madhura): ");
        bool validBranch = Enum.TryParse<Branch>(Console.ReadLine(), true, out Branch branch);
        //for validating user input
        while (!validBranch)
        {
            Console.WriteLine("Invalid! Please Enter a valid Option");
            Console.Write("Enter your Branch Name ( Eymard/ Karuna/ Madhura): ");
            validBranch = Enum.TryParse<Branch>(Console.ReadLine(), true, out branch);
        }
        employee.Branch = branch;
        Console.Write("Enter your Team(Network/Hardware/ Developer/Facility): ");
        bool validTeam = Enum.TryParse<Team>(Console.ReadLine(), true, out Team team);
        //for validating user input
        while (!validTeam)
        {
            Console.WriteLine("Invalid! Please Enter a valid Option");
            Console.Write("Enter your Team(Network/Hardware/ Developer/Facility): ");
            validTeam = Enum.TryParse<Team>(Console.ReadLine(), true, out team);
        }
        employee.Team = team;

        employeeList.Add(employee);
        Console.WriteLine($"Employee Registered Successfully and Your Employee ID is {employee.EmployeeID}");
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }

    //Login
    public static void Login()
    {
        Console.WriteLine("------------------WELCOME---------------------");
        Console.Write("Enter your Employee Id: ");
        string id = Console.ReadLine().ToUpper();
        bool isPresent = false;
        foreach (EmployeeDetails employee in employeeList)
        {
            if (employee.EmployeeID == id)
            {
                isPresent = true;
                Console.WriteLine($"---------------- WELCOME {employee.Name}:-) --------------");
                bool flag = true;
                while (flag)
                {
                    Console.WriteLine("Choose the Operation You want");
                    Console.WriteLine("  i. Add Attendance\n ii. Display Details\niii. Calculate Salary\n iv. Exit");
                    string option = Console.ReadLine();
                    switch (option)
                    {
                        case "i":
                            {
                                AttendanceDetails.CreateAttendance(employee.EmployeeID);
                                Console.WriteLine("Press Any key to Continue");
                                Console.WriteLine("--------------------------------");
                                Console.ReadKey();
                                break;
                            }
                        case "ii":
                            {
                                employee.DisplayDetails();
                                break;
                            }
                        case "iii":
                            {
                                AttendanceDetails.CalculateSalary(employee.EmployeeID);
                                break;
                            }
                        case "iv":
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
            Console.WriteLine("Invalid Employee Id:-(");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }

}