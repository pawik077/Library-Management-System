using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace Library.Models
{
    public partial class Klient
    {
        public Klient()
        {
            Wypożyczenia = new HashSet<Wypożyczenie>();
        }
        [Required]
        public int Id { get; set; }
        [Required]
        public string ImięKlienta { get; set; }
        [Required]
        public string NazwiskoKlienta { get; set; }
        [Display(Name = "PESEL")]
        public string Pesel { get; set; }
        [Required, Display(Name = "Adres zamieszkania")]
        public string AdresZamieszkania { get; set; }
        [Display(Name = "Numer telefonu")]
        public string NumerTelefonu { get; set; }
        [Display(Name = "Adres e-mail")]
        public string AdresEmail { get; set; }
        [Required]
        public DateTime DataRejestracji { get; set; }

        public virtual ICollection<Wypożyczenie> Wypożyczenia { get; set; }
        [Display(Name = "Data rejestracji")]
        public string ShortDate {
            get {
                return DataRejestracji.ToString("d");
			}
		}
        [Display(Name = "Imię i nazwisko")]
        public string NameConcatenation {
            get {
                return ImięKlienta + " " + NazwiskoKlienta;
			}
		}
    }
}
