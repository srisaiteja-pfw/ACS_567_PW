using System;
using HW.Models;
namespace HW.Interfaces
{
    public interface IFintechRepository
    {
        ICollection<Fintech> getItems();

        Fintech GetItem(int id);

        bool AccountExists(int id);

        string CustomerService();

        CustomerService GetCustomerServiceById(int id);
        bool CreateCustomerService(CustomerService customerservice);
    
        bool AddAccount(Fintech account);

        bool EditAccount(Fintech account);

        bool DeleteAccount(int  id);

        ICollection<FinTechModel> getAllExpenses();

        FinTechModel GetExpense(int id);

        bool AddExpense(FinTechModel expense);

        bool UpdateExpense(FinTechModel expense);

        bool DeleteExpense(int id);

        Dictionary<string, dynamic> analyzeBill();

        //DataAnalysis DataAnalysis();
        bool Save();
    }
}