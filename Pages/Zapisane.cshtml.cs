using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FizzBuzzWeb.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


namespace FizzBuzzWeb.Pages
{
    public class ZapisaneModel : PageModel
    {
        public List<FizzBuzz>? FizzBuzzList { get; set; }
        public void OnGet()
        {
            var data = HttpContext.Session.GetString("Data");
            if (data != null)
            {
                FizzBuzzList = JsonConvert.DeserializeObject<List<FizzBuzz>>(data);
            }
        }
    }
  
}
