using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    public class DepartmentDetails
    {
        public static List<DepartmentDetails> departmentList = new List<DepartmentDetails>();
        /// <summary>
        /// Static field s_deparmentId is used to autoincrement DepartmentId of an instance of <see cref="DepartmentDetails"/>
        /// </summary>
        private static int s_departmentId = 100;
        /// <summary>
        /// DepartmentId used to hold the deparment id for each department of an instance of <see cref="DepartmentDetails"/> 
        /// </summar>
        public string DepartmentId { get; }
        /// <summary>
        /// Department name property holds the name of the department 
        /// </summary>
        /// <value></value>
        public string DepartmentName { get; set; }
        public int Seats { get; set; }
        public DepartmentDetails()
        {
            s_departmentId++;
            DepartmentId = "DID" + s_departmentId;
        }

        //Method for Creating Department Details
        /// <summary>
        /// Method DepartmentCreation used to create deparments and their seats of an instance of <see cref="DepartmentDetails"/>
        /// </summary>
        /// <param name="name">name parameter used to assign its value to coressponding property</param>
        /// <param name="seats">seats parameter used to assign its value to corressponding property</param>
        public static void DepartmentCreation(string name, int seats)
        {
            DepartmentDetails department = new DepartmentDetails();
            department.DepartmentName = name;
            department.Seats = seats;
            departmentList.Add(department);
        }

        //Method to Check seats availability
        /// <summary>
        /// Method SeatsAvailability used to display the Deparment details and their seats availabily of an instance of <see cref="DepartmentDetails"/> 
        /// </summary>
        public static void SeatsAvailability()
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Department Id     Department Name     Number Of Seats");
            Console.WriteLine("-----------------------------------------------------");
            //for getting the department details
            foreach (DepartmentDetails department in DepartmentDetails.departmentList)
            {
                Console.WriteLine($"    {department.DepartmentId}              {department.DepartmentName.PadRight(19, ' ')}{department.Seats}");
                Console.WriteLine("-----------------------------------------------------");
            }
        }
    }
}