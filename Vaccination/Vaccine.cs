using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vaccination
{
    /// <summary>
    /// Class holds the property for vaccine information of the instance of <see cref="Vaccine"/>
    /// </summary>
    public class Vaccine
    {
        /*
        a.	VaccineID {Auto Incremented ID – CID2001}
        b.	VaccineName {Enum – Covishield, Covaccine}
        c.	NoOfDoseAvailable

        */

        //Field
        //Static Field
        /// <summary>
        /// Static field for auto incrementation of the vaccine ID of the instance of <see cref="Vaccine"/>
        /// </summary>
        private static int s_vaccineID=2000;

        //Properties
        /// <summary>
        /// Read only for vaccine id of the instance of <see cref="Vaccine"/>
        /// </summary>
        /// <value></value>
        public string VaccineID { get; }
        /// <summary>
        /// Property holds the vaccine name of the instance of <see cref="Vaccine"/>
        /// </summary>
        /// <value></value>
        public string VaccineName { get; set; }
        /// <summary>
        /// Property holds the dosage availablilty of the instance of <see cref="Vaccine"/>
        /// </summary>
        /// <value></value>
        public int NoOfDoseAvailable { get; set; }

        //Constructor
        /// <summary>
        /// For initializing the value for the property of the instance of<see cref="Vaccine"/>
        /// </summary>
        /// <param name="vaccineName"></param>
        /// <param name="noOfDoseAvailable"></param>
        public Vaccine(string vaccineName,int noOfDoseAvailable)
        {
            //Auto Incrementation
            s_vaccineID++;

            VaccineID="CID"+s_vaccineID;
            VaccineName=vaccineName;
            NoOfDoseAvailable=noOfDoseAvailable;

        }
    }
}