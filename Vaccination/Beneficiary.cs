using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vaccination
{
    //Enum Declaration
    /// <summary>
    /// enum gender for getting the gender info of the user of the instance of <see cref="Beneficiary"/>
    /// </summary>
    public enum Gender{Male,Female,Others}
    /// <summary>
    /// Class holds the property for the user information of the instance of <see cref="Beneficiary"/>
    /// </summary>
    public class Beneficiary
    {
        /*
        a.	Registration Number (Auto Incremented BID1001)
        b.	Name
        c.	Age
        d.	Gender (Enum [Male, Female, Others])
        e.	Mobile Number
        f.	City
        */
        //Field
        //Static Field
        /// <summary>
        /// static field for auto incrementation of the beneficiary id of the instance of <see cref="Beneficiary"/>
        /// </summary>

        private static int s_beneficiaryID=1000;

        //properties
        /// <summary>
        /// Read only property holds the registration number of the user of the instance of <see cref="Beneficiary"/>
        /// </summary>
        /// <value></value>
        public string RegistrationNumber { get; }
        /// <summary>
        /// Property holds the name of the user of the instance of <see cref="Beneficiary"/>
        /// </summary>
        /// <value></value>
        public string Name { get; set; }
        /// <summary>
        /// Property holds the age of the user of the instance of <see cref="Beneficiary"/>
        /// </summary>
        /// <value></value>
        public int Age { get; set; }
        /// <summary>
        /// Property holds the gender of the user of the instance of <see cref="Beneficiary"/>
        /// </summary>
        /// <value></value>
        public Gender Gender { get; set; }
        /// <summary>
        /// Property holds the mobile number of the user of the instance of <see cref="Beneficiary"/>
        /// </summary>
        /// <value></value>
        public string MobileNumber { get; set; }
        /// <summary>
        /// Property holds the city name of the user of the instance of <see cref="Beneficiary"/>
        /// </summary>
        /// <value></value>
        public string City { get; set; }
        /// <summary>
        /// For initializing the value for the property of the instance of <see cref="Beneficiary"/>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="gender"></param>
        /// <param name="mobilNumber"></param>
        /// <param name="city"></param>
/// 
        //Constructor
        public Beneficiary(string name,int age,Gender gender, string mobilNumber,string city)
        {
            //Auto Incrementation
            s_beneficiaryID++;

            RegistrationNumber="BID"+s_beneficiaryID;
            Name=name;
            Age=age;
            Gender=gender;
            MobileNumber=mobilNumber;
            City=city;
            
        }
    }
}