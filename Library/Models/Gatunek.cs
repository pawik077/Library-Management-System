using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Library.Models
{
    public partial class Gatunek
    {
        public Gatunek()
        {
            Książki = new HashSet<Książka>();
        }

        [Required]
        public int Id { get; set; }
        [Required]
        public string NazwaGatunku { get; set; }

        public virtual ICollection<Książka> Książki { get; set; }
    }
}
