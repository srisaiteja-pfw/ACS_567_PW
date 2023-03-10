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

        bool DeleteAccount(Fintech account);

        //DataAnalysis DataAnalysis();
        bool Save();
    }
}