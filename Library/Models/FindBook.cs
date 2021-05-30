using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models {
	public class FindBook {
		public int ID { get; set; }
		public string Tytuł { get; set; }
		public string Imię_Autora { get; set; }
		public string Nazwisko_Autora { get; set; }
		public string Nazwa_Gatunku { get; set; }
		public int Stan { get; set; }
		public int Dostępność { get; set; }
		public string Opis { get; set; }
		public byte[] Okładka { get; set; }
	}
}
