
using Microsoft.AspNetCore.Mvc;
using System;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using HW.Interfaces;
using HW.Models;
using HW.Data;
using Microsoft.Extensions.Configuration;
using MySqlConnector;


namespace HW.Repositories
{
    /// <summary>
	/// instead of performing the operations directly,
	/// it uses an instance of the FintechRepository interface to perform the operations(read,delete,edit)
	/// </summary>
    public class FintechRepository : IFintechRepository
    {
        private DataContext _context;

        public FintechRepository(DataContext context)
        {
            _context = context;
        }

        /// <summary>
		/// The getItems method reads all the contents of a text file 
		/// </summary>
		/// <returns>returns it in the response.</returns>
        public ICollection<Fintech> getItems()
        {
            return _context.Fintech.ToList();
        }
        /// <summary>
        /// The GetItem method reads all the contents of a text file 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>returns response based on the id</returns>
        public Fintech GetItem(int id)
        {
            return _context.Fintech.Where(account => account.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// The FintechExists method checks if account exists or not 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns true if account exists</returns>
        public bool AccountExists(int id)
        {
            return _context.Fintech.Any(account => account.Id == id);
        }

        /// <summary>
		/// The addItem method adds to the response
		/// </summary>
		/// <param name="account"></param>
		/// <returns>returns true if successfully added</returns>
        public bool AddAccount(Fintech account)
        {
            _context.Add(account);
            return Save();
        }

        /// <summary>
		/// The editItem method updated the content based on id with specified content
		/// </summary>
		/// <param name="account"></param>
		/// <returns>returns true if updated successfully</returns>
        /// <summary>
        public bool EditAccount(Fintech account)
        {
            _context.Update(account);
            return Save();

        }
        /// <summary>
		/// The deleteItem method deletes request based on the specified id
		/// </summary>
		/// <param name="account"></param>
		/// <returns>returns item deleted and null if not found </returns>
       

        public bool DeleteAccount(int id)
        {
            var items = _context.Fintech.Where(account => account.Id == id);
            foreach (var account in items)
            {
                _context.Remove(account);
            }

            return Save();
        }
        /// <summary>
        /// Data Analysis method to calculate min,max and average of the amount
        /// </summary>
        /// <returns>Returns min, max,average of the amount </returns>
        //public DataAnalysis DataAnalysis()
        //{
        //    //System.Diagnostics.Debug.WriteLine("Context:"+_context);

        //    var result = new List<double>();
        //    foreach (MonthlyBill i in _context.MonthlyBill)
        //    {
        //        result.Add(i.Amount);
        //        //System.Diagnostics.Debug.WriteLine("Monthly bill" + i);
        //        //if (i.Amount >= max)
        //        //{
        //        //    bill = i;
        //        //    max = i.Amount;
        //        //}
        //    }

        //    DataAnalysis dataAnalysis = new DataAnalysis();

        //    dataAnalysis.min = result.Min();
        //    dataAnalysis.max = result.Max();
        //    dataAnalysis.average = result.Average();

        //    return dataAnalysis;
        //}

        /// <summary>
        /// Save changes to database
        /// </summary>
        /// <returns>Store in database</returns>
        public bool Save()
        {
            int saved = _context.SaveChanges();
            return saved == 1;

        }


    }

}
