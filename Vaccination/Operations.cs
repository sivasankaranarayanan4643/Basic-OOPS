using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Vaccination
{
    public static class Operations
    {
        static Beneficiary currentLoggedInUser;
        //Static List
        static List<Beneficiary> beneficiaryList = new List<Beneficiary>();
        static List<Vaccine> vaccineList = new List<Vaccine>();
        static List<Vaccination> vaccinationList = new List<Vaccination>();

        //MainMenu
        public static void MainMenu()
        {
            Console.WriteLine("*********Application for Vaccination Drive*********");
            string isRunning = "yes";
            do
            {
                Console.WriteLine("___________Main Menu____________\nSelect an Option\n1. Beneficiary Registration\n2. Login\n3. Get Vaaccine Info\n4. Exit");
                Console.Write("Enter the option you want: ");
                bool tempMainChoice=int.TryParse(Console.ReadLine(),out int mainChoice);
                while(!tempMainChoice||mainChoice<1||mainChoice>4)
                {
                    Console.WriteLine("Invalid option");
                    Console.Write("Enter a valid Option: ");
                    tempMainChoice=int.TryParse(Console.ReadLine(),out mainChoice);
                }
                switch (mainChoice)
                {
                    case 1:
                        {
                            Console.WriteLine("**********Beneficiary Registration*********");
                            BeneficiaryRegistration();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("***********Beneficiary Login*************");
                            BeneficiaryLogin();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("***********Vaccine Info***********");
                            GetVaccineInfo();
                            break;
                        }
                    case 4:
                        {
                            isRunning = "no";
                            Console.WriteLine("Application exited successfully");
                            break;
                        }
                }
            } while (isRunning == "yes");
        }
        //Benificiary Registration
        public static void BeneficiaryRegistration()
        {
            //getting user info
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Enter your age: ");
            bool tempAge=int.TryParse(Console.ReadLine(),out int age);
            while(!tempAge||age<1)
            {
                Console.Write("Enter a valid age: ");
                tempAge=int.TryParse(Console.ReadLine(),out  age);
            }
            Console.Write("Enter your Gender(Male/Female/Others): ");
            bool tempGender=Enum.TryParse<Gender>(Console.ReadLine(),true,out Gender gender);
            while(!tempGender)
            {
                Console.Write("Enter a valid gender(Male/Female/Others): ");
                tempGender=Enum.TryParse<Gender>(Console.ReadLine(),true,out  gender);
            }
            Console.Write("Enter your mobile number: ");
            string mobileNumber = Console.ReadLine();
            Console.Write("Enter your city name: ");
            string city = Console.ReadLine();
            //creating object
            Beneficiary beneficiary = new Beneficiary(name, age, gender, mobileNumber, city);
            //Adding object to the list
            beneficiaryList.Add(beneficiary);
            //registration successful message to the user
            Console.WriteLine($"Registration Successful. Register Number: {beneficiary.RegistrationNumber}");
        }

        //Beneficiary Login
        public static void BeneficiaryLogin()
        {
            //Ask the user for Registration Number
            Console.Write("Enter your Registration Number: ");
            string registerNumber = Console.ReadLine().ToUpper();
            //check whether the Registration number valid or not
            bool flag = true;
            foreach (Beneficiary beneficiary in beneficiaryList)
            {
                if (registerNumber.Equals(beneficiary.RegistrationNumber))
                {
                    flag = false;
                    currentLoggedInUser = beneficiary;
                    Console.WriteLine("Logged  In successfully");
                    //call subMenu if RegisterNumber is present
                    SubMenu();
                }
            }
            if (flag)
            {
                //if not-print Invalid Registration number
                Console.WriteLine("Invalid Registration Number or Registration Number not found");
            }
        }

        //SubMenu
        public static void SubMenu()
        {
            string isRunning = "yes";
            do
            {
                Console.WriteLine("_____________Sub Menu_____________");
                Console.WriteLine("Select the option\n1. Show My Details\n2. Take Vaccination\n3. My Vaccination History\n4. Next Due Date\n5. Exit");
                Console.Write("Enter the Option: ");
                bool tempSubOption=int.TryParse(Console.ReadLine(),out int subOption);
                while(!tempSubOption||subOption<1||subOption>5)
                {
                    Console.Write("Enter a valid option: ");
                    tempSubOption=int.TryParse(Console.ReadLine(),out  subOption);
                }
                switch (subOption)
                {
                    case 1:
                        {
                            Console.WriteLine("************Show Details************");
                            ShowDetails();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("************Take Vaccination**********");
                            TakeVaccination();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("*********My Vaccination History*********");
                            VaccinationHistory();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("***********Next Due Date***********");
                            NextDueDate();
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Taking back to the Main Menu");
                            isRunning = "no";
                            break;
                        }
                }
            } while (isRunning == "yes");
        }

        //Show Details
        public static void ShowDetails()
        {
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine($"|{"Register Number",-10}|{"Name",-15} |{"Age",-5}|{"Gender",-10}|{"Mobile Number",-12}|{"City",-10}|");
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine($"|{currentLoggedInUser.RegistrationNumber,-15}|{currentLoggedInUser.Name,-16}|{currentLoggedInUser.Age,-5}|{currentLoggedInUser.Gender,-10}|{currentLoggedInUser.MobileNumber,-13}|{currentLoggedInUser.City,-10}|");
            Console.WriteLine("----------------------------------------------------------------------------");
        }

        //Take Vaccination
        public static void TakeVaccination()
        {
            //show vaccine details
            GetVaccineInfo();
            //ask the user for vaccine Id
            Console.Write("Enter the Vaccine ID: ");
            string vaccineID = Console.ReadLine().ToUpper();
            int currentDosage = 0;
            //check whether the vaccine ID is valid
            bool flag = true;
            foreach (Vaccine vaccine in vaccineList)
            {
                if (vaccineID.Equals(vaccine.VaccineID))
                {
                    flag = false;
                    //check whether the taken vaccine or not
                    bool readyForVaccination = false;
                    bool alreadyVaccinated = false;
                    bool wrongVaccine = true;
                    foreach (Vaccination vaccination in vaccinationList)
                    {
                        if (vaccination.RegistrationNumber.Equals(currentLoggedInUser.RegistrationNumber))
                        {
                            alreadyVaccinated = true;
                            if (vaccination.VaccineID.Equals(vaccineID))
                            {
                                wrongVaccine = false;
                                //if he already taken vaccine check whether its a same vaccine and third currentDosage or not
                                if (vaccination.Dosage < 3)
                                {
                                    currentDosage = vaccination.Dosage + 1;
                                    //if he took one or two then check whether the date is 30 days after the currentDosage
                                    if (vaccination.VaccinatedDate.AddDays(30) <= DateTime.Now)
                                    {
                                        readyForVaccination = true;
                                    }
                                    else
                                    {
                                        readyForVaccination = false;
                                    }
                                }
                                else
                                {
                                    currentDosage = vaccination.Dosage + 1;
                                    Console.WriteLine("All the three Vaccination are completed, you cannot be vaccinated now");
                                }
                                // if ues then show All three vaccination completed, you cannot be vaccinated now
                            }
                            else
                            {
                                //if it is another vaccine show You have selected different vaccine
                                Console.WriteLine("You have selected different Vaccine.You can vaccine with Covaccine/Covishield (His first/second dose vaccine type)");
                                break;
                            }
                        }

                    }
                    //if yes allow him to take vaccination
                    if (readyForVaccination && currentDosage <= 3)
                    {
                        wrongVaccine = false;
                        Console.WriteLine("You can take the vaccination");
                        //create vaccination object
                        Vaccination vaccinationTaken = new Vaccination(currentLoggedInUser.RegistrationNumber, vaccineID, currentDosage, DateTime.Now);
                        //add the details to the vaccination list
                        vaccinationList.Add(vaccinationTaken);
                        //deduct the count of Vaccine 
                        vaccine.NoOfDoseAvailable--;
                    }
                    //showing 30 days not completed only for the user not reday for vaccination &doasage && not a new user & not choosen wrong vaccine
                    else if (!readyForVaccination && currentDosage <= 3 && alreadyVaccinated && !wrongVaccine)
                    {
                        Console.WriteLine("30 days not completed from the previous vaccinated date");
                    }
                 
                    if (!alreadyVaccinated)
                    {
                        //if not check the age is above 14
                        //if above 14 allow him to take the vaccine
                        if (currentLoggedInUser.Age > 14)
                        {
                            Console.WriteLine("You can take the vaccine");
                            //update the details in his vaccination history
                            Vaccination vaccinationTaken = new Vaccination(currentLoggedInUser.RegistrationNumber, vaccineID, 1, DateTime.Now);
                            vaccinationList.Add(vaccinationTaken);
                            //deduct the vaccine count
                            vaccine.NoOfDoseAvailable--;
                        }
                        else
                        {
                            Console.WriteLine("Your age should be above 14 to get vaccinated.");
                        }

                    }
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("Vaccine ID invalid");
            }
        }

        //My Vaccination History
        public static void VaccinationHistory()
        {
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("|Vaccination ID|Register Number|Vaccine ID|Dose Number|Vacccinated Date|");
            Console.WriteLine("------------------------------------------------------------------------");
            bool flag = true;
            foreach (Vaccination vaccination in vaccinationList)
            {
                if (vaccination.RegistrationNumber.Equals(currentLoggedInUser.RegistrationNumber))
                {
                    flag = false;
                    Console.WriteLine($"|{vaccination.VaccinationID,-14}|{vaccination.RegistrationNumber,-15}|{vaccination.VaccineID,-10}|{vaccination.Dosage,-11}|{vaccination.VaccinatedDate.ToString("dd/MM/yyyy"),-16}|");
                    Console.WriteLine("------------------------------------------------------------------------");
                }
            }
            if (flag)
            {
                Console.WriteLine("Your are not yet vaccinated");
            }
        }

        //Next due date
        public static void NextDueDate()
        {
            //traversing vaccination history for checking whether the user vaccinated or not
            DateTime dueDate = new DateTime();
            bool flag = true;
            bool vaccinationCompleted = false;
            foreach (Vaccination vaccination in vaccinationList)
            {
                if (vaccination.RegistrationNumber.Equals(currentLoggedInUser.RegistrationNumber))
                {
                    flag = false;
                    //if the user get the third dose or not
                    if (vaccination.Dosage < 3)
                    {
                        //if-vaccinated add 30 days to the last currentDosage date
                        dueDate = vaccination.VaccinatedDate.AddDays(30);
                    }
                    else
                    {
                        vaccinationCompleted = true;
                    }

                }
            }
            if (flag)
            {
                //if-not tell the user you can take vaccine now
                Console.WriteLine("You can take Vaccine now");
            }
            else if (!vaccinationCompleted)
            {
                Console.WriteLine($"Your Next due date for the vaccination is {dueDate.ToString("dd/MM/yyyy")}");
            }
            else
            {
                Console.WriteLine("You have completed all vaccination. Thanks for your participation in the vaccination drive");
            }

        }

        //Get Vaccine Info
        public static void GetVaccineInfo()
        {
            //traverse vaccinelist to get the vaccine details
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("|Vaccine ID|Vaccine Name|NoOfDoseAvailable|");
            Console.WriteLine("-------------------------------------------");
            foreach (Vaccine vaccine in vaccineList)
            {
                Console.WriteLine($"|{vaccine.VaccineID,-10}|{vaccine.VaccineName,-12}|{vaccine.NoOfDoseAvailable,-17}|");
                Console.WriteLine("-------------------------------------------");
            }

        }
        //Adding Default Data
        public static void AddDefaultData()
        {
            Beneficiary beneficiary1 = new Beneficiary("RaviChandran", 21, Gender.Male, "8484484", "Chennai");
            Beneficiary beneficiary2 = new Beneficiary("Baskaran", 22, Gender.Male, "8484747", "Chennai");
            beneficiaryList.AddRange(new List<Beneficiary>() { beneficiary1, beneficiary2 });

            Vaccine vaccine1 = new Vaccine("Covishield", 50);
            Vaccine vaccine2 = new Vaccine("Covaccine", 50);
            vaccineList.AddRange(new List<Vaccine>() { vaccine1, vaccine2 });

            Vaccination vaccination1 = new Vaccination(beneficiary1.RegistrationNumber, vaccine1.VaccineID, 1, new DateTime(2021, 11, 11));
            Vaccination vaccination2 = new Vaccination(beneficiary1.RegistrationNumber, vaccine1.VaccineID, 2, new DateTime(2022, 03, 11));
            Vaccination vaccination3 = new Vaccination(beneficiary2.RegistrationNumber, vaccine2.VaccineID, 1, new DateTime(2022, 04, 04));
            vaccinationList.AddRange(new List<Vaccination>() { vaccination1, vaccination2, vaccination3 });

        }

    }
}