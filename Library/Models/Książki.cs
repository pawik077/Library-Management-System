using System;
using System.Collections.Generic;

#nullable disable

namespace Library.Models
{
    public partial class Książki
    {
        public Książki()
        {
            Wypożyczenia = new HashSet<Wypożyczenia>();
        }

        public int Id { get; set; }
        public string Tytuł { get; set; }
        public int Idautor { get; set; }
        public int Idgatunek { get; set; }
        public string Opis { get; set; }
        public byte[] Okładka { get; set; }
        public int Stan { get; set; }
        public int Dostępność { get; set; }

        public virtual Autorzy IdautorNavigation { get; set; }
        public virtual Gatunki IdgatunekNavigation { get; set; }
        public virtual ICollection<Wypożyczenia> Wypożyczenia { get; set; }
    }
}
