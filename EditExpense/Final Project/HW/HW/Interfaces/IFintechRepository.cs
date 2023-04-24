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

        bool EditExpense(FinTechModel expense);

        bool DeleteExpense(int id);

        //Dictionary<string, dynamic> analyzeBill();

        Dictionary<string, dynamic>  DataAnalysis();
		/// <summary>
		/// Withdrawing money function
		/// </summary>
		/// <param name="id"></param>
		/// <param name="amount"></param>
		/// <returns></returns>
		bool WithdrawAmount(int id, double amount);

		/// <summary>
		/// Depositing Checks
		/// </summary>
		/// <param name="id"></param>
		/// <param name="Check_Amount"></param>
		/// <returns></returns>
		/// 

		bool DepositCheck(int id, double Check_Amount);

		/// <summary>
		/// A1 is account 1 from where amount is debited and account 2 is account where amount needs to be deposited
		/// </summary>
		/// <param name="A1"></param>
		/// <param name="A2"></param>
		/// <returns></returns>
		bool TransferAmount(int A1, int A2, double Amount);

		/// <summary>
		/// Save changes to databse
		/// </summary>
		/// <returns></returns>
		bool Save();
    }
}