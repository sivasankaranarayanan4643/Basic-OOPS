using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    /// <summary>
    /// Enum Admission for getting the admission status of the instacne of <see cref="AdmissionDetails"/>
    /// </summary>
    public enum Admission { Select, Booked, Cancelled }
    /// <summary>
    /// Class holds the property for admission details of the instance of <see cref="AdmissionDetails"/>
    /// </summary>
    public class AdmissionDetails
    {
        public static List<AdmissionDetails> admissionList = new List<AdmissionDetails>();
        /// <summary>
        /// static field for the auto incrementation of the admission id of the instance of <see cref="AdmissionDetails"/>
        /// </summary>
        private static int s_admissionId = 1000;
        /// <summary>
        /// read only property holds the admission id of the student of the instance of <see cref="AdmissionDetails"/>
        /// </summary>
        /// <value></value>
        public string AdmissionId { get; }
        /// <summary>
        /// Property holds the student id of the instance of <see cref="AdmissionDetails"/>
        /// </summary>
        /// <value></value>
        public string StudentId { get; set; }
        /// <summary>
        /// Property holds the department ID of the instance of <see cref="AdmissionDetails"/>
        /// </summary>
        /// <value></value>
        public string DepartmentId { get; set; }
        /// <summary>
        /// Property holds the admission date of the instance of <see cref="AdmissionDetails"/>
        /// </summary>
        /// <value></value>
        public DateTime AdmissionDate { get; set; }
        /// <summary>
        /// Property holds the status of the admission of the instance of <see cref="AdmissionDetails"/>
        /// </summary>
        /// <value></value>
        public Admission AdmissionStatus { get; set; }
        /// <summary>
        /// For initializing the value for the properties of the instance of <see cref="AdmissionDetails"/>
        /// </summary>
        public AdmissionDetails()
        {
            s_admissionId++;
            AdmissionId = "AID" + s_admissionId;
            AdmissionDate = DateTime.Now;
            AdmissionStatus = (Admission)1;
        }
        /// <summary>
        /// For cancelling the admission of the students of the instance of <see cref="AdmissionDetails"/>
        /// </summary>
        /// <param name="id"></param>
        public static void CancelAdmission(string id)
        {
            bool isAdmitted = ShowAdmission(id);
            if (isAdmitted)
            {
                Console.WriteLine("Do you really want to cancel your Admission?(yes/No)");
                string cancellation = Console.ReadLine().ToUpper();
                string departmentId = "";
                if (cancellation == "YES")
                {
                    foreach (AdmissionDetails admission in admissionList)
                    {
                        if (admission.StudentId == id && admission.AdmissionStatus == (Admission)1)
                        {
                            admission.AdmissionStatus = (Admission)2;
                            departmentId = admission.DepartmentId;
                            break;
                        }
                    }
                    Console.WriteLine("Admission Cancelled Succesfully");
                    foreach (DepartmentDetails department in DepartmentDetails.departmentList)
                    {
                        if (department.DepartmentId == departmentId)
                        {
                            department.Seats++;
                            break;
                        }
                    }

                }

            }

        }
        /// <summary>
        /// show admission for showing the admission details of the user of the instance of <see cref="AdmissionDetails"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool ShowAdmission(string id)
        {
            bool isAdmitted = false;
            foreach (AdmissionDetails admission in admissionList)
            {
                if (admission.StudentId == id && admission.AdmissionStatus == (Admission)1)
                {
                    Console.WriteLine("------------------------------------------------------------------------------");
                    Console.WriteLine("Admission Id   Student Id  Department Id   Admission Date    Admission Status");
                    Console.WriteLine("------------------------------------------------------------------------------");
                    Console.WriteLine($"    {admission.AdmissionId.PadRight(14, ' ')}{admission.StudentId.PadRight(14, ' ')}{admission.DepartmentId.PadRight(14, ' ')}{admission.AdmissionDate.ToString("dd/MM/yyyy").PadRight(20, ' ')}{admission.AdmissionStatus}");
                    Console.WriteLine("------------------------------------------------------------------------------");
                    isAdmitted = true;
                    break;
                }
            }
            if (!isAdmitted)
            {
                Console.WriteLine("No admission made");
            }
            return isAdmitted;
        }
    }
}