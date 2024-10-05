using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class clsDataAccess
    {
        static SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
        public static bool Login(string username,string password)
        {
            bool IsFound = false;
            string GetContact_query = @"Select * From Clients Where UserName = @UserName And Password = @Password;";
            SqlCommand GetContact_Command = new SqlCommand(GetContact_query, connection);

            GetContact_Command.Parameters.AddWithValue("@UserName", username);
            GetContact_Command.Parameters.AddWithValue("@Password", password);

            try
            {
                connection.Open();

                SqlDataReader reader = GetContact_Command.ExecuteReader();
                if (reader.Read()) 
                {
                    IsFound = true;
                }

                reader.Close();
            }
            catch (Exception Error)
            {
                Console.WriteLine(Error.Message);
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool SignUp(string UserName, string Password, decimal Balance) 
        {
            int InsertedID = 0;
            string Insert_query = @"Insert Into Clients Values (@UserName, @Password, @Balance);
                                    Select SCOPE_IDENTITY();";
            SqlCommand Insert_Command = new SqlCommand(Insert_query, connection);

            Insert_Command.Parameters.AddWithValue("@UserName", UserName);
            Insert_Command.Parameters.AddWithValue("@Password", Password);
            Insert_Command.Parameters.AddWithValue("@Balance", Balance);

            try
            {
                connection.Open();

                object result = Insert_Command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString() , out int ID))
                {
                    InsertedID = ID;
                }
            }
            catch (Exception Error)
            {
                Console.WriteLine(Error.Message);
            }
            finally
            {
                connection.Close();
            }
            return (InsertedID >0 );
        }

        public static bool UpdateAccount(int ID , string UserName, string Password , string New_UserName , string New_Password)
        {
            bool AccountUpdated_Successfully = false;

            string UpdateAccount_query = @"update Clients set  UserName = @New_UserName , Password = @New_Password
                                           where  UserName = @UserName and Password = @Password and ID = @ID;";
            SqlCommand UpdateAccount_Command = new SqlCommand(UpdateAccount_query, connection);

            UpdateAccount_Command.Parameters.AddWithValue("@New_UserName", New_UserName);
            UpdateAccount_Command.Parameters.AddWithValue("@New_Password", New_Password);
            UpdateAccount_Command.Parameters.AddWithValue("@UserName", UserName);
            UpdateAccount_Command.Parameters.AddWithValue("@Password", Password);
            UpdateAccount_Command.Parameters.AddWithValue("@ID", ID);
            
            try
            {
                connection.Open();

                int RowsAffected = UpdateAccount_Command.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    AccountUpdated_Successfully = true;
                }

            }
            catch (Exception Error)
            {
                Console.WriteLine(Error.Message);
            }
            finally
            {
                connection.Close();
            }
            return AccountUpdated_Successfully;
        }

        public static bool WithDrawal(string UserName, string Password , decimal Moeny)
        {
            bool WithDrawal_Successed = false;
            string Withdrawal_query = @"update Clients set Balance-= @Money where UserName = @UserName and Password = @Password;";
            SqlCommand Withdrawal_Command = new SqlCommand(Withdrawal_query, connection);

            Withdrawal_Command.Parameters.AddWithValue("@Money", Moeny);
            Withdrawal_Command.Parameters.AddWithValue("@UserName", UserName);
            Withdrawal_Command.Parameters.AddWithValue("@Password", Password);

            try
            {
                connection.Open();

                int RowsAffected = Withdrawal_Command.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    WithDrawal_Successed = true;
                }

            }
            catch (Exception Error)
            {
                Console.WriteLine(Error.Message);
            }
            finally
            {
                connection.Close();
            }
            return WithDrawal_Successed;
        }

        public static bool Deposit(string UserName, string Password, decimal Moeny)
        {
            bool Deposit_Successed = false;
            string Deposit_query = @"update Clients set Balance+= @Money where UserName = @UserName and Password = @Password;";
            SqlCommand Deposit_Command = new SqlCommand(Deposit_query, connection);

            Deposit_Command.Parameters.AddWithValue("@Money", Moeny);
            Deposit_Command.Parameters.AddWithValue("@UserName", UserName);
            Deposit_Command.Parameters.AddWithValue("@Password", Password);

            try
            {
                connection.Open();

                int RowsAffected = Deposit_Command.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    Deposit_Successed = true;
                }

            }
            catch (Exception Error)
            {
                Console.WriteLine(Error.Message);
            }
            finally
            {
                connection.Close();
            }
            return Deposit_Successed;
        }

        public static bool AccountStatement(ref int ID,ref string username,ref string password,ref decimal Balance)
        {
            bool AccountStatement_Successed = false;

            string GetContact_query = @"Select * From Clients Where UserName = @UserName And Password = @Password;";
            SqlCommand GetContact_Command = new SqlCommand(GetContact_query, connection);

            GetContact_Command.Parameters.AddWithValue("@UserName", username);
            GetContact_Command.Parameters.AddWithValue("@Password", password);

            try
            {
                connection.Open();

                SqlDataReader reader = GetContact_Command.ExecuteReader();
                if (reader.Read())
                {
                    AccountStatement_Successed = true;
                    ID = (int)reader["ID"];
                    username = (string)reader["UserName"];
                    password = (string)reader["Password"];
                    Balance = (decimal)reader["Balance"];
                }

                reader.Close();
            }
            catch (Exception Error)
            {
                Console.WriteLine(Error.Message);
            }
            finally
            {
                connection.Close();
            }
            return AccountStatement_Successed;
        }

        public static bool Transfer
            (string UserName_Sender ,string Password_sender ,string UserName_Receiver ,
             string Password_Receiver ,decimal Money)
        {
            bool Transfer_Successed = false;
            string Transfer_query = @"update Clients set Balance-= @Money where UserName = @UserName_Sender and Password = @Password_sender ;
                                      update Clients set Balance+= @Money where UserName = @UserName_Receiver and Password = @Password_Receiver;";

            SqlCommand Transfer_Command = new SqlCommand(Transfer_query, connection);

            Transfer_Command.Parameters.AddWithValue("@Money", Money);
            Transfer_Command.Parameters.AddWithValue("@UserName_Sender", UserName_Sender);
            Transfer_Command.Parameters.AddWithValue("@Password_sender", Password_sender);
            Transfer_Command.Parameters.AddWithValue("@UserName_Receiver", UserName_Receiver);
            Transfer_Command.Parameters.AddWithValue("@Password_Receiver", Password_Receiver);

            try
            {
                connection.Open();
                int RowsAffected =  Transfer_Command.ExecuteNonQuery();

                if (RowsAffected > 0)
                {
                    Transfer_Successed = true;
                }

            }
            catch (Exception Error)
            {
                Console.WriteLine(Error.Message);
            }
            finally
            {
                connection.Close();
            }
            return Transfer_Successed;
        }

    }
}
