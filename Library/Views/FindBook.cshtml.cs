using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Library.Models;

namespace Library.Views.Home
{
    public class FindBookModel : PageModel
    {
        private readonly Library.Models.BibliotekaContext _context;

        public FindBookModel(Library.Models.BibliotekaContext context)
        {
            _context = context;
        }

        public IList<FindBook> FindBook { get;set; }

        public async Task OnGetAsync()
        {
            FindBook = await _context.FindBookModels.ToListAsync();
        }
    }
}
