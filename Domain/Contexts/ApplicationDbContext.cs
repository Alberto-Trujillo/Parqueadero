using Microsoft.EntityFrameworkCore;
using Parqueadero.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Domain.Enums.Disponible;
using static Domain.Enums.TipoVehiculo;
using static Parqueadero.Entities.clsParqueadero;

namespace Parqueadero.Contexts
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<PicoPlaca> PicoPlacas { get; set; }
        public DbSet<Entities.clsParqueadero> Parqueaderos { get; set; }
        public DbSet<Cobro> Cobros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Picos y placas diarios.
            var vPicoPlacas = new List<PicoPlaca>()
            {
                new PicoPlaca(){Id = 1, Dia = DayOfWeek.Monday, Numero = 0},
                new PicoPlaca(){Id = 2, Dia = DayOfWeek.Monday, Numero = 1},
                new PicoPlaca(){Id = 3, Dia = DayOfWeek.Tuesday, Numero = 2},
                new PicoPlaca(){Id = 4, Dia = DayOfWeek.Tuesday, Numero = 3},
                new PicoPlaca(){Id = 5, Dia = DayOfWeek.Wednesday, Numero = 4},
                new PicoPlaca(){Id = 6, Dia = DayOfWeek.Wednesday, Numero = 5},
                new PicoPlaca(){Id = 7, Dia = DayOfWeek.Thursday, Numero = 6},
                new PicoPlaca(){Id = 8, Dia = DayOfWeek.Thursday, Numero = 7},
                new PicoPlaca(){Id = 9, Dia = DayOfWeek.Friday, Numero = 8},
                new PicoPlaca(){Id = 10, Dia = DayOfWeek.Friday, Numero = 9},
                new PicoPlaca(){Id = 11, Dia = DayOfWeek.Saturday, Numero = 0},
                new PicoPlaca(){Id = 12, Dia = DayOfWeek.Saturday, Numero = 1},
                new PicoPlaca(){Id = 13, Dia = DayOfWeek.Saturday, Numero = 2},
                new PicoPlaca(){Id = 14, Dia = DayOfWeek.Saturday, Numero = 3},
                new PicoPlaca(){Id = 15, Dia = DayOfWeek.Saturday, Numero = 4},
                new PicoPlaca(){Id = 16, Dia = DayOfWeek.Sunday, Numero = 5},
                new PicoPlaca(){Id = 17, Dia = DayOfWeek.Sunday, Numero = 6},
                new PicoPlaca(){Id = 18, Dia = DayOfWeek.Sunday, Numero = 7},
                new PicoPlaca(){Id = 19, Dia = DayOfWeek.Sunday, Numero = 8},
                new PicoPlaca(){Id = 20, Dia = DayOfWeek.Sunday, Numero = 9}
            };

            //Parqueaderos totales.
            var vParqueaderos = new List<Entities.clsParqueadero>();
            for (int vIntCount = 1; vIntCount <= 20; vIntCount++)
            {
                vParqueaderos.Add(
                    new clsParqueadero() { Id = vIntCount, TipoVehiculo = EnumTipoVehiculo.Carro, Disponible = EnumParqueaderoDisponible.Si });
            }

            for (int vIntCount = 21; vIntCount <= 30; vIntCount++)
            {
                vParqueaderos.Add(
                    new clsParqueadero() { Id = vIntCount, TipoVehiculo = EnumTipoVehiculo.Moto, Disponible = EnumParqueaderoDisponible.Si });
            }

            modelBuilder.Entity<clsParqueadero>().HasData(vParqueaderos);
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<PicoPlaca>().HasData(vPicoPlacas);
            base.OnModelCreating(modelBuilder);
        }
    }
}
