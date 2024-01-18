using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CameliaRasiga_ProiectMedii.Data;
using CameliaRasiga_ProiectMedii.Models;
using CameliaRasiga_ProiectMedii.Models.ViewModels;

namespace CameliaRasiga_ProiectMedii.Pages.Locatii
{
    public class IndexModel : PageModel
    {
        private readonly CameliaRasiga_ProiectMedii.Data.CameliaRasiga_ProiectMediiContext _context;

        public IndexModel(CameliaRasiga_ProiectMedii.Data.CameliaRasiga_ProiectMediiContext context)
        {
            _context = context;
        }

        public IList<Locatie> Locatie { get; set; } = default!;

        public LocatieIndexData LocatieData { get; set; }
        public int LocatieID { get; set; }
        public int MedicID { get; set; }

        public async Task OnGetAsync(int? id, int? medicID)
        {
            LocatieData = new LocatieIndexData();
            LocatieData.Locatii = await _context.Locatie
                                                    .Include(i => i.Medici)
                                                        .ThenInclude(b => b.Specialitate)
                                                    .OrderBy(i => i.Nume)
                                                    .ToListAsync();

            if (id != null)
            {
                LocatieID = id.Value;
                Locatie locatie = LocatieData.Locatii.Where(i => i.ID == id.Value).Single();
                LocatieData.Medici = locatie.Medici;
            }
        }
    }
}

