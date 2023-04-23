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
		public async void OnGet()
		{
			// line retrieves the month parameter from the query string of the request.
			string id = Request.Query["id"];
			using (var client = new HttpClient())
			{
				//These lines create an instance of HttpClient, set the base address
				client.BaseAddress = new Uri("http://localhost:5264");
				//HTTP GET
				var responseTask = client.DeleteAsync("/Fintech/DeleteExpense/" + id);
				responseTask.Wait();

				//If the response was successful, it sets the Month property of the bill object to the month parameter. 
				if (responseTask.Result.IsSuccessStatusCode)
				{
					monthly_expenses.Id = int.Parse(id);

				}

			}
		}
	}
}


	//public async void OnGet()
	//	{
	//		string id = Request.Query["id"];


	//		using (var client = new HttpClient())
	//		{
	//			client.BaseAddress = new Uri("http://localhost:5264");

	//			// HTTP GET
	//			var responseTask = client.GetAsync("/Fintech/GetExpenses" + id);
	//			responseTask.Wait();

	//			var result = responseTask.Result;
	//			if (result.IsSuccessStatusCode)
	//			{
	//				var readTask = await result.Content.ReadAsStringAsync();
	//				monthly_expenses = JsonConvert.DeserializeObject<FinTechModel>(readTask);
	//			}

	//		}
	//	}
	//	/// <summary>
	//	/// The OnPost method is called when the user submits the form to delete the Fintech account object.
	//	/// </summary>
	//	public async Task<IActionResult> OnPostAsync()
	//	{
	//		bool isDeleted = false;
	//		int id = int.Parse(Request.Form["id"]);
	//		using (var client = new HttpClient())
	//		{
	//			client.BaseAddress = new Uri("http://localhost:5264");

	//			var response = await client.DeleteAsync("/Fintech/DeleteExpense");

	//			if (response.IsSuccessStatusCode)
	//			{
	//				isDeleted = true;

	//			}
	//		}
	//		if (isDeleted)
	//		{
	//			successMessage = "Successfully deleted";
	//			Console.WriteLine("successMessage: " + successMessage);
	//		}
	//		else
	//		{
	//			errorMessage = "Error deleting";
	//		}
	//		return RedirectToPage("/ExpenseTracker");
	//	}
	//}




