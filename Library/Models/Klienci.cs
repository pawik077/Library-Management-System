using System;
using System.Collections.Generic;

#nullable disable

namespace Library.Models
{
    public partial class Klienci
    {
        public Klienci()
        {
            Wypożyczenia = new HashSet<Wypożyczenia>();
        }

        public int Id { get; set; }
        public string ImięKlienta { get; set; }
        public string NazwiskoKlienta { get; set; }
        public string Pesel { get; set; }
        public string AdresZamieszkania { get; set; }
        public string NumerTelefonu { get; set; }
        public string AdresEmail { get; set; }
        public DateTime DataRejestracji { get; set; }

        public virtual ICollection<Wypożyczenia> Wypożyczenia { get; set; }
    }
}
