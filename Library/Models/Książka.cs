using System;
using System.Collections.Generic;

#nullable disable

namespace Library.Models
{
    public partial class Książka
    {
        public Książka()
        {
            Wypożyczenia = new HashSet<Wypożyczenie>();
        }

        public int Id { get; set; }
        public string Tytuł { get; set; }
        public int Idautor { get; set; }
        public int Idgatunek { get; set; }
        public string Opis { get; set; }
        public byte[] Okładka { get; set; }
        public int Stan { get; set; }
        public int Dostępność { get; set; }

        public virtual Autor IdautorNavigation { get; set; }
        public virtual Gatunek IdgatunekNavigation { get; set; }
        public virtual ICollection<Wypożyczenie> Wypożyczenia { get; set; }
    }
}
