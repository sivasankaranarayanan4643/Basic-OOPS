using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace PayRoll
{
    /// <summary>
    /// class holding the property for attendance details of the employee of the instance of <see cref="AttendanceDetails"/>
    /// </summary>
    public class AttendanceDetails
    {
        /// <summary>
        /// static List for storing the attendance details of the employee
        /// </summary>
        public static List<AttendanceDetails> attendanceList = new List<AttendanceDetails>();
        /// <summary>
        /// static field for the auto incrementation of the attendance id of the instance of <see cref="AttendanceDetails"/>
        /// </summary>
        private static int s_idInfo = 1000;
        /// <summary>
        /// Read only property holds the attendance id of the employee of the instance of <see cref="AttendanceDetails"/>
        /// </summary>
        /// <value></value>
        public string AttendanceID { get; }
        /// <summary>
        /// Property holds the Employee ID of the instance of <see cref="AttendanceDetails"/>
        /// </summary>
        /// <value></value>
        public string EmployeeID { get; set; }
        /// <summary>
        /// Property holds the date of the attendance of the instance of <see cref="AttendanceDetails"/>
        /// </summary>
        /// <value></value>
        public DateTime Date { get; set; }
        /// <summary>
        /// Property holds the check in time of the employee of the instance of <see cref="AttendanceDetails"/>
        /// </summary>
        /// <value></value>
        public DateTime CheckIn { get; set; }
        /// <summary>
        /// Property holds the check out time of the employee of the instance of <see cref="AttendanceDetails"/>
        /// </summary>
        public DateTime CheckOut { get; set; }
        /// <summary>
        /// Property holds the total working hours of the employee of the instance of <see cref="AttendanceDetails"/>
        /// </summary>
        public double TotalHours { get; set; } = 0;
        /// <summary>
        /// For initializing the Attendance id of the instance of <see cref="AttendanceDetails"/>
        /// </summary>
        public AttendanceDetails()
        {
            s_idInfo++;
            AttendanceID = "AID" + s_idInfo;
        }
        /// <summary>
        /// method for creating attendance for the employee of the instance of <see cref="AttendanceDetails"/>
        /// </summary>
        /// <param name="id"></param>
        public static void CreateAttendance(string id)
        {
            Console.Write("Do you want to Check-in(yes): ");
            string option = Console.ReadLine().ToUpper();
            if (option == "YES")
            {
                Console.Write("Enter Check-In Date and Time(dd/MM/yyyy hh:mm tt): ");
                bool isValidDate = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy hh:mm tt", null, System.Globalization.DateTimeStyles.None, out DateTime date);
                //for validating user input
                while (!isValidDate)
                {
                    Console.WriteLine("Invalid Format");
                    Console.Write("Enter Check-In Date and Time(dd/MM/yyyy hh:mm tt): ");
                    isValidDate = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy hh:mm tt", null, System.Globalization.DateTimeStyles.None, out date);
                }
                bool isChecked = false;
                foreach (AttendanceDetails details1 in attendanceList)
                {
                    if (details1.CheckIn.ToString("dd/MM/yyyy") == date.ToString("dd/MM/yyyy") && details1.EmployeeID == id)
                    {
                        isChecked = true;
                    }
                }
                if (!isChecked)
                {
                    AttendanceDetails attendance = new AttendanceDetails();
                    attendance.EmployeeID = id;
                    attendance.Date = date;
                    attendance.CheckIn = date;
                    attendanceList.Add(attendance);
                }
            }
            Console.Write("Do you want to Check-out(yes): ");
            string checkOutOption = Console.ReadLine().ToUpper();
            if (checkOutOption == "YES")
            {
                Console.Write("Enter Check-Out Time(dd/MM/yyyy hh:mm tt): ");
                bool isValidDate1 = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy hh:mm tt", null, System.Globalization.DateTimeStyles.None, out DateTime date1);
                //for validating user input
                while (!isValidDate1)
                {
                    Console.WriteLine("Invalid Format");
                    Console.Write("Enter Check-Out Time(dd/MM/yyyy hh:mm tt): ");
                    isValidDate1 = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy hh:mm tt", null, System.Globalization.DateTimeStyles.None, out date1);
                }
                bool isPresent = false;
                foreach (AttendanceDetails details in attendanceList)
                {
                    if (date1.ToString("dd/MM/yyyy") == details.CheckIn.ToString("dd/MM/yyyy") && details.EmployeeID == id)
                    {
                        details.CheckOut = date1;
                        TimeSpan difference = date1 - details.CheckIn;
                        details.TotalHours = difference.Hours > 8 || difference.Hours < 0 ? 8 : difference.Hours;
                        Console.WriteLine($"Check-in and Checkout Successful and today you have worked {details.TotalHours} Hours");
                        isPresent = true;
                    }
                }
                if (!isPresent)
                {
                    Console.WriteLine("you are not Check in for this date.Check-In first");
                }

            }
        }
        /// <summary>
        /// method for calculating salary for the employee of the instance of <see cref="AttendanceDetails"/>
        /// </summary>
        /// <param name="id"></param>
        public static void CalculateSalary(string id)
        {
            double Hours = 0;
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine("Attendance ID   Employee ID     Date     Check-In   Check-Out   Total Hours Worked");
            Console.WriteLine("----------------------------------------------------------------------------------");
            bool isPresent=false;
            foreach (AttendanceDetails attendance in attendanceList)
            {
                if (attendance.EmployeeID == id && attendance.Date.ToString("MM") == DateTime.Now.ToString("MM"))
                {
                    isPresent=true;
                    Hours += attendance.TotalHours;
                    Console.WriteLine($"{attendance.AttendanceID.PadRight(16, ' ')}{attendance.EmployeeID.PadRight(13, ' ')}{attendance.Date.ToString("dd/MM/yyyy").PadRight(12, ' ')}{attendance.CheckIn.ToString("hh:mm tt").PadRight(12, ' ')}{attendance.CheckOut.ToString("hh:mm tt").PadRight(20, ' ')}{attendance.TotalHours}");
                    Console.WriteLine("----------------------------------------------------------------------------------");
                }
            }
            if (!isPresent)
            {
                Console.WriteLine("No Check-in found");
            }
            else
            {
                double days = Hours / 8;
                Console.WriteLine($"Your Salary for this month is {Math.Round(days * 500)}");
            }
        }
    }
}