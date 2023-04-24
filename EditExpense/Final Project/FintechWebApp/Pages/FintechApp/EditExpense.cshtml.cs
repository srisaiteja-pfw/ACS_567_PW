using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using HW.Interfaces;
using HW.Models;
using HW.Repositories;
using System.Text.Json;

namespace FintechWebApp.Pages.FintechApp
{
    public class EditExpenseModel : PageModel
	{
		public FinTechModel monthly_expenses = new();
		public string errorMessage = "";
		public string successMessage = "";
		/// <summary>
		/// In the OnGet method, the code retrieves the ID of the account
		/// to be edited from the request query parameters.
		/// </summary>

		public async void OnGet()
		{
			// line retrieves the month parameter from the query string of the request.
			string id = Request.Query["id"];
			using (var client = new HttpClient())
			{
				//These lines create an instance of HttpClient, set the base address
				client.BaseAddress = new Uri("http://localhost:5264");
				//HTTP GET
				var responseTask = client.GetAsync("/Fintech/EditExpense/" + id);
				responseTask.Wait();

				//If the response was successful, it sets the Month property of the bill object to the month parameter. 
				if (responseTask.Result.IsSuccessStatusCode)
				{
					monthly_expenses.Id = int.Parse(id);

				}

			}
		}
		/// <summary>
		/// In the OnPost method, the code updates the properties of the 
		/// Fintech object using values from the request form data. 
		/// </summary>

		public async Task<IActionResult> OnPostAsync()

		{
			//The values from the form are set to the fintech object
			monthly_expenses.Account_number = int.Parse(Request.Form["accountnumber"]);
			monthly_expenses.Date = Request.Form["date"];
			monthly_expenses.Category = Request.Form["category"];
			monthly_expenses.Expense = int.Parse(Request.Form["expense"]);

			if (monthly_expenses.Expense == 0)
			{
				errorMessage = "Add an Expense";
			}
			else
			{
				var opt = new JsonSerializerOptions() { WriteIndented = true };
				string json = System.Text.Json.JsonSerializer.Serialize<FinTechModel>(monthly_expenses, opt);

				using (var client = new HttpClient())
				{
					client.BaseAddress = new Uri("http://localhost:5264");

					var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

					var result = await client.PutAsync("Fintech/EditExpense", content);
					string resultContent = await result.Content.ReadAsStringAsync();
					Console.WriteLine(resultContent);
					// If the server returns an error, an error message is displayed
					if (!result.IsSuccessStatusCode)
					{
						errorMessage = "Error updating";
					}
					else
					{
						// If the server returns a success message, a success message is displayed
						successMessage = "Successfully updated";
					}

				}
			}
			return RedirectToPage("/Pages/ExpenseTracker");
		}
	}

}
