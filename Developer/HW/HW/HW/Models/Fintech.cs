
using System;
using System.Runtime.CompilerServices;

namespace HW.Models
{
    public class Fintech
    {
        /// <summary>
		/// Added getters and setters for all the input var
		/// </summary>
        /// 
        public int Id { get; set; }

        public string Firstname { get; set; } = String.Empty;

        public string Lastname { get; set; } = String.Empty;

        public string Address { get; set; } = String.Empty;

        public string Email { get; set; } = String.Empty;

        public string Contact { get; set; } = String.Empty;

        public int Age { get; set; }

        public string SSN { get; set; } = String.Empty;

        public double Balance { get; set; }

    }

    public class FinTechModel

    {
        public int Account_number { get; set; }
        public int Id { get; set; }
        public string Date { get; set; }
        public string Category { get; set; }
        public int Expense { get; set; }

        public FinTechModel(int account_number = 10001, string date = "", string category = "", int expense = 0)
        {
            Account_number = account_number;
            Date = date;
            Expense = expense;
            Category = category;

        }//This is the constructor for the "Bills" class. It takes in two parameter "month" and "expense"
    }



}


