using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FizzBuzzWeb.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Display(Name = "Imię")]
        [Required, StringLength(100,
        ErrorMessage = "Długość imienia nie może przekraczać {1}.")]
        [Column(TypeName="varchar(100)")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Nazwisko")]
        [MaxLength(100)]
        public string LastName { get; set; } = null!;

        [Display(Name = "Rok")]
        [Required, Range(1899,2022,
        ErrorMessage = "Rok powinien być z zakresu {1} i {2}.")]
        public int Year { get; set; }

        [Display(Name = "Data")]
        public DateTime? localDate { get; set; }

        public string description = null!;
        public string check()
        {
            if (DateTime.IsLeapYear(Year))
            {
                description = " - rok przestępny";
                return FirstName + " " + LastName + " urodził/a się w " + Year + " roku. To był rok przestępny.";
            }
            else
            {
                description = " - rok zwykły";
                return FirstName + " " + LastName + " urodził/a się w " + Year + " roku. To nie był rok przestępny.";
            }
        }
    }
}
