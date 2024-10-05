using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
namespace BusinessLayer
{
    public class clsBankSystem
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }


        // Parameterized Constructor --> We Will Return It With Values
        clsBankSystem(int ID ,  string UserName, string Password, decimal Balance)
        {
            this.ID = ID;
            this.UserName = UserName;
            this.Password = Password;
            this.Balance = Balance;
        }

        public static bool BS_Login(ref string UserName , ref string Password)
        {
            bool UserLogin = false;

            if (clsDataAccess.Login(UserName, Password))
            {
                UserLogin = true;
            }
            return UserLogin;
        }

        public static bool BS_SignUp(string Username , string Password , decimal Balance)
        {
            bool SignUp_Successed = false;
            if(clsDataAccess.SignUp(Username ,Password , Balance))
            {
                SignUp_Successed = true;
            }
            return SignUp_Successed;
        }

        public static bool BS_Withdrawal(string Username, string Password , decimal Moeny)
        {
            bool WithDrawal_Successed = false;
            if(clsDataAccess.WithDrawal(Username ,Password , Moeny))
            {
                WithDrawal_Successed = true;
            }
            return WithDrawal_Successed;
        }
        public static bool BS_Deposit(string Username, string Password, decimal Moeny)
        {
            bool Deposit_Successed = false;
            if (clsDataAccess.Deposit(Username, Password, Moeny))
            {
                Deposit_Successed = true;
            }
            return Deposit_Successed;
        }

        public static clsBankSystem BS_AccountStatement(ref string UserName, ref string Password)
        {
            int ID = 0;
            decimal Balance = 0;
            if (clsDataAccess.AccountStatement(ref ID , ref UserName , ref Password , ref Balance))
            {
                return new clsBankSystem(ID, UserName, Password, Balance);
            }
            else
            {
                return null;
            }

        }

        public static bool BS_Transfer(string UserName_Sender, string Password_sender,  string UserName_Receiver,
             string Password_Receiver,  decimal Money)
        {
            bool Transfer_Successed = false;
            if(clsDataAccess.Transfer(UserName_Sender, Password_sender , UserName_Receiver, Password_Receiver , Money))
            {
                Transfer_Successed = true;
            }
            return Transfer_Successed;
        }

        public static bool BS_UpdateAccount(int ID, string UserName, string Password, string New_UserName, string New_Password)
        {
            bool Update_Successed = false;
            if (clsDataAccess.UpdateAccount(ID , UserName , Password , New_UserName , New_Password))
            {
                Update_Successed = true;
            }
            return Update_Successed;
        }
    }
}
