using HW.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace FintechWebApp.Pages.FintechApp
{

	public class WithdrawMoneyModel : PageModel
	{
		public Fintech fintech = new();
		public string errorMessage = "";
		public string successMessage = "";
/// <summary>
/// WE give the amount to be withdrawn
/// </summary>
/// <returns></returns>
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

					var result = await client.PutAsync("/Fintech/WithdrawAmount/" + fintech.Id + "/" + withdrawAmount, requestContent);
					string resultContent = await result.Content.ReadAsStringAsync();


					if (!result.IsSuccessStatusCode)
					{
						errorMessage = "Error in Withdrawing Money";
					}
					else
					{
						successMessage = "Successfully Withdrawn";
						fintech.Balance -= withdrawAmount;
					}
				}

			}
			return RedirectToPage("/MainPage");
		}
	}
}





