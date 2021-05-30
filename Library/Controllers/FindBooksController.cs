using Library.Models;
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

		public IActionResult Index() {
			string input = "'%'";
			string sql = @$"SELECT [Książki].[ID], [Tytuł], [Imię_Autora], [Nazwisko_Autora], [Nazwa_Gatunku], [Stan], [Dostępność], [Opis], [Okładka] FROM Książki 
			INNER JOIN[Autorzy] ON[Książki].[IDAutor] = [Autorzy].[ID] INNER JOIN[Gatunki] ON[Książki].[IDGatunek] = [Gatunki].[ID]
			WHERE CONCAT([Imię_Autora], ' ', [Nazwisko_Autora]) LIKE(('%' + {input} + '%') COLLATE SQL_Latin1_General_CP1253_CI_AI) OR[Tytuł] LIKE(('%' + {input} + '%') COLLATE SQL_Latin1_General_CP1253_CI_AI)
			ORDER BY[Nazwisko_Autora] ASC";
			var BooksViewModel = _db.FindBookModels.FromSqlRaw<FindBook>(sql);
			return View(BooksViewModel);
		}
	}
}
