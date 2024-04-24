using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLibrary
{
    //Enum Declaration
    public enum  Gender {Select,Male,Female}
   public enum Department{ECE,EEE,CSE}
    public class UserDetails
    {
        /*
            a.	UserID (Auto Increment – SF3000)
            b.	UserName
            c.	Gender
            d.	Department – (Enum – ECE, EEE, CSE)
            e.	MobileNumber
            f.	MailID
            g.	WalletBalance

        */
        //Field
        //static Field

        private static int s_userID=3000;

        //properties
        public string UserID { get; }

        public string UserName { get; set; }

        public Gender Gender { get; set; }

        public Department Department { get; set; }

        public string MobileNumber { get; set; }

        public string MailID { get; set; }

        public double WalletBalance { get; set; } 
        
        public UserDetails(string userName,Gender gender,Department department,string mobileNumber,string mailID,double walletBalance)
        {
            //Auto Incrementation
            s_userID++;
            
            UserID="SF"+s_userID;
            UserName=userName;
            Gender=gender;
            Department=department;
            MobileNumber=mobileNumber;
            MailID=mailID;
            WalletBalance=walletBalance;
        }
        //methods
        //Wallet Recharge
        public void WalletRecharge(double amount)
        {
            WalletBalance+=amount;
        }
        //Deduct Balance
        public void DeductBalance(double amount)
        {
            WalletBalance-=amount;
        }
        
    }
}