﻿using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers {
	public class FindBooksController : Controller {
		private readonly ILogger<FindBooksController> _logger;
		private readonly BibliotekaContext _db;
		public FindBooksController(ILogger<FindBooksController> logger, BibliotekaContext db) {
			_logger = logger;
			_db = db;
		}

		public IActionResult Index(string data) {
			string sql = @$"SELECT [Książki].[ID], [Tytuł], [Imię_Autora], [Nazwisko_Autora], [Nazwa_Gatunku], [Stan], [Dostępność], [Opis], [Okładka] FROM Książki 
			INNER JOIN[Autorzy] ON[Książki].[IDAutor] = [Autorzy].[ID] INNER JOIN[Gatunki] ON[Książki].[IDGatunek] = [Gatunki].[ID]
			WHERE CONCAT([Imię_Autora], ' ', [Nazwisko_Autora]) LIKE(('%' + '{data}' + '%') COLLATE SQL_Latin1_General_CP1253_CI_AI) OR[Tytuł] LIKE(('%' + '{data}' + '%') COLLATE SQL_Latin1_General_CP1253_CI_AI)
			ORDER BY[Nazwisko_Autora] ASC";
			var BooksViewModel = _db.FindBookModels.FromSqlRaw<FindBook>(sql);
			return View(BooksViewModel);
		}
		public IActionResult Create(FindBook książka) {
			if(książka.Tytuł == null)
				return View();
			else {
				int? IDAutor, IDGatunek;
				if((IDAutor = _db.Autorzy.SingleOrDefault(a => a.ImięAutora == książka.Imię_Autora && a.NazwiskoAutora == książka.Nazwisko_Autora)?.Id) == null) {
					_db.Autorzy.Add(new Autor { ImięAutora = książka.Imię_Autora, NazwiskoAutora = książka.Nazwisko_Autora });
					_db.SaveChanges();
					IDAutor = _db.Autorzy.SingleOrDefault(a => a.ImięAutora == książka.Imię_Autora && a.NazwiskoAutora == książka.Nazwisko_Autora)?.Id;
				}
				if((IDGatunek = _db.Gatunki.SingleOrDefault(g => g.NazwaGatunku == książka.Nazwa_Gatunku)?.Id) == null) {
					_db.Gatunki.Add(new Gatunek { NazwaGatunku = książka.Nazwa_Gatunku });
					_db.SaveChanges();
					IDGatunek = _db.Gatunki.SingleOrDefault(g => g.NazwaGatunku == książka.Nazwa_Gatunku)?.Id;
				}
				_db.Książki.Add(new Książka {
					Tytuł = książka.Tytuł,
					Idautor = IDAutor.Value,
					Idgatunek = IDGatunek.Value,
					Opis = książka.Opis,
					Okładka = książka.Okładka,
					Stan = książka.Stan,
					Dostępność = książka.Stan
				});
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
		}
	}
}
