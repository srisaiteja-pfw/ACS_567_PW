using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using HW.Interfaces;
using HW.Models;
using HW.Repositories;
using System.Text.Json;

namespace FintechWebApp.Pages.FintechApp
{

	/// <summary>
	/// // The public class is defined as a PageModel
	/// </summary>
	public class DeleteExpenseModel : PageModel
	{
		/// <summary>
		///  A public Fintech object is created
		/// </summary>
		public FinTechModel monthly_expenses = new();
		public string errorMessage = "";
		public string successMessage = "";

		/// <summary>
		/// This method is called when the page is loaded with an HTTP GET request. 
		/// </summary>
		public async Task<IActionResult> OnGetAsync()
		{
			string id = Request.Query["id"];

			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri("http://localhost:5264");
				var responseTask = client.DeleteAsync("/Fintech/DeleteExpense/" + id);
				responseTask.Wait();

				if (responseTask.Result.IsSuccessStatusCode)
				{
					monthly_expenses.Id = int.Parse(id);
				}
			}

			// Redirect to the homepage
			return RedirectToPage("/ExpenseTracker");
		}

	}
}



