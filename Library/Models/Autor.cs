using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Library.Models
{
    public partial class Autor
    {
        public Autor()
        {
            Książki = new HashSet<Książka>();
        }

        [Required]
        public int Id { get; set; }
        public string ImięAutora { get; set; }
        [Required]
        public string NazwiskoAutora { get; set; }

        public virtual ICollection<Książka> Książki { get; set; }
    }
}
