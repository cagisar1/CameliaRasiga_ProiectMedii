using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CameliaRasiga_ProiectMedii.Data;
using CameliaRasiga_ProiectMedii.Models;
using Microsoft.AspNetCore.Authorization;

namespace CameliaRasiga_ProiectMedii.Pages.Specialitati
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly CameliaRasiga_ProiectMedii.Data.CameliaRasiga_ProiectMediiContext _context;

        public DeleteModel(CameliaRasiga_ProiectMedii.Data.CameliaRasiga_ProiectMediiContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Specialitate == null)
            {
                return NotFound();
            }
            var specialitate = await _context.Specialitate.FindAsync(id);

            if (specialitate != null)
            {
                Specialitate = specialitate;
                _context.Specialitate.Remove(Specialitate);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
