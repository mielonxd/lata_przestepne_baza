using FizzBuzzWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


namespace FizzBuzzWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public FizzBuzz FizzBuzz { get; set; } = null!;

        [BindProperty(SupportsGet = true)]
        public string Name { get; set; } = null!;
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            
        }

        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                Name = "User";

            }
            
        }
        public IActionResult OnPost()
        {
           
            if (!ModelState.IsValid)
            {
                ViewData["check"] = FizzBuzz.check();
                string? data = HttpContext.Session.GetString("Data");
                List<FizzBuzz> list;
                if (data == null)
                {
                    list  = new();
                }
                else
                {
                    list = JsonConvert.DeserializeObject<List<FizzBuzz>>(data!)!;
                }
                list.Add(FizzBuzz);
                HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(list));
                
                return Page();
            }
            return Page();
        }
    }
}