using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace FizzBuzzWeb.Models
{
    public class FizzBuzz
    {
        [Display(Name = "Imię")]
        [Required, StringLength(100,
        ErrorMessage = "Długość imienia nie może przekraczać {1}.")]
        public string Name { get; set; } = null!;

        [Display(Name = "Rok")]
        [Required, Range(1899,2022,
        ErrorMessage = "Rok powinien być z zakresu {1} i {2}.")]
        public int Year { get; set; }

        public string description = null!;
        public string check()
        {
            if (DateTime.IsLeapYear(Year))
            {
                description = " - rok przestępny";
                return Name + " urodził/a się w " + Year + " roku. To był rok przestępny.";
            }
            else
            {
                description = " - rok zwykły";
                return Name + " urodził/a się w " + Year + " roku. To nie był rok przestępny.";
            }
        }
    }
}
