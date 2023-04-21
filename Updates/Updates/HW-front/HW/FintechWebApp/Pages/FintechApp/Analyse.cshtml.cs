using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using HW.Models;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using HW.Interfaces;
using HW.Data;
using System.Threading.Tasks;
using System.Net.Http;

namespace FintechWebApp.Pages.FintechApp
{
    public class AnalyseModel : PageModel
    {
  //      /// <summary>
		///// It declares a public DataAnalysis object named fini.
		///// </summary>
		//public FinTechModel fini = new();
  //      /// <summary>
  //      /// It declares a public dictionary named dictionary, which will store the analysis data.
  //      /// </summary>

  //      public Dictionary<string, dynamic> dictionary = new Dictionary<string, dynamic>();

  //      public async Task<IActionResult> OnGetAsync()
  //      {
  //          using (var client = new HttpClient())
  //          {
  //              client.BaseAddress = new Uri("http://localhost:5264");
  //              var response = await client.GetAsync("/Fintech/Analyse");
  //              var json = await response.Content.ReadAsStringAsync();
  //              dictionary = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(json);
  //              return Page();
                
  //          }
  //      }



        //public async Task<IActionResult> OnPostMeanAsync()
        //{
        //    dictionary = await _repository.CalculateMeanAsync();
        //    return Page();
        //}
    }
}
