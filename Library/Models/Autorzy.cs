using System;
using System.Collections.Generic;

#nullable disable

namespace Library.Models
{
    public partial class Autorzy
    {
        public Autorzy()
        {
            Książkis = new HashSet<Książki>();
        }

        public int Id { get; set; }
        public string ImięAutora { get; set; }
        public string NazwiskoAutora { get; set; }

        public virtual ICollection<Książki> Książkis { get; set; }
    }
}
