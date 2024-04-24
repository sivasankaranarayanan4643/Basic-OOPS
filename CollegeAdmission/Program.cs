using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace CollegeAdmission;
class Program
{
    static List<StudentDetails> studentList = new List<StudentDetails>();



    public static void Main(string[] args)
    {
        StudentDetails student1=new StudentDetails("Ravichandran E","Ettapparajan",Gender.Male,95,95,95);
        studentList.Add(student1);
        StudentDetails student2=new StudentDetails("Baskaran S","Sethurajan",Gender.Male,95,95,95);
        studentList.Add(student2);
        //Creating departments and seats
        DepartmentDetails.DepartmentCreation("EEE", 29);
        DepartmentDetails.DepartmentCreation("CSE", 29);
        DepartmentDetails.DepartmentCreation("MECH", 30);
        DepartmentDetails.DepartmentCreation("ECE", 30);


        bool isRunning = true;
        while (isRunning)
        {
        Console.WriteLine("--------------Syncfusion College of Engineering and Technology---------------");
            Console.WriteLine("Choose the Option you want");

            Console.WriteLine("1. Student Registration");
            Console.WriteLine("2. Student Login");
            Console.WriteLine("3. Department wise seat availability");
            Console.WriteLine("4. Exit");
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

                        DepartmentDetails.SeatsAvailability();
                        break;
                    }
                case "4":
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
        Console.WriteLine("--------------------------Registration----------------------------");
        StudentDetails student = new StudentDetails();
        Console.Write("Enter Your Name: ");
        student.StudentName = Console.ReadLine();
        Console.Write("Enter your Father Name: ");
        student.FatherName = Console.ReadLine();
        Console.Write("Choose your Gender(Male/Female/Transgender): ");
        bool validGender = Enum.TryParse<Gender>(Console.ReadLine(), true, out Gender gender);
        //for validating user input
        while (!validGender)
        {
            Console.WriteLine("Invalid! Please Enter a valid Option");
            Console.Write("Choose your Gender(Male/Female/Transgender): ");
            validGender = Enum.TryParse<Gender>(Console.ReadLine(), true, out gender);
        }
        student.Gender = gender;

        Console.Write("Enter your Date Of Birth dd/MM/yyyy: ");
        bool isValidDOB = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime DOB);
        //for validating user input
        while (!isValidDOB)
        {
            Console.WriteLine("Invalid Format");
            Console.Write("Enter your Date Of Birth dd/MM/yyyy: ");
            isValidDOB = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DOB);
        }
        student.DOB = DOB;
        Console.Write("Enter your Physics Mark: ");
        student.Physics = MarkValidation();
        Console.Write("Enter your Chemistry Mark: ");
        student.Chemistry = MarkValidation();
        Console.Write("Enter your Maths Mark: ");
        student.Maths = MarkValidation();
        studentList.Add(student);
        Console.WriteLine($"Student Registered Successfully and  Student ID is {student.StudentId}");
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }

    //Method for List
    static void Login()
    {
        Console.WriteLine("------------------WELCOME---------------------");
        Console.Write("Enter your Student Id: ");
        string id = Console.ReadLine();
        bool isPresent = false;
        foreach (StudentDetails student in studentList)
        {
            if (student.StudentId == id)
            {
                isPresent = true;
                Console.WriteLine($"---------------- WELCOME {student.StudentName}:-) --------------");
                bool flag = true;
                while (flag)
                {
                    Console.WriteLine("Choose the Operation You want");
                    Console.WriteLine("1. Check Eligibility\n2. Show Details\n3. Take Admission\n4. Cancel Admission\n5. Show Admission Details\n6. Exit");
                    string option = Console.ReadLine();
                    switch (option)
                    {
                        case "1":
                            {
                                bool isEligible = student.CheckEligibility();
                                Console.WriteLine(isEligible ? "You are Eligible for Admission" : "You are not Eligible for Admission");
                                Console.WriteLine("Press Any key to Continue");
                                Console.WriteLine("--------------------------------");
                                Console.ReadKey();
                                break;
                            }
                        case "2":
                            {
                                student.ShowDetails();
                                break;
                            }
                        case "3":
                            {
                                student.TakeAdmission();
                                break;
                            }
                        case "4":
                            {
                                AdmissionDetails.CancelAdmission(student.StudentId);
                                break;
                            }
                        case "5":
                            {
                                AdmissionDetails.ShowAdmission(student.StudentId);
                                break;
                            }
                        case "6":
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
            Console.WriteLine("Invalid Student Id:-(");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
    //for validating mark inputs
    static float MarkValidation()
    {
        bool isValid = float.TryParse(Console.ReadLine(), out float mark);
        while (!isValid)
        {
            Console.Write("Enter a valid Mark: ");
            isValid = float.TryParse(Console.ReadLine(), out mark);
        }
        return mark;
    }





}