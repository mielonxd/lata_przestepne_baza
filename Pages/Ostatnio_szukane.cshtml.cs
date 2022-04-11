using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FizzBuzzWeb.Models;
using FizzBuzzWeb.Data;

namespace FizzBuzzWeb.Pages
{
    public class Ostatnio_szukaneModel : PageModel
    {
        private readonly PeopleContext _context;
        private readonly ILogger<Ostatnio_szukaneModel> _logger;
        public Ostatnio_szukaneModel(ILogger<Ostatnio_szukaneModel> logger, PeopleContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IList<Person> People { get; set; } = null!;
        public void OnGet()
        {
            //People =_context.Person.Take(20).OrderByDescending(p => p.localDate).ToList();
            People = _context.Person.OrderByDescending(x => x.localDate).Take(20).ToList();

        }
    }
}
