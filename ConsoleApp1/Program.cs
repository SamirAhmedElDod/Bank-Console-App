using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
namespace PresentationLayer
{
    internal class Program
    {
        public static bool TestLogin(string UserName , string Password)
        {
            bool Login_Successfully = false;
            if (clsBankSystem.BS_Login(ref UserName, ref Password) )
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n\nAccount {UserName} Login Successfully ");
                Login_Successfully = true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nLogin Faild ");
            }
            return Login_Successfully;
        }

        public static bool TestSignUp(string UserName , string PassWord , decimal Balance)
        {
            bool SignUp_Successfully = false;
            if (clsBankSystem.BS_SignUp(UserName, PassWord, Balance))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                SignUp_Successfully = true;
                Console.WriteLine("\n\nAccount Created Successfully ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nAccount Created Failed ");
            }
            return SignUp_Successfully;
        }

        public static void TestWithdrawal(string UserName, string PassWord, decimal Money)
        {
            if(clsBankSystem.BS_Withdrawal(UserName, PassWord, Money))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\nWithDraw Successfully Done");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nWithDraw Failed ");

            }
            Console.ResetColor();
        }
        public static void TestWithDeposit(string UserName, string PassWord, decimal Money)
        {
            if (clsBankSystem.BS_Deposit(UserName, PassWord, Money))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\nDeposit Successfully Done");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nDeposit Failed ");

            }

            Console.ResetColor();
        }

        public static void TestAccountStatement(string UserName, string Password)
        {
            clsBankSystem ClientAccount = clsBankSystem.BS_AccountStatement(ref UserName, ref Password);
            if (ClientAccount != null)
            {
                Console.WriteLine($"\n\nYour Account ID : {ClientAccount.ID}");
                Console.WriteLine($"Account User Name : {ClientAccount.UserName}");
                Console.WriteLine($"Account Password : {ClientAccount.Password}");
                Console.WriteLine($"Account Availble Balance : {ClientAccount.Balance}");
            }
        }

        public static void TestTranfer(string UserName_Sender, string Password_sender, string UserName_Receiver,
            string Password_Receiver, decimal Money)
        {
            if (clsBankSystem.BS_Transfer(UserName_Sender, Password_sender , UserName_Receiver , Password_Receiver , Money))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n\nTransfer Done Successfully From {UserName_Sender} To {UserName_Receiver}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine($"\n\nTransfer Faild From {UserName_Sender} To {UserName_Receiver}");
            }
            Console.ResetColor();
        }

        public static bool TestUpdateAccount(int ID, string UserName, string Password, string New_UserName, string New_Password)
        {
            bool AccountUpdated = false;
            if (clsBankSystem.BS_UpdateAccount(ID, UserName, Password, New_UserName, New_Password))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\nAccount Updated Successfully");
                AccountUpdated =  true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                AccountUpdated = false;
                Console.WriteLine("\n\nAccount Failed to Update");
            }
            Console.ResetColor();
            return AccountUpdated;
        }

        public static void MainMenu()
        {
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("\t\tWelcome To Bank System");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("1. Login");
            Console.WriteLine();
            Console.WriteLine("2. SignUp");
            Console.WriteLine();
            Console.WriteLine("3. Exit");
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("\nChoose Number From 1 To 3\n");
            Console.Write("Your Answer Is :  ");


        }
        public static void LoginMenu()
        {
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("\t\tWelcome To Login Page");
            Console.WriteLine("-------------------------------------------------------");
        }
        public static void UpdateAccountMenu()
        {
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("\t\tWelcome To Update Account Page");
            Console.WriteLine("-------------------------------------------------------");
        }
        // this Menu Only Show In Transfer  -- Start 
        public static void SecondAccountLoginMenu()
        {
            Console.WriteLine("\n----------------------------------");
            Console.WriteLine("   Receiver Account Login Page");
            Console.WriteLine("----------------------------------");

        }
        public static void Warningmenu()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("\t\tTake Care ");
        }
        // this Menu Only Show In Transfer -- End
        public static void SignUpMenu()
        {
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("\t\tWelcome To SignUp Page");
            Console.WriteLine("-------------------------------------------------------");
        }
        public static void AccountStatementMenu()
        {
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("\t\tWelcome To Account Statement Page");
            Console.WriteLine("-------------------------------------------------------");
        }
        public static void WithDrawalMenu()
        {
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("\t\tWelcome To Withdraw Page");
            Console.WriteLine("-------------------------------------------------------");
        }
        public static void DepositMenu()
        {
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("\t\tWelcome To Deposit Page");
            Console.WriteLine("-------------------------------------------------------");
        }
        public static void TransferMenu()
        {
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("\t\tWelcome To Transfer Page");
            Console.WriteLine("-------------------------------------------------------");
        }
        public static void MoneyFunctionsMenu()
        {
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("\t\tWelcome To Bank System");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("1. Withdraw");
            Console.WriteLine();
            Console.WriteLine("2. Deposit");
            Console.WriteLine();
            Console.WriteLine("3. Transfer");
            Console.WriteLine(); 
            Console.WriteLine("4. Account Statement");
            Console.WriteLine();
            Console.WriteLine("5. Update Account");
            Console.WriteLine();
            Console.WriteLine("6. Exit");
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("\nChoose Number From 1 To 6\n");
            Console.Write("Your Answer Is :  ");
        }
        public static bool MainMenuFunction(int Answer , ref string UserName , ref string Password)
        {
            bool Success = false;
           
            switch (Answer)
            {
                case 1:
                    Console.Clear();
                    LoginMenu();
                    Console.WriteLine("Please Enter Your Account User Name");
                    UserName = Console.ReadLine();
                    Console.WriteLine("Please Enter Your Account Password");
                    Password = Console.ReadLine();
                    if (TestLogin(UserName, Password))
                    {
                        Success = true;
                        Console.ResetColor();
                    } else
                    {
                        Success = false;
                        Console.WriteLine("\n\n\aLogin Again Or SignUp If You Don't Have Account");
                        Console.ReadKey();
                    }

                    break;
                case 2:
                    Console.Clear();
                    SignUpMenu();
                    Console.WriteLine("Please Enter Your Account User Name -- [Full Name]");
                    UserName = Console.ReadLine();
                    Console.WriteLine("Please Enter Your Account Password -- [4 Characters Only Contains -> (Numbers , Letters) ]");
                    Password = Console.ReadLine();
                    Console.WriteLine("Please Enter Your Account Balance -- [Maximum Lenth 10 Nums]");
                    decimal Balance = Convert.ToDecimal(Console.ReadLine());
                    if (TestSignUp(UserName, Password, Balance)) 
                    {
                        Success = true;
                        Console.ResetColor();
                    } else
                    {
                         Success = false;
                        Console.WriteLine("\n\n\aPlease Follow The Rules In The Brackets.");
                        Console.WriteLine("\nAnd Try Again.");
                        Console.ReadKey();
                    }
                    break;                   
                case 3:
                    Console.WriteLine("Bank System Closed , Thank You ");
                    break;
                default:
                    Console.WriteLine("\n\nWrong Choice , You Can Only Choose From 1 To 4");
                    break;

            }
            return Success;
        }
        public static void MoneyFunctions(int MoneyAnswer, ref string UserName, ref string Password , ref decimal Money)
        {
            switch (MoneyAnswer)
            {
                case 1:
                    Console.Clear();
                    WithDrawalMenu();
                    Console.WriteLine("Please Enter The Amount You Want To Withdraw.");
                    Money = Convert.ToDecimal(Console.ReadLine());
                    TestWithdrawal(UserName, Password, Money);

                    Console.WriteLine("\nPress Any Key To Back Continue");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    DepositMenu();
                    Console.WriteLine("Please Enter The Amount You Want To Deposit.");
                    Money = Convert.ToDecimal(Console.ReadLine());
                    TestWithDeposit(UserName, Password, Money);

                    Console.WriteLine("\nPress Any Key To Continue To Bank System");
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    TransferMenu();
                    SecondAccountLoginMenu();
                    Console.WriteLine("Please Enter Receiver Account User Name");
                    string Receiver_UserName = Console.ReadLine();
                    Console.WriteLine("Please Enter Receiver Account Password");
                    string Receiver_Password = Console.ReadLine();
                    Console.WriteLine("Please Enter The Amount You Want To Transfer.");
                    Money = Convert.ToDecimal(Console.ReadLine());
                    Warningmenu();
                    Console.WriteLine($"Account [{UserName}] Will Send [{Money}] To Account [{Receiver_UserName}]");
                    Console.WriteLine("Are You Sure ?");
                    Console.WriteLine("Please Enter Y For Yes Or N For No");
                    char YesOrNO = Console.ReadLine().ToUpper()[0];
                    Console.ResetColor();

                    if (YesOrNO == 'Y')
                    {
                        TestTranfer(UserName, Password, Receiver_UserName, Receiver_Password, Money);
                    }
                    else
                    {
                        Console.WriteLine("Transfer Canceld ...");
                        Console.WriteLine("You Will Go Back To Bank Main Menu");
                    }

                    Console.WriteLine("\nPress Any Key To Back Continue");
                    Console.ReadKey();

                    break;
                case 4:
                    Console.Clear();
                    AccountStatementMenu();
                    TestAccountStatement(UserName, Password);
                    Console.WriteLine("\n-------------------------------------------------------");

                    Console.WriteLine("\nPress Any Key To Back Continue");
                    Console.ReadKey();
                    break;
                case 5:
                    Console.Clear();
                    UpdateAccountMenu();
                    Console.WriteLine("Please Enter Your Account ID");
                    int ID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please Enter Your Account New User Name");
                    string New_UserName = Console.ReadLine();
                    Console.WriteLine("Please Enter Your Account New Password");
                    string New_Password = Console.ReadLine();
                    if (TestUpdateAccount(ID, UserName, Password, New_UserName, New_Password))
                    {
                        UserName = New_UserName;
                        Password = New_Password;
                    }
                    Console.WriteLine("\nPress Any Key To Back Continue");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("\n\nWrong Choice , You Can Only Choose From 1 To 5");
                    Console.ReadKey();

                    break;
            }
        }
        public static void MainAppStart(int Answer , int MoneyAnswer , ref string UserName, ref string Password , ref decimal Money)
        {
            while (Answer != 4)
            {
                Console.Clear();

                // Start Main Menu -------------------------------------------------
                MainMenu();
                Answer = Convert.ToInt32(Console.ReadLine());
                if (Answer == 4)
                {
                    return;
                }

                // Start Using ( Login Or Signup ) -------------------------------------------------
                if (!MainMenuFunction(Answer, ref UserName, ref Password))
                {
                    return;
                }


                Console.WriteLine("\nPress Any Key To Continue To Bank System");
                Console.ReadKey();

                // Start Account Statement  -------------------------------------------------
                Console.Clear();

                while (MoneyAnswer != 6)
                {
                    Console.Clear();
                    MoneyFunctionsMenu();
                    MoneyAnswer = Convert.ToInt32(Console.ReadLine());

                    if (MoneyAnswer == 6)
                    {
                        return;
                    }

                    MoneyFunctions(MoneyAnswer, ref UserName, ref Password, ref Money);
                }

            }
        }
        static void Main(string[] args)
        {

            string UserName = "";
            string Password = "";
            decimal Money = 0;
            int Answer= 0 , MoneyAnswer = 0 ;

            MainAppStart(Answer , MoneyAnswer ,ref  UserName , ref Password ,ref Money);
            
        }
    }
}
