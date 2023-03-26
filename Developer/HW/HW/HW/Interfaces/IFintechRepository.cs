using System;
using HW.Models;
namespace HW.Interfaces
{
    public interface IFintechRepository
    {
        ICollection<Fintech> getItems();

        Fintech GetItem(int id);

        bool AccountExists(int id);

        bool AddAccount(Fintech account);

        bool EditAccount(Fintech account);

        bool DeleteAccount(int  id);

        bool AddExpense(FinTechModel expense);

        /// <summary>
        /// returns a dictionary of string and dynamic objects with the analysis results.
        /// </summary>
        /// <returns></returns>
        Dictionary<string, dynamic> analyzeBill();
        bool Save();
    }
}