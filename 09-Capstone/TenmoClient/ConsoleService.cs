using System;
using System.Collections.Generic;
using TenmoClient.Data;

namespace TenmoClient
{
    public class ConsoleService
    {
        /// <summary>
        /// Prompts for transfer ID to view, approve, or reject
        /// </summary>
        /// <param name="action">String to print in prompt. Expected values are "Approve" or "Reject" or "View"</param>
        /// <returns>ID of transfers to view, approve, or reject</returns>
        public int PromptForTransferID(string action)
        {
            Console.WriteLine("");
            Console.Write("Please enter transfer ID to " + action + " (0 to cancel): ");
            if (!int.TryParse(Console.ReadLine(), out int auctionId))
            {
                Console.WriteLine("Invalid input. Only input a number.");
                return 0;
            }
            else
            {
                return auctionId;
            }
        }

        public LoginUser PromptForLogin()
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();
            string password = GetPasswordFromConsole("Password: ");

            LoginUser loginUser = new LoginUser
            {
                Username = username,
                Password = password
            };
            return loginUser;
        }

        private string GetPasswordFromConsole(string displayMessage)
        {
            string pass = "";
            Console.Write(displayMessage);
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                // Backspace Should Not Work
                if (!char.IsControl(key.KeyChar))
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Remove(pass.Length - 1);
                        Console.Write("\b \b");
                    }
                }
            }
            // Stops Receving Keys Once Enter is Pressed
            while (key.Key != ConsoleKey.Enter);
            Console.WriteLine("");
            return pass;
        }

        //public NewTransfer PromptForTransfer(TransferType transferType)
        //{
        //    Console.WriteLine($"Enter the User ID you are sending to);
        //}


        public void PrintAccount(Account account)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Current Balance");
            Console.WriteLine("--------------------------------------------");
            //Console.WriteLine(" Id: " + account.AccountId);
            //Console.WriteLine(" User Id: " + account.UserId);
            Console.WriteLine(" Balance: " + account.Balance);

        }
        public void PrintUser(User user)
        {


            Console.WriteLine("--------------------------------------------");
            Console.WriteLine(" User Id: " + user.UserId);
            Console.WriteLine(" Username: " + user.Username);
            Console.WriteLine("--------------------------------------------");

        }
        public void PrintTransfer(Transfer transfer)
        {

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine(" Sending User: " + transfer.AccountFrom);
            Console.WriteLine(" Receiving User: " + transfer.AccountTo);
            Console.WriteLine(" Amount: " + transfer.Amount);
            Console.WriteLine(" Transfer ID: " + transfer.TransferId);
            Console.WriteLine("--------------------------------------------");
        }

        public void ShowTransferDetails(Transfer transfer)
        {
            string transferType = "Send";
            string transferStatus = "Approved"; //IM SO SORRY

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine(" Id: " + transfer.TransferId);
            Console.WriteLine(" From: " + transfer.AccountFrom);
            Console.WriteLine(" To: " + transfer.AccountTo);
            Console.WriteLine(" Type: " + transferType);
            Console.WriteLine(" Status: " + transferStatus);
            Console.WriteLine(" Amount: " + transfer.Amount);
            Console.WriteLine("--------------------------------------------");

        }
    }
}
