using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Library.Models
{
    public partial class Pracownik
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string ImięPracownika { get; set; }
        [Required]
        public string NazwiskoPracownika { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Hasło { get; set; }
    }
}
