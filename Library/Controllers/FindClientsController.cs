using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers {
	public class FindClientsController : Controller {
		private readonly ILogger<FindClientsController> _logger;
		private readonly BibliotekaContext _db;
		public FindClientsController(ILogger<FindClientsController> logger, BibliotekaContext db) {
			_logger = logger;
			_db = db;
		}

		public IActionResult Index(string data) {
			string sql = $@"SELECT [ID], [Imię_Klienta], [Nazwisko_Klienta], [PESEL], [Adres_zamieszkania], [Numer_telefonu], [Adres_email], [Data_rejestracji] FROM [Klienci]
			WHERE CONCAT([Imię_Klienta], ' ', [Nazwisko_Klienta]) LIKE (('%' + '{data}' + '%') COLLATE SQL_Latin1_General_CP1253_CI_AI)
			ORDER BY [Nazwisko_Klienta] ASC";
			var ClientsViewModel = _db.Klienci.FromSqlRaw(sql);
			return View(ClientsViewModel);
		}
		public IActionResult Create(Klient klient) {
			if(klient.ImięKlienta == null)
				return View();
			else {
				_db.Klienci.Add(klient);
				_db.SaveChanges();
				return RedirectToAction("Index");

			}
		}
		public IActionResult RentIndex(int? id) {
			string sql = $@"SELECT [Wypożyczenia].[ID], [Tytuł], [Imię_Autora], [Nazwisko_Autora], [Imię_Klienta], [Nazwisko_Klienta], [Data_wypożyczenia], [Data_zwrotu]
			FROM Wypożyczenia INNER JOIN [Książki] ON [Wypożyczenia].IDKsiążka = [Książki].[ID]
			INNER JOIN [Autorzy] ON [Książki].[IDAutor] = [Autorzy].[ID]
			INNER JOIN [Klienci] ON [Wypożyczenia].IDKlient = [Klienci].[ID]
			WHERE [Wypożyczenia].IDKlient = {id}";
			var RentViewModel = _db.RentModels.FromSqlRaw(sql);
			return View(RentViewModel);
		}
		public IActionResult Return(int? id) {
			Wypożyczenie wypożyczenie = _db.Wypożyczenia.Find(id);
			Książka książka = _db.Książki.Find(wypożyczenie.Idksiążka);
			Autor autor = _db.Autorzy.Single(a => a.Id == książka.Idautor);
			Klient klient = _db.Klienci.Single(k => k.Id == wypożyczenie.Idklient);
			RentModel rentModel = new RentModel {
				Tytuł = książka.Tytuł,
				Imię_Autora = autor.ImięAutora,
				Nazwisko_Autora = autor.NazwiskoAutora,
				Imię_Klienta = klient.ImięKlienta,
				Nazwisko_Klienta = klient.NazwiskoKlienta,
				Data_wypożyczenia = wypożyczenie.DataWypożyczenia
			};
			return View(rentModel);
		}
		[HttpPost, ActionName("Return")]
		public IActionResult ReturnConfirmed(int? id) {
			Wypożyczenie wypożyczenie = _db.Wypożyczenia.Find(id);
			wypożyczenie.DataZwrotu = DateTime.Today;
			++_db.Książki.Find(wypożyczenie.Idksiążka).Dostępność;
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
