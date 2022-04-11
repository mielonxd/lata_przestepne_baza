using FizzBuzzWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using FizzBuzzWeb.Data;

namespace FizzBuzzWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly PeopleContext _context;

        [BindProperty]
        public Person FizzBuzz { get; set; } = null!;

        [BindProperty(SupportsGet = true)]
        public string Name { get; set; } = null!;
        public IndexModel(ILogger<IndexModel> logger, PeopleContext context)
        {
            _logger = logger;
            _context = context;
        }
        

        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                Name = "User";

            }
        }
        public IList<Person> People { get; set; } = null!;
        //  [BindProperty]
        //public Person Person { get; set; } = null!;
        public IActionResult OnPost()
        {
            People = _context.Person.ToList();
            ViewData["check"] = FizzBuzz.check();
            string? data = HttpContext.Session.GetString("Data");
            List<Person> list;
            if (data == null)
            {
                list = new();
            }
            else
            {
                list = JsonConvert.DeserializeObject<List<Person>>(data!)!;
            }
            list.Add(FizzBuzz);
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(list));
            FizzBuzz.localDate = DateTime.Now;
            _context.Person.Add(FizzBuzz);
            _context.SaveChanges();
            return Page();

        }
    }
}