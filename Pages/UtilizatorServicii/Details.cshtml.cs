using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CameliaRasiga_ProiectMedii.Data;
using CameliaRasiga_ProiectMedii.Models;

namespace CameliaRasiga_ProiectMedii.Pages.UtilizatorServicii
{
    public class DetailsModel : PageModel
    {
        private readonly CameliaRasiga_ProiectMedii.Data.CameliaRasiga_ProiectMediiContext _context;

        public DetailsModel(CameliaRasiga_ProiectMedii.Data.CameliaRasiga_ProiectMediiContext context)
        {
            _context = context;
        }

      public UtilizatorServiciu UtilizatorServiciu { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.UtilizatorServiciu == null)
            {
                return NotFound();
            }

            var utilizatorserviciu = await _context.UtilizatorServiciu
                .Include(u => u.Serviciu)
                .Include(u => u.Utilizator)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (utilizatorserviciu == null)
            {
                return NotFound();
            }
            else 
            {
                UtilizatorServiciu = utilizatorserviciu;
            }
            return Page();
        }
    }
}
