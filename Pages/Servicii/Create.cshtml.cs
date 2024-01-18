using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CameliaRasiga_ProiectMedii.Data;
using CameliaRasiga_ProiectMedii.Models;
using Microsoft.AspNetCore.Authorization;

namespace CameliaRasiga_ProiectMedii.Pages.Servicii
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly CameliaRasiga_ProiectMedii.Data.CameliaRasiga_ProiectMediiContext _context;

        public CreateModel(CameliaRasiga_ProiectMedii.Data.CameliaRasiga_ProiectMediiContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["MedicID"] = new SelectList(_context.Set<Medic>(), "ID", "NumeComplet");
        ViewData["SpecialitateID"] = new SelectList(_context.Set<Specialitate>(), "ID", "Denumire");
            return Page();
        }

        [BindProperty]
        public Serviciu Serviciu { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Serviciu == null || Serviciu == null)
            {
                return Page();
            }

            _context.Serviciu.Add(Serviciu);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
