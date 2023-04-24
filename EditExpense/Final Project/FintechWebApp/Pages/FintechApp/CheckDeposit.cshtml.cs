using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Newtonsoft.Json;
using System.Text.Json;
using HW.Interfaces;
using HW.Models;
using HW.Repositories;
using HW.Models;
using static System.Net.WebRequestMethods;
using System.Text;

namespace FintechWebApp.Pages.FintechApp
{

	public class CheckDepositModel : PageModel
	{
		public Fintech fintech = new();
		public string errorMessage = "";
		public string successMessage = "";
		/// <summary>
		/// In the OnGet method, the code retrieves the ID of the account
		/// to be edited from the request query parameters.
		/// </summary>

		public async void OnGet()
		{
			//string id = Request.Query["id"];
			//using (var client = new HttpClient())
			//{
			//	client.BaseAddress = new Uri("http://localhost:5264");

			//	// HTTP GET
			//	//var responseTask = client.GetAsync("/Fintech/" + id);
			//	//responseTask.Wait();

			//	//var result = responseTask.Result;
			//	//if (result.IsSuccessStatusCode)
			//	//{
			//	//	var readTask = await result.Content.ReadAsStringAsync();
			//	//	fintech = JsonConvert.DeserializeObject<Fintech>(readTask);
			//	//}
			//}
		}
		/// <summary>
		/// In the OnPost method, the code updates the properties of the 
		/// Fintech object using values from the request form data. 
		/// </summary>
		/// 

		public async Task<IActionResult> OnPostAsync()
		{
			fintech.Id = int.Parse(Request.Form["id"]);

			if (fintech.Id < 1001)
			{
				errorMessage = "Account Id is wrong";
			}
			else
			{
				double checkAmount = double.Parse(Request.Form["balance"]);

				using (var client = new HttpClient())
				{
					client.BaseAddress = new Uri("http://localhost:5264");

					var requestContent = new StringContent(JsonConvert.SerializeObject(checkAmount), Encoding.UTF8, "application/json");

					var result = await client.PutAsync("/Fintech/DepositChecks/"+fintech.Id+"/"+checkAmount, requestContent);
					string resultContent = await result.Content.ReadAsStringAsync();


					if (!result.IsSuccessStatusCode)
					{
						errorMessage = "Error in Check deposit";
					}
					else
					{
						successMessage = "Successfully Deposited";
						fintech.Balance += checkAmount;
					}
				}

			}
			return RedirectToPage("/MainPage");
		}
	}
}




