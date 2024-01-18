using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CameliaRasiga_ProiectMedii.Data;
using CameliaRasiga_ProiectMedii.Models;

namespace CameliaRasiga_ProiectMedii.Pages.Specialitati
{
    public class DetailsModel : PageModel
    {
        private readonly CameliaRasiga_ProiectMedii.Data.CameliaRasiga_ProiectMediiContext _context;

        public DetailsModel(CameliaRasiga_ProiectMedii.Data.CameliaRasiga_ProiectMediiContext context)
        {
            _context = context;
        }

      public Specialitate Specialitate { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Specialitate == null)
            {
                return NotFound();
            }

            var specialitate = await _context.Specialitate.FirstOrDefaultAsync(m => m.ID == id);
            if (specialitate == null)
            {
                return NotFound();
            }
            else 
            {
                Specialitate = specialitate;
            }
            return Page();
        }
    }
}
