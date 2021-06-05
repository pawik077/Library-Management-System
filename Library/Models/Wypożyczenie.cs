using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Library.Models
{
    public partial class Wypożyczenie
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int Idklient { get; set; }
        [Required]
        public int Idksiążka { get; set; }
        [Required]
        public DateTime DataWypożyczenia { get; set; }
        public DateTime? DataZwrotu { get; set; }

        public virtual Klient IdklientNavigation { get; set; }
        public virtual Książka IdksiążkaNavigation { get; set; }
    }
}
