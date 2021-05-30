using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Library.Controllers {
	public class HomeController : Controller {
		private readonly ILogger<HomeController> _logger;
		private readonly BibliotekaContext _db;

		public HomeController(ILogger<HomeController> logger, BibliotekaContext db) {
			_logger = logger;
			_db = db;
		}

		public IActionResult Index() {
			return View();
		}

		public IActionResult Privacy() {
			return View();
		}

		public IActionResult FindBook() {
			List<FindBook> list;
			string input = "'%'";
			string sql = $@"SELECT [Książki].[ID], [Tytuł], [Imię_Autora], [Nazwisko_Autora], [Nazwa_Gatunku], [Stan], [Dostępność], [Opis], [Okładka] FROM Książki 
	INNER JOIN[Autorzy] ON[Książki].[IDAutor] = [Autorzy].[ID] INNER JOIN[Gatunki] ON[Książki].[IDGatunek] = [Gatunki].[ID]
	WHERE CONCAT([Imię_Autora], ' ', [Nazwisko_Autora]) LIKE(('%' + {input} + '%') COLLATE SQL_Latin1_General_CP1253_CI_AI) OR[Tytuł] LIKE(('%' + {input} + '%') COLLATE SQL_Latin1_General_CP1253_CI_AI)
	ORDER BY[Nazwisko_Autora] ASC";
			list = _db.FindBookModels.FromSqlRaw<FindBook>(sql).ToList();
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error() {
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
