using System;
using System.Collections.Generic;

#nullable disable

namespace Library.Models
{
    public partial class Pracownik
    {
        public int Id { get; set; }
        public string ImięPracownika { get; set; }
        public string NazwiskoPracownika { get; set; }
        public string Login { get; set; }
        public string Hasło { get; set; }
    }
}
