using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CameliaRasiga_ProiectMedii.Data;
using CameliaRasiga_ProiectMedii.Models;

namespace CameliaRasiga_ProiectMedii.Pages.UtilizatorServicii
{
    public class EditModel : PageModel
    {
        private readonly CameliaRasiga_ProiectMedii.Data.CameliaRasiga_ProiectMediiContext _context;

        public EditModel(CameliaRasiga_ProiectMedii.Data.CameliaRasiga_ProiectMediiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UtilizatorServiciu UtilizatorServiciu { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.UtilizatorServiciu == null)
            {
                return NotFound();
            }

            var utilizatorserviciu =  await _context.UtilizatorServiciu.FirstOrDefaultAsync(m => m.ID == id);
            if (utilizatorserviciu == null)
            {
                return NotFound();
            }
            UtilizatorServiciu = utilizatorserviciu;
           ViewData["ServiciuID"] = new SelectList(_context.Serviciu, "ID", "Denumire");
           ViewData["UtilizatorID"] = new SelectList(_context.Utilizator, "ID", "NumeComplet");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(UtilizatorServiciu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UtilizatorServiciuExists(UtilizatorServiciu.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool UtilizatorServiciuExists(int id)
        {
          return (_context.UtilizatorServiciu?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
