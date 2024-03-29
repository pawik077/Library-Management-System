﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Library.Models {
	public class FindBook {
		[Required]
		public int ID { get; set; }
		[Required]
		public string Tytuł { get; set; }
		[Display(Name = "Imię autora")]
		public string Imię_Autora { get; set; }
		[Required, Display(Name = "Nazwisko autora")]
		public string Nazwisko_Autora { get; set; }
		[Required, Display(Name = "Gatunek")]
		public string Nazwa_Gatunku { get; set; }
		[Required]
		public int Stan { get; set; }
		[Required]
		public int Dostępność { get; set; }
		public string Opis { get; set; }
		public byte[] Okładka { get; set; }
		[Display(Name = "Autor")]
		public string NameConcatenation {
			get {
				return Imię_Autora + " " + Nazwisko_Autora;
			}
		}
	}
}
