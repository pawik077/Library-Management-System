using System;
using System.Collections.Generic;

#nullable disable

namespace Library.Models
{
    public partial class Gatunki
    {
        public Gatunki()
        {
            Książkis = new HashSet<Książki>();
        }

        public int Id { get; set; }
        public string NazwaGatunku { get; set; }

        public virtual ICollection<Książki> Książkis { get; set; }
    }
}
