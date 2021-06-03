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
	}
}
