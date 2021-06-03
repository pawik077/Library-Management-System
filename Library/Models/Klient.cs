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
        public string Pesel { get; set; }
        [Required]
        public string AdresZamieszkania { get; set; }
        public string NumerTelefonu { get; set; }
        public string AdresEmail { get; set; }
        [Required]
        public DateTime DataRejestracji { get; set; }

        public virtual ICollection<Wypożyczenie> Wypożyczenia { get; set; }
    }
}
