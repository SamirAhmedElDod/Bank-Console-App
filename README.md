# Bank Account Management System

## Introduction

This project is a bank account management system that relies on an SQL Server database. It allows users to perform various financial operations such as deposits, withdrawals, and transfers between accounts. The project is designed to store account data

## Features

- **Create New Account**: Stores new account data (username, password, balance) in the database.
- **Login**: Verifies user login information by comparing it with stored database records.
- **Deposit Money**: Updates the account balance in the database when a deposit is made.
- **Withdraw Money**: Allows users to withdraw money, provided they have sufficient funds in the database.
- **Transfer Between Accounts**: Enables transferring money between different accounts, with real-time balance updates in the database.
- **Check Balance**: Retrieves the current account balance from the database and displays it to the user.
- **Update Account**: Allows users to update their account information, such as username or password, and the changes are saved in the database.

  
## Database Details (SQL Server)

- **Main Accounts Table**:
  - `AccountID`: Account number (Primary Key).
  - `UserName`: Username.
  - `Password`: Password (Encryption is recommended for future improvements).
  - `Balance`: Current balance.
 
 ## Program Workflow

1. **Account Registration**:
   - When creating a new account, the system stores the account data in the accounts table in the database.
   - It checks for duplicate usernames before account creation.

2. **Login**:
   - The system verifies the entered username and password using an SQL query that checks for a matching record in the accounts table.

3. **Deposits and Withdrawals**:
   - When depositing or withdrawing money, the program performs an `UPDATE` query to adjust the account balance in the accounts table.
   - Each transaction is recorded in the transactions table for tracking and reporting purposes.

4. **Money Transfers**:
   - The system verifies the existence of both accounts involved in the transfer and updates the balance of both accounts.
   - Each transfer is recorded as a separate transaction in the transactions table.

5. **Balance Inquiry**:
   - The program retrieves the user's current balance by executing an SQL query that fetches the balance from the accounts table based on the `AccountID`.
     
6. **Account Update**:
    - Users can update their account information, such as username or password. The system performs an `UPDATE` query to save the changes in the `accounts` table.

## Architecture

This project follows the **3-Tier Architecture**:
- **Data Layer**: Handles database interactions for storing and retrieving account data.
- **Business Layer**: Implements the core banking logic, including account operations and validation.
- **Presentation Layer**: Provides a console-based interface for user interaction.

    
## Additional Details

- **Programming Language**: C# 
- **Database**: Microsoft SQL Server.
- **User Interface**: Console Application

## App Images
![Main Project Image](https://raw.githubusercontent.com/SamirAhmedElDod/Bank-Console-App/master/Assets%20For%20Readme/Bank.png)

___

![Main Project Image](https://raw.githubusercontent.com/SamirAhmedElDod/Bank-Console-App/master/Assets%20For%20Readme/bank2.png)
___

![Main Project Image](https://raw.githubusercontent.com/SamirAhmedElDod/Bank-Console-App/master/Assets%20For%20Readme/Bank5.png)

___

![Main Project Image](https://raw.githubusercontent.com/SamirAhmedElDod/Bank-Console-App/master/Assets%20For%20Readme/Bank3.png)

___

![Main Project Image](https://raw.githubusercontent.com/SamirAhmedElDod/Bank-Console-App/master/Assets%20For%20Readme/Bank4.png)



