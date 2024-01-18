using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CameliaRasiga_ProiectMedii.Data;
using CameliaRasiga_ProiectMedii.Models;

namespace CameliaRasiga_ProiectMedii.Pages.Utilizatori
{
    public class IndexModel : PageModel
    {
        private readonly CameliaRasiga_ProiectMedii.Data.CameliaRasiga_ProiectMediiContext _context;

        public IndexModel(CameliaRasiga_ProiectMedii.Data.CameliaRasiga_ProiectMediiContext context)
        {
            _context = context;
        }

        public IList<Utilizator> Utilizator { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Utilizator != null)
            {
                Utilizator = await _context.Utilizator.ToListAsync();
            }
        }
    }
}
