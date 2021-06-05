using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Library.Models
{
    public partial class Książka
    {
        public Książka()
        {
            Wypożyczenia = new HashSet<Wypożyczenie>();
        }
        [Required]
        public int Id { get; set; }
        [Required]
        public string Tytuł { get; set; }
        [Required]
        public int Idautor { get; set; }
        [Required]
        public int Idgatunek { get; set; }
        public string Opis { get; set; }
        public byte[] Okładka { get; set; }
        [Required]
        public int Stan { get; set; }
        [Required]
        public int Dostępność { get; set; }

        public virtual Autor IdautorNavigation { get; set; }
        public virtual Gatunek IdgatunekNavigation { get; set; }
        public virtual ICollection<Wypożyczenie> Wypożyczenia { get; set; }
    }
}
