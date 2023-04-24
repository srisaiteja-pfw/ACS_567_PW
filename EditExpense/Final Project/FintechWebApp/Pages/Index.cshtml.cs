using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using HW.Interfaces;
using HW.Models;
using HW.Repositories;

namespace FintechWebApp.Pages.FintechApp
{
    public class IndexModel : PageModel
    {
        public List<Fintech> fintech = new();
        /// <summary>
        /// The OnGet method is responsible for getting the data for this property 
        /// from the API using HTTP GET request
        /// </summary>
        public async void OnGet()
        { }
    }
}
