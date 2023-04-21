using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;
using HW.Interfaces;
using HW.Models;
using HW.Repositories;

namespace FintechWebApp.Pages.FintechApp
{
    /// <summary>
    /// The DeleteModel class inherits from the 
    /// PageModel class and contains three public fields: fintech, errorMessage, and successMessage.
    /// </summary>

    public class DeleteModel : PageModel
    {
        public Fintech fintech = new();
        public string errorMessage = "";
        public string successMessage = "";

        /// <summary>
        /// The OnGet method is called when the page is loaded and 
        /// uses the Request.Query property to get the ID of the Fintech Account object to delete.
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
        /// The OnPost method is called when the user submits the form to delete the Fintech account object.
        /// </summary>
        public async void OnPost()
        {
            bool isDeleted = false;
            int id = int.Parse(Request.Form["id"]);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5264");

                var response = await client.DeleteAsync("/Fintech/" + id);

                if (response.IsSuccessStatusCode)
                {
                    isDeleted = true;
                }
            }
            if (isDeleted)
            {
                successMessage = "Successfully deleted";
            }
            else
            {
                errorMessage = "Error deleting";
            }

        }
    }
}
