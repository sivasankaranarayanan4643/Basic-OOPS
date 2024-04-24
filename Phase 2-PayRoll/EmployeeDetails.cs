using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayRoll
{
    /// <summary>
    /// enum Gender for getting the gender information of the employee of the instance of <see cref="EmployeeDetails"/>
    /// </summary>
    public enum Gender { Male, Female, Transgender }
    /// <summary>
    /// enum Branch for getting the branch of the employee of the instance of<see cref="EmployeeDetails"/>
    /// </summary>
    public enum Branch { Eymard, Karuna, Madhura }
    /// <summary>
    /// enum team for getting the team of the employee of the instance of <see cref="EmployeeDetails"/>
    /// </summary>
    public enum Team { Network, Hardware, Developer, Facility }
    
    /// <summary>
    /// This class used to create a Employee details of the instance of <see cref="EmployeeDetails"/>
    /// </summary>
    public class EmployeeDetails
    {
        /// <summary>
        /// Static field for auto incrementation of the idInfo of the instance of <see cref="EmployeeDetails"/>
        /// </summary>
        private static int s_idInfo = 3000;
        /// <summary>
        /// Read only property holds the Employee ID of the instance of <see cref="EmployeeDetails"/> 
        /// </summary>
        /// <value></value>
        public string EmployeeID { get; }
        /// <summary>
        /// property holds the name of the employee of the instance of <see cref="EmployeeDetails"/>
        /// </summary>
        /// <value></value>
        public string Name { get; set; }
        /// <summary>
        /// property holds the date of birth of the employee of the instance of <see cref="EmployeeDetails"/>
        /// </summary>
        public string DOB { get; set; }=(new DateTime(1999,11,11)).ToString("dd/MM/yyyy");
        /// <summary>
        /// property holds the phone number of the employee of the instacne of <see cref="EmployeeDetails"/>
        /// </summary>
        /// <value></value>
        public long Phone { get; set; }
        /// <summary>
        /// Property holds the gender of the employee of the instance of <see cref="EmployeeDetails"/>
        /// </summary>
        /// <value></value>
        public Gender Gender { get; set; }
        /// <summary>
        /// Property holds the branch of the employee of the instance of <see cref="EmployeeDetails"/>
        /// </summary>
        /// <value></value>
        public Branch Branch { get; set; }
        /// <summary>
        /// Property holds the team of the employee of the instance of <see cref="EmployeeDetails"/>
        /// </summary>
        /// <value></value>
        public Team Team { get; set; }
        /// <summary>
        /// For initializing the value for the properties of the instance of <see cref="EmployeeDetails"/>
        /// </summary>
        public EmployeeDetails()
        {
            s_idInfo++;
            EmployeeID = "SF" + s_idInfo;
        }
        /// <summary>
        /// For initializing the value for the properties of the instance of <see cref="EmployeeDetails"/>
        /// </summary>
        public EmployeeDetails(string name,long phone,Gender gender,Branch branch,Team team)
        {
            s_idInfo++;
            EmployeeID = "SF" + s_idInfo;
            Name=name;
            Phone=phone;
            Gender=gender;
            Branch=branch;
            Team=team;
        }
        /// <summary>
        /// For displaying the details of the employee of the instance of <see cref="EmployeeDetails"/>
        /// </summary>
        public void DisplayDetails()
        {
            Console.WriteLine("---------------Employee Details----------------");
            Console.WriteLine($"Employee ID: {EmployeeID}\nName: {Name}\nDOB: {DOB}\nPhone: {Phone}\nGender: {Gender}\nBranch: {Branch}\nTeam: {Team}");
            Console.WriteLine("Press Any key to Continue");
            Console.WriteLine("-----------------------------------------------");
            Console.ReadKey();
        }
    }

}