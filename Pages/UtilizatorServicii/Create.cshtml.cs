using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CameliaRasiga_ProiectMedii.Data;
using CameliaRasiga_ProiectMedii.Models;

namespace CameliaRasiga_ProiectMedii.Pages.UtilizatorServicii
{
    public class CreateModel : PageModel
    {
        private readonly CameliaRasiga_ProiectMedii.Data.CameliaRasiga_ProiectMediiContext _context;

        public CreateModel(CameliaRasiga_ProiectMedii.Data.CameliaRasiga_ProiectMediiContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ServiciuID"] = new SelectList(_context.Serviciu, "ID", "Denumire");
        ViewData["UtilizatorID"] = new SelectList(_context.Utilizator, "ID", "NumeComplet");
            return Page();
        }

        [BindProperty]
        public UtilizatorServiciu UtilizatorServiciu { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.UtilizatorServiciu == null || UtilizatorServiciu == null)
            {
                return Page();
            }

            _context.UtilizatorServiciu.Add(UtilizatorServiciu);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
