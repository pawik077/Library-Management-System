using System;
using System.Collections.Generic;

#nullable disable

namespace Library.Models
{
    public partial class Wypożyczenie
    {
        public int Id { get; set; }
        public int Idklient { get; set; }
        public int Idksiążka { get; set; }
        public DateTime DataWypożyczenia { get; set; }
        public DateTime? DataZwrotu { get; set; }

        public virtual Klient IdklientNavigation { get; set; }
        public virtual Książka IdksiążkaNavigation { get; set; }
    }
}
