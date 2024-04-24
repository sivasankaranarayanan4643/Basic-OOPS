using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLibrary
{
    public static class Operations
    {

        static UserDetails currentLoggedInUser;
        //Static List
        static List<UserDetails> userList=new List<UserDetails>();
        static List<BookDetails> bookList=new List<BookDetails>();
        static List<BorrowDetails> borrowList=new List<BorrowDetails>();
        
        //MainMenu
        public static void MainMenu()
        {
            /*
                1.	UserRegistration
                2.	UserLogin
                3.	Exit
            */
            Console.WriteLine("****************SYNCFUSION LIBRARY****************");
            string isRunning="yes";
            do
            {
                Console.WriteLine("____________Main Menu___________");
                Console.WriteLine("Select an Option\n1. User Registration\n2. User Login\n3. Exit");
                bool isValid=int.TryParse(Console.ReadLine(),out int mainChoice);
                while(!isValid||mainChoice>3)
                {
                    Console.Write("Please enter a valid option: ");
                    isValid=int.TryParse(Console.ReadLine(),out mainChoice);
                }

                switch(mainChoice)
                {
                    case 1:
                    {
                        Console.WriteLine("************User Registration**************");
                        UserRegistration();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("************User Login****************");
                        UserLogin();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("Application exited Successfully");
                        isRunning="no";
                        break;
                    }
                }
            }while(isRunning=="yes");
        }//Mainmenu ends

        //Registration
        public static void UserRegistration()
        {
            /*
                a.	Username
                b.	Gender (Enum – Select, Male, Female, Transgender)
                c.	Department  
                d.	MobileNumber
                e.	MailID
                f.	WalletBalance
            */
            //Getting properties from the user
            Console.Write("Enter your name: ");
            string name=Console.ReadLine();
            Console.Write("Enter your gender(Male/Female): ");
            bool isGender=Enum.TryParse<Gender>(Console.ReadLine(),true,out Gender gender);
            while(!isGender)
            {
                Console.Write("Please enter a valid gender(Male/Female): ");
                isGender=Enum.TryParse<Gender>(Console.ReadLine(),true,out gender);
            }
            Console.Write("Enter your Department(EEE/ECE/CSE): ");
            bool isDepartment=Enum.TryParse<Department>(Console.ReadLine(),true,out Department department);
            while(!isDepartment)
            {
                Console.Write("Please enter a valid Department(EEE/ECE/CSE): ");
                isDepartment=Enum.TryParse<Department>(Console.ReadLine(),true,out department);
            }
            Console.Write("Enter your mobile number: ");
            string mobileNumber=Console.ReadLine();
            Console.Write("Enter your mail ID: ");
            string mailID=Console.ReadLine();
            Console.Write("Enter the initial amount you want to add in you wallet(in Rupees): ");
            bool isBalance=double.TryParse(Console.ReadLine(),out double walletBalance);
            while(!isBalance)
            {
                Console.Write("Enter a valid amount: ");
                isBalance=double.TryParse(Console.ReadLine(),out walletBalance);
            }
            //Creating object
            UserDetails user=new UserDetails(name,gender,department,mobileNumber,mailID,walletBalance);
            //adding the object to the list
            userList.Add(user);
            //displaying successful
            Console.WriteLine($"User Registration successful. User ID: {user.UserID}");

        }//User registration ends

        //Login
        public static void UserLogin()
        {
            //get the id from the user
            Console.Write("Enter your user ID: ");
            string loginID=Console.ReadLine().ToUpper();
            bool flag=true;
            //check whether id is in the list
            foreach(UserDetails user in userList)
            {
                if(user.UserID.Equals(loginID))
                {
                    //if yes than call the submenu
                    Console.WriteLine("Logged In succesfully");
                    flag=false;
                    currentLoggedInUser=user;
                    SubMenu();
                }
            }
            //if-not show invalid id
            if(flag)
            {
                Console.WriteLine("Invalid ID or UserID not found");
            }
        }//Login ends
        //subMenu
        public static void SubMenu()
        {
            /*
                1.	Borrowbook.
                2.	ShowBorrowedhistory.
                3.	ReturnBooks
                4.	WalletRecharge 
                5.	Exit

            */
            string subMenuRuns="yes";
            do
            {
                Console.WriteLine("_____________Sub Menu____________");
                Console.WriteLine("Select an Option\n1. Borrow Book\n2. Show Borrowed History\n3. Return Books\n4. Wallet Recharge\n5. Exit");
                Console.Write("Enter the Option: ");
                bool isValid=int.TryParse(Console.ReadLine(),out int subChoice);
                while(!isValid||subChoice>5)
                {
                    Console.Write("Enter a valid Option: ");
                    isValid=int.TryParse(Console.ReadLine(),out subChoice);
                }
                switch(subChoice)
                {
                    case 1:
                    {
                        Console.WriteLine("**************Borrow Book***************");
                        BorrowBook();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("***************Borrowed History************");
                        ShowBorrowedhistory();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("**************Return Books**************");
                        ReturnBooks();
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("*************Wallet Recharge**************");
                        WalletRecharge();
                        break;
                    }
                    case 5:
                    {
                        Console.WriteLine("Taking to the Main Menu");
                        subMenuRuns="no";
                        break;
                    }
                }
            }while(subMenuRuns.Equals("yes"));
        }//sub menu ends

        //Borrow Book
        public static void BorrowBook()
        {
            //show available books
            ShowBooksAvailable ();
            //get the book id from the user
            Console.Write("Enter the Book ID you want to borrow: ");
            string bookID=Console.ReadLine().ToUpper();
            //check whether book is available or not
            bool flag=true;
            foreach(BookDetails book in bookList)
            {
                if(bookID.Equals(book.BookID))
                {
                    flag=false;
                    //if present ask the user to enter the count
                    Console.Write("Enter the count you want: ");
                    bool isCount=int.TryParse(Console.ReadLine(),out int count);
                    while(!isCount)
                    {
                        Console.Write("Enter a valid number: ");
                        isCount=int.TryParse(Console.ReadLine(),out count);
                    }
                    //check the available count
                    if(book.BookCount>=count)
                    {
                    //book count available means check whether the uer already borrowed a book maximum of 3 count 
                    int bookCount=BookBorrowedCount(book.BookID);
                    //if 3 count than already borrowed 3 books
                        if(bookCount+count>3)
                        {
                        //if count +required count >3 show You can have maximum of 3 borrowed books. Your already borrowed books count is {BorrowBookCount} and requested count is {Current Requested Count}, which exceeds 3 
                            Console.WriteLine($"You can have maximum of 3 borrowed books. Your already borrowed books count is {bookCount} and requested count is {count}, which exceeds 3");
                        }
                        //else create an borrow object strore them to the borrowList update the book count and show book borrowed successfully
                        else
                        {
                            BorrowDetails borrow=new BorrowDetails(book.BookID,currentLoggedInUser.UserID,DateTime.Now,count,Status.Borrowed,0);
                            borrowList.Add(borrow);
                            book.BookCount-=count;
                            Console.WriteLine("Book borrowed succesfully");
                        }
                    }
                    else
                    {
                    //get the book borrwed date from the borrow list
                        Console.WriteLine("Required count not available");
                        DateTime date=NextAvailable(book.BookID);
                        //add 15 days and show as the next available date
                        Console.WriteLine($"The Book will be available on {date.AddDays(15).ToString("dd/MM/yyyy")}");

                    }

                    break;
                }
            }
            if(flag)
            {
                Console.WriteLine("Invalid Book ID or Book ID not found");
            }
        }//Borrow book ends

        //show borrowed history
        public static void ShowBorrowedhistory()
        {
            //get the borrowed history from the borrowedlist with the same user id
            Console.WriteLine("|Borrow ID|Book ID|User ID|Borrowed Date|Borro2 Book Count|Status|Paid Fine Amount|");
            foreach(BorrowDetails borrow in borrowList)
            {
                if(borrow.UserID.Equals(currentLoggedInUser.UserID))
                {
                    Console.WriteLine($"|{borrow.BorrowID}|{borrow.BookID}|{borrow.UserID}|{borrow.BorrowedDate.ToString("dd/MM/yyyy")}|{borrow.BorrowBookCount}|{borrow.Status}|{borrow.PaidFineAmount}|");
                }
            }
        }//show borrowed history ends

        //return books
        public static void ReturnBooks()
        {
            //show the borrowed book details of the user with return date
            //if the return date exceeds the current date fine his 1/day and the fine for each book
            BorrowedBook();

            //ask the user to enter the borrow id to return
            Console.Write("Enter the borrow id you want to return: ");
            string borrowID=Console.ReadLine().ToUpper();
            bool flag=true;
            foreach(BorrowDetails borrow in borrowList)
            {
                if(borrowID.Equals(borrow.BorrowID)&&borrow.Status==Status.Borrowed)
                {
                    flag=false;
                    //if borrow id is present check the fine amount of the book 
                    double fine=FineCalculation(borrow.BorrowedDate.AddDays(15),borrow.BorrowBookCount);
                    Console.WriteLine($"your total fine amount is {fine}");
                    if(currentLoggedInUser.WalletBalance>=fine)
                    {
                        borrow.Status=Status.Returned;
                        currentLoggedInUser.DeductBalance(fine);
                        borrow.PaidFineAmount+=fine;
                        foreach(BookDetails book in bookList)
                        {
                            if(borrow.BookID==book.BookID)
                            {
                                book.BookCount+=borrow.BorrowBookCount;
                            }
                        }
                        Console.WriteLine("Book returned successfully");
                    }else
                    {
                        //if he had not the balance then ask him to recharge
                        Console.WriteLine("Insufficient Balance.please recharge and return");
                    }
                    //if he had the balance deduct the balance from the user and change the status as returned add the book count to the booklist
                }
            //if he returned before time change the status as returned and add the book to the book count
            }
            if (flag)
            {
                Console.WriteLine("Invalid Borrow ID or borrow ID not present");
            }

        }//return books ends

        //wallet recharge
        public static void WalletRecharge()
        {
            Console.Write("Do you want to recharge the wallet(yes/no): ");
            string userChoice=Console.ReadLine().ToLower();
            if(userChoice.Equals("yes"))
            {
                Console.Write("Enter the amount to recharge(in rupees): ");
                bool isAmount=double.TryParse(Console.ReadLine(),out double amount);
                while(!isAmount)
                {
                    Console.Write("Enter a valid Amount: ");
                    isAmount=double.TryParse(Console.ReadLine(),out amount);
                }
                currentLoggedInUser.WalletRecharge(amount);
                Console.WriteLine($"Your current Wallet Balance: {currentLoggedInUser.WalletBalance}");
            }
        }//wallet recharge ends

        //methods
        //show books available
        public static void ShowBooksAvailable()
        {
            Console.WriteLine("|Book ID|Book Name|Author Name|Book Count|");
            foreach(BookDetails book in bookList)
            {
                Console.WriteLine($"|{book.BookID}|{book.BookName}|{book.AuthorName}|{book.BookCount}|");
            }
        }//show book available ends

        //count of book Borrowed
        public static int BookBorrowedCount(string bookID)
        {
            int count=0;
            foreach(BorrowDetails borrow in borrowList)
            {
                if(currentLoggedInUser.UserID.Equals(borrow.UserID)&&borrow.BookID==bookID&&borrow.Status==Status.Borrowed)
                {
                    count+=borrow.BorrowBookCount;
                }
            }
            return count;
        }
       
        //next available
        public static DateTime NextAvailable(string bookID)
        {
            DateTime date=new DateTime();
            foreach(BorrowDetails borrow in borrowList)
            {
                if(bookID.Equals(borrow.BookID)&&borrow.Status==Status.Borrowed)
                {
                    date=borrow.BorrowedDate;
                    break;
                }
            }
            return date;
        }
        
        //borrwedbook
        public static void BorrowedBook()
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"|{"Borrow ID",-10}|{"Book ID",-10}|{"User ID",-10}|{"Borrowed Date",-10}|{"Borrow Book Count",-10}|{"Status",-10}|{"Return Date",-10}|{"Fine Amount",-10}|{"Paid Fine Amount",-10}|");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
            foreach(BorrowDetails borrow in borrowList)
            {
                if(currentLoggedInUser.UserID.Equals(borrow.UserID)&& borrow.Status==Status.Borrowed)
                {
                    DateTime returnDate=borrow.BorrowedDate.AddDays(15);
                    double fine=FineCalculation(returnDate,borrow.BorrowBookCount);
                    Console.WriteLine($"|{borrow.BorrowID,-10}|{borrow.BookID,-10}|{borrow.UserID,-10}|{borrow.BorrowedDate.ToString("dd/MM/yyyy"),-13}|{borrow.BorrowBookCount,-17}|{borrow.Status,-10}|{returnDate.ToString("dd/MM/yyyy"),-11}|{fine,-11}|{borrow.PaidFineAmount,-16}|");
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                }
            }
        }

        //fine calculation
        public static double FineCalculation(DateTime returnDate,int count)
        {
             TimeSpan noOfDays=DateTime.Now-returnDate;
            double fine=Math.Ceiling(noOfDays.TotalDays)>0? Math.Ceiling(noOfDays.TotalDays)*count:0;
            return fine;
        }
        //Default Data Adding
        public static void DefaultData()
        {
            UserDetails user1=new UserDetails("Ravichandran",Gender.Male,Department.EEE,"9938388333","ravi@gmail.com",100);
            UserDetails user2=new UserDetails("Priyadharshini",Gender.Female,Department.CSE,"9944444455","priya@gmail.com",150);
            userList.AddRange(new List<UserDetails>(){user1,user2});

            BookDetails book1=new BookDetails("C#","Author1",3);
            BookDetails book2=new BookDetails("HTML","Author2",5);
            BookDetails book3=new BookDetails("CSS","Author1",3);
            BookDetails book4=new BookDetails("JS","Author1",3);
            BookDetails book5=new BookDetails("TS","Author2",2);
            bookList.AddRange(new List<BookDetails>(){book1,book2,book3,book4,book5});

            BorrowDetails borrow1=new BorrowDetails(book1.BookID,user1.UserID,new DateTime(2023,09,10),2,Status.Borrowed,0);
            BorrowDetails borrow2=new BorrowDetails(book3.BookID,user1.UserID,new DateTime(2023,09,12),1,Status.Borrowed,0);
            BorrowDetails borrow3=new BorrowDetails(book4.BookID,user1.UserID,new DateTime(2023,09,14),1,Status.Returned,16);
            BorrowDetails borrow4=new BorrowDetails(book2.BookID,user2.UserID,new DateTime(2023,09,11),2,Status.Borrowed,0);
            BorrowDetails borrow5=new BorrowDetails(book5.BookID,user2.UserID,new DateTime(2023,09,09),1,Status.Returned,20);
            borrowList.AddRange(new List<BorrowDetails>(){borrow1,borrow2,borrow3,borrow4,borrow5});
        }
    }
}