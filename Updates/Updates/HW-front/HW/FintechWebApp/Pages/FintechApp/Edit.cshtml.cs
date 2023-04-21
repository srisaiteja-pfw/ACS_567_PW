using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Newtonsoft.Json;
using System.Text.Json;
using HW.Interfaces;
using HW.Models;
using HW.Repositories;
using HW.Models;
using static System.Net.WebRequestMethods;

namespace FintechWebApp.Pages.FintechApp
{

    public class EditModel : PageModel
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
            string id = Request.Query["id"];
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5264");

                // HTTP GET
                var responseTask = client.GetAsync("/Fintech/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsStringAsync();
                    fintech = JsonConvert.DeserializeObject<Fintech>(readTask);
                }
            }
        }
        /// <summary>
        /// In the OnPost method, the code updates the properties of the 
        /// Fintech object using values from the request form data. 
        /// </summary>
        public async void OnPost()
        {
            fintech.Id = int.Parse(Request.Form["id"]);
            fintech.Firstname = Request.Form["firstname"];
            fintech.Lastname = Request.Form["lastname"];
            fintech.Address = Request.Form["address"];
            fintech.Email = Request.Form["email"];
            fintech.Contact = Request.Form["contact"];
            fintech.Age = int.Parse(Request.Form["age"]);
            fintech.SSN = Request.Form["ssn"];
            fintech.Balance = double.Parse(Request.Form["balance"]);

            if (fintech.Firstname.Length == 0)
            {
                errorMessage = "Firstname is required";
            }
            else
            {
                var opt = new JsonSerializerOptions() { WriteIndented = true };
                string json = System.Text.Json.JsonSerializer.Serialize<Fintech>(fintech, opt);

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5264");

                    var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var result = await client.PutAsync("/Fintech", content);
                    string resultContent = await result.Content.ReadAsStringAsync();
                    Console.WriteLine(resultContent);

                    if (!result.IsSuccessStatusCode)
                    {
                        errorMessage = "Error editing";
                    }
                    else
                    {
                        successMessage = "Successfully editing";
                    }

                }

            }
        }
    }
}
