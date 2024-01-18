using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CameliaRasiga_ProiectMedii.Models;

namespace CameliaRasiga_ProiectMedii.Data
{
    public class CameliaRasiga_ProiectMediiContext : DbContext
    {
        public CameliaRasiga_ProiectMediiContext (DbContextOptions<CameliaRasiga_ProiectMediiContext> options)
            : base(options)
        {
        }

        public DbSet<CameliaRasiga_ProiectMedii.Models.Locatie> Locatie { get; set; } = default!;

        public DbSet<CameliaRasiga_ProiectMedii.Models.Medic>? Medic { get; set; }

        public DbSet<CameliaRasiga_ProiectMedii.Models.Serviciu>? Serviciu { get; set; }

        public DbSet<CameliaRasiga_ProiectMedii.Models.Specialitate>? Specialitate { get; set; }

        public DbSet<CameliaRasiga_ProiectMedii.Models.Utilizator>? Utilizator { get; set; }

        public DbSet<CameliaRasiga_ProiectMedii.Models.UtilizatorServiciu>? UtilizatorServiciu { get; set; }
    }
}
