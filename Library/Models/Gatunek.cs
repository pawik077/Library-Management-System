using System;
using System.Collections.Generic;

#nullable disable

namespace Library.Models
{
    public partial class Gatunek
    {
        public Gatunek()
        {
            Książki = new HashSet<Książka>();
        }

        public int Id { get; set; }
        public string NazwaGatunku { get; set; }

        public virtual ICollection<Książka> Książki { get; set; }
    }
}
