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
    public class AddExpenseModel : PageModel
    {
        /// <summary>
        ///  A public Fintech object is created
        /// </summary>
        public HW.Models.FinTechModel monthly_expenses = new();
        public string errorMessage = "";
        public string successMessage = "";

        /// <summary>
        /// 
        ///  The OnPost method is defined as an async void method
        /// </summary>

        public async void OnPost()
        {
            //The values from the form are set to the fintech object
            monthly_expenses.Id = int.Parse(Request.Form["id"]);
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

                    var result = await client.PostAsync("Fintech", content);
                    string resultContent = await result.Content.ReadAsStringAsync();
                    Console.WriteLine(resultContent);
                    // If the server returns an error, an error message is displayed
                    if (!result.IsSuccessStatusCode)
                    {
                        errorMessage = "Error adding";
                    }
                    else
                    {
                        // If the server returns a success message, a success message is displayed
                        successMessage = "Successfully added";
                    }

                }
            }
        }
    }
}


