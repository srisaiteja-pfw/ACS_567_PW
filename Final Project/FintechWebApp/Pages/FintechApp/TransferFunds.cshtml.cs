using HW.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace FintechWebApp.Pages.FintechApp
{

	public class TransferFundsModel : PageModel
	{
		public Fintech fintech = new();
		public string errorMessage = "";
		public string successMessage = "";
		
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
				double withdrawAmount = double.Parse(Request.Form["balance"]);

				using (var client = new HttpClient())
				{
					client.BaseAddress = new Uri("http://localhost:5264");

					var requestContent = new StringContent(JsonConvert.SerializeObject(withdrawAmount), Encoding.UTF8, "application/json");

					var result = await client.PutAsync("/Fintech/DepositChecks/" + fintech.Id + "/" + withdrawAmount, requestContent);
					string resultContent = await result.Content.ReadAsStringAsync();


					if (!result.IsSuccessStatusCode)
					{
						errorMessage = "Error in Check deposit";
					}
					else
					{
						successMessage = "Successfully Deposited";
						fintech.Balance += withdrawAmount;
					}
				}

			}
			return Page();
		}
	}
}





