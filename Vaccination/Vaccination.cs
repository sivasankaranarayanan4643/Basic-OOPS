using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vaccination
{
    /// <summary>
    /// Class holds the property for vaccination details of the user of the instance of <see cref="Vaccination"/>
    /// </summary>
    public class Vaccination
    {
        /*
        •	VaccinationID (Auto increment – VID3001)
        •	Registration Number (Beneficiary Reg. num)
        •	VaccineID
        •	DoseNumber – (1,2,3)
        •	Vaccinated Date (DateTime.Now)
        */
        //Field
        //Static Field
        /// <summary>
        /// static field for the auto incrementation of the vaccination id of the user of the instance of <see cref="Vaccination"/>
        /// </summary>
        private static int s_vaccinationID=3000;
    
        //Properties
        /// <summary>
        /// read only property holds the vaccination id of the user of the instance of <see cref="Vaccination"/>
        /// </summary>
        /// <value></value>
        public string VaccinationID { get; }
        /// <summary>
        /// property holds the registration number of the user of the instance of <see cref="Vaccination"/>
        /// </summary>
        /// <value></value>
        public string RegistrationNumber { get; set; }
        /// <summary>
        /// Property holds the vaccine id of the instance of <see cref="Vaccination"/>
        /// </summary>
        /// <value></value>
        public string VaccineID { get; set; }
        /// <summary>
        /// Protperty holds the dosage information of the instance of <see cref="Vaccination"/>
        /// </summary>
        /// <value></value>
        public int Dosage  { get; set; }
        /// <summary>
        /// Property holds the vaccinated date of the instance of <see cref="Vaccination"/>
        /// </summary>
        /// <value></value>
        public DateTime VaccinatedDate { get; set; }
        
        //Constructor
        /// <summary>
        /// For initializing values for the properties of the instance of <see cref="Vaccination"/>
        /// </summary>
        /// <param name="registrationNumber"></param>
        /// <param name="vaccineID"></param>
        /// <param name="dosage"></param>
        /// <param name="vaccinationDate"></param>
        public Vaccination(string registrationNumber,string vaccineID,int dosage,DateTime vaccinationDate){
            //Auto Incrementation
            s_vaccinationID++;

            VaccinationID="VID"+s_vaccinationID;
            RegistrationNumber=registrationNumber;
            VaccineID=vaccineID;
            Dosage=dosage;
            VaccinatedDate=vaccinationDate;

        }

    }
}