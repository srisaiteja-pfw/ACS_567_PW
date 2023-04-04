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
        public class CreateModel : PageModel
        {
            /// <summary>
            ///  A public Fintech object is created
            /// </summary>
            public HW.Models.Fintech fintech = new();
            public string errorMessage = "";
            public string successMessage = "";

            /// <summary>
            /// 
            ///  The OnPost method is defined as an async void method
            /// </summary>

            public async void OnPost()
            {
                //The values from the form are set to the fintech object
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

