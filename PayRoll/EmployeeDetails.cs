using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace PayRoll
{
    public enum Gender { Male, Female, Others }
    public enum Location { AnnaNagar, Kilpauk }
    public class EmployeeDetails
    {

        private static int s_employeeId = 1000;
        public string EmployeeId { get; }
        public string EmployeeName { get; set; }
        public string Role { get; set; }
        public Location WorkLocation { get; set; }
        public string TeamName { get; set; }
        public DateTime DateOfJoining { get; set; }
        public int WorkingDays { get; set; }
        public int LeaveTaken { get; set; }
        public Gender Gender { get; set; }

        public EmployeeDetails()
        {
            s_employeeId++;
            EmployeeId = "SF" + s_employeeId;
        }

        public void CalculateSalary()
        {
            int totalDays = WorkingDays - LeaveTaken;
            Console.WriteLine($"Total Working Days: {WorkingDays}\nLeave Taken:{LeaveTaken}");
            Console.WriteLine($"Your Salary for {totalDays} days is Rs.{totalDays * 500}");
            Console.WriteLine("Press any key to continue");
            Console.WriteLine("--------------------------------------------");
            Console.ReadKey();
        }

        public void ShowDetails()
        {
            Console.WriteLine("-------------Employee Details---------------");
            Console.WriteLine($"Employee Name: {EmployeeName}\nRole: {Role}\nWorkLocation: {WorkLocation}\nTeam Name: {TeamName}\nDate Of Joining: {DateOfJoining.ToString("dd/MM/yyyy")}\nGender: {Gender}");
            Console.WriteLine("Press any key to continue");
            Console.WriteLine("--------------------------------------------");
            Console.ReadKey();
        }
    }
}