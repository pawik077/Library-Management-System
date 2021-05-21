using System;
using System.Collections.Generic;

#nullable disable

namespace Library.Models
{
    public partial class Wypożyczenia
    {
        public int Id { get; set; }
        public int Idklient { get; set; }
        public int Idksiążka { get; set; }
        public DateTime DataWypożyczenia { get; set; }
        public DateTime? DataZwrotu { get; set; }

        public virtual Klienci IdklientNavigation { get; set; }
        public virtual Książki IdksiążkaNavigation { get; set; }
    }
}
