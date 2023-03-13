using System;
using System.Configuration;
using System.Data.Common;
using MySql.Data.MySqlClient;



    public class BankAccount
    {
        public int AccountNumber { get; set; }
        public string Name { get; set; }
        public decimal TotalBalance { get; set; }
        public decimal WithdrawAmount { get; set; }
       // public decimal RemainingBalance { get; set; }
    }

