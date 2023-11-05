using System;

namespace MiniProject3// Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Bank!");

            Console.Write("Enter your account number: ");
            string accountNumber = Console.ReadLine();

            Console.Write("Enter your initial account balance: ");
            if (double.TryParse(Console.ReadLine(), out double initialBalance)) // to check if the user is putting a real number - if not the system will tell him to put a valid option
            {
                BankAccount userAccount = new BankAccount(accountNumber, initialBalance);

                int choice;
                do
                {
                    Console.WriteLine("Menu:");
                    Console.WriteLine("1. Check your current balance");
                    Console.WriteLine("2. Deposit money");
                    Console.WriteLine("3. Withdraw money");
                    Console.WriteLine("4. Quit");

                    Console.Write("Enter your choice: ");
                    if (int.TryParse(Console.ReadLine(), out choice)) // to check if the user is putting a real choice, which is a number between 1, 2 and 3 
                    {
                        switch (choice)
                        {
                            case 1:
                                userAccount.DisplayBalance();
                                break;
                            case 2:
                                Console.Write("Enter the amount to deposit: ");
                                if (double.TryParse(Console.ReadLine(), out double depositAmount))
                                {
                                    userAccount.Deposit(depositAmount);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input for deposit amount.");
                                }
                                break;
                            case 3:
                                Console.Write("Enter the amount to withdraw: ");
                                if (double.TryParse(Console.ReadLine(), out double withdrawAmount))
                                {
                                    userAccount.Withdraw(withdrawAmount);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input for withdraw amount");
                                }
                                break;
                            case 4:
                                Console.WriteLine("Thank you for using our banking services!");
                                break;
                            default:
                                Console.WriteLine("Invalid choice. Please try again.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please enter a valid number.");
                    }

                } while (choice != 4); // do this while the choice is a number between 1, 2 and 3 
            }
            else
            {
                Console.WriteLine("Invalid input for initial balance. Please enter a valid number.");
            }
        }
    }


    //class for bank account 
    class BankAccount
    {
        public string accountNumber { get; set; }
        public double balance { get; set; }

        public BankAccount(string accountNumber, double initialBalance)
        {
            this.accountNumber = accountNumber;
            this.balance = initialBalance;
        }

        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine($"Deposited {amount:C}. New balance: {balance:C}");
            }
            else
            {
                Console.WriteLine("Invalid deposit amount.");
            }
        }

        public void Withdraw(double amount)
        {
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"Withdrawn {amount:C}. New balance: {balance:C}");
            }
            else
            {
                Console.WriteLine("Invalid withdrawal amount or insufficient funds.");
            }
        }

        public void DisplayBalance()
        {
            Console.WriteLine($"Account Number: {accountNumber}");
            Console.WriteLine($"Balance: {balance:C}");
        }
    }
}

