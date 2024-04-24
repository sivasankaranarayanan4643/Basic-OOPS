using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    /// <summary>
    /// DataType Gender used to select a instance of  <see cref="StudentDetails"/> Gender Information 
    /// </summary>
    public enum Gender { Male, Female, Transgender }
    /// <summary>
    /// Class StudentDetails used to create instance for student <see cref="StudentDetails"/> 
    /// Refer documentation on <see href="www.syncfusion.com"/> 
    /// </summary>
    public class StudentDetails
    {
        /// <summary>
        /// Static Field s_studentId used to autoincrement StudentID of the instance of <see cref="StudentDetails"/>
        /// </summary>
        private static int s_studentId = 3000;
        /// <summary>
        /// StudentId Property used to hold a Student's ID of instance of <see cref="StudentDetails"/> 
        /// </summary>
        public string StudentId { get; }
        /// <summary>
        /// StudentName property used to hold Student Name of a instance of <see cref="StudentDetails"/> 
        /// </summary>
        public string StudentName { get; set; }
        /// <summary>
        /// FatherName property used to hold Student's FatherName of a instance of <see cref="StudentDetails"/>
        /// </summary>
        public string FatherName { get; set; }
        /// <summary>
        /// Gender property used to hold the Student's Gender of a instance of <see cref="StudentDetails"/>
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// DOB property used to hold the student's Date of Birth of a instance of <see cref="StudentDetails"/>
        /// </summary>
        /// <returns></returns>
        public DateTime DOB { get; set; }=new DateTime(1999,11,11);
        /// <summary>
        /// Physics property used to hold Student's Physics mark of a instance of <see cref="StudentDetails"/>
        /// </summary>
        /// <value></value>
        public float Physics { get; set; }
        /// <summary>
        /// Chemkstry property used to hold Student's Chemkstry mark of a instance of <see cref="StudentDetails"/>
        /// </summary>
        public float Chemistry { get; set; }
        /// <summary>
        /// Maths property used to hold Student's Maths mark of a instance of <see cref="StudentDetails"/>
        /// </summary>
        public float Maths { get; set; }
        //Default Constructors

        /// <summary>
        /// Constructor StudentDetails used to initialize default values to its properties
        /// </summary>
        public StudentDetails()
        {
            s_studentId++;
            StudentId = "SF" + s_studentId;
        }
        // Parameterized Constructor
        /// <summary>
        /// Constructor StudentDetails used to initialize parameter values to its properties
        /// </summary>
        /// <param name="name">name parameter used to assign value to StudentName property</param>
        /// <param name="fatherName">fatherName parameter to assign value to FatherName property</param>
        /// <param name="gender">gender parameter to assign value to Gender property</param>
        /// <param name="physics">physics parameter to assign value to Physics property</param>
        /// <param name="chemistry">chemistry parameter to assign value to Chemistry property</param>
        /// <param name="maths">maths parameter to assign value to Maths property</param>
        public StudentDetails(string name, string fatherName, Gender gender, float physics,float chemistry, float maths){
            s_studentId++;
            StudentId = "SF" + s_studentId;
            StudentName=name;
            FatherName=fatherName;
            Gender=gender;
            Physics=physics;
            Chemistry=chemistry;
            Maths=maths;
        }

        //method for check Eligibility
        /// <summary>
        /// Method CheckEligibility used to check whether the instance of <see cref="StudentDetails"/>
        /// is eligible for admission based on cutoff
        /// </summary>
        /// <returns>return true if eligible, else false.</returns>
        public bool CheckEligibility()
        {
            double average = (double)(Physics + Chemistry + Maths) / 3;
            if (average >= 75.0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        //method for showing details
        /// <summary>
        /// Method ShowDetails used to show the details of the student of a instance of <see cref="StudentDetails"/> 
        /// </summary>
        public void ShowDetails()
        {
            Console.WriteLine("---------------Student Details------------");
            Console.WriteLine($"Student Name:{StudentName}\nFather Name: {FatherName}\nDOB: {DOB.ToString("dd/MM/yyyy")}\nGender: {Gender}");
            Console.WriteLine("Press Any key to Continue");
            Console.WriteLine("------------------------------------------");
            Console.ReadKey();
        }

        //Method for taking admission
        /// <summary>
        /// Method TakeAdmission used to taking admission for the student of an instance of <see cref="StudentDetails"/>
        /// </summary>
        public void TakeAdmission()
        {
            //for checking the student already took admission
            bool alreadyBooked = false;
            foreach (AdmissionDetails admission in AdmissionDetails.admissionList)
            {
                if (admission.StudentId == StudentId && admission.AdmissionStatus == (Admission)1)
                {
                    alreadyBooked = true;
                    Console.WriteLine("Already you took an admission cannot make morethan 1 admission");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    break;
                }
            }
            if (!alreadyBooked)
            {
                //for getting the department details && get the user choice of department
                DepartmentDetails.SeatsAvailability();
                Console.WriteLine("Enter the Department Id you want to take admission");
                string ID = Console.ReadLine().ToUpper();
                bool isPresent = false;
                do
                {
                    foreach (DepartmentDetails department in DepartmentDetails.departmentList)
                    {
                        if (department.DepartmentId == ID)
                        {
                            //Checking eligibility
                            bool isEligible = CheckEligibility();
                            if (isEligible)
                            {
                                if (department.Seats > 0)
                                {
                                    //store the admissionn objects
                                    AdmissionDetails admission = new AdmissionDetails();
                                    admission.StudentId = StudentId;
                                    admission.DepartmentId = ID;
                                    department.Seats--;
                                    AdmissionDetails.admissionList.Add(admission);
                                    Console.WriteLine($"Admission took Successfully, your Admission ID is {admission.AdmissionId}");
                                    Console.WriteLine("Press any key to continue");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine("No seats Available");
                                    Console.WriteLine("Press any key to continue");
                                    Console.ReadKey();
                                }
                            }
                            else
                            {
                                Console.WriteLine("You are not Eligible for Admission");
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();
                            }
                            isPresent = true;
                            break;
                        }
                    }
                    if (!isPresent)
                    {
                        Console.WriteLine("Enter a valid Department Id");
                        ID = Console.ReadLine().ToUpper();
                    }
                } while (!isPresent);
            }

        }

    }
}