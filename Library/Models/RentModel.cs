using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Library.Models {
	public class RentModel {
		public int ID { get; set; }
		public string Tytuł { get; set; }
		[Display(Name = "Imię autora")]
		public string Imię_Autora { get; set; }
		[Display(Name = "Nazwisko autora")]
		public string Nazwisko_Autora { get; set; }
		[Display(Name = "Imię klienta")]
		public string Imię_Klienta { get; set; }
		[Display(Name = "Nazwisko klienta")]
		public string Nazwisko_Klienta { get; set; }
		[Display(Name = "Data wypożyczenia")]
		public DateTime Data_wypożyczenia { get; set; }
		[Display(Name = "Data zwrotu")]
		public DateTime? Data_zwrotu { get; set; }
		[Display(Name = "Data wypożyczenia")]
		public string ShortRentDate {
			get {
				return Data_wypożyczenia.ToString("d");
			}
		}
		[Display(Name = "Data zwrotu")]
		public string ShortReturnDate {
			get {
				return Data_zwrotu == null ? "" : Data_zwrotu.Value.ToString("d");
			}
		}
		[Display(Name = "Autor")]
		public string AuthorNameConcatenation {
			get {
				return Imię_Autora + " " + Nazwisko_Autora;
			}
		}
		[Display(Name = "Klient")]
		public string ClientNameConcatenation {
			get {
				return Imię_Klienta + " " + Nazwisko_Klienta;
			}
		}
	}
}
