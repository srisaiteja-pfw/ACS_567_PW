
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
}
