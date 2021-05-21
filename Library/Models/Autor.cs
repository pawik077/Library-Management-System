using System;
using System.Collections.Generic;

#nullable disable

namespace Library.Models
{
    public partial class Autor
    {
        public Autor()
        {
            Książki = new HashSet<Książka>();
        }

        public int Id { get; set; }
        public string ImięAutora { get; set; }
        public string NazwiskoAutora { get; set; }

        public virtual ICollection<Książka> Książki { get; set; }
    }
}
