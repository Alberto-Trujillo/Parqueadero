using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Parqueadero.Contexts;
using Parqueadero.Entities;
using Parqueadero.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Parqueadero.Entities.clsParqueadero;
using static Domain.Enums.TipoVehiculo;
using static Domain.Enums.Disponible;

namespace Parqueadero.Services
{
    public class ParqueaderoService : IParqueadero
    {
        private readonly ApplicationDbContext context;
        public ParqueaderoService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<ActionResult<IList<clsParqueadero>>> GetParqueaderos()
        {
            try
            {
                return await context.Parqueaderos.ToListAsync();
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<ActionResult<IList<clsParqueadero>>> GetParqueaderosDisponibles()
        {
            try
            {
                var vParqueadero = await context.Parqueaderos.Where(x => x.Disponible == EnumParqueaderoDisponible.Si).ToListAsync();
                if (vParqueadero == null)
                {
                    return new NotFoundResult();
                }
                return vParqueadero;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<ActionResult<IList<clsParqueadero>>> GetParqueaderosDisponiblesByTypeVehicle(EnumTipoVehiculo TipoVehiculo)
        {
            try
            {
                var vParqueadero = await context.Parqueaderos.Where(x => x.TipoVehiculo == TipoVehiculo && x.Disponible == EnumParqueaderoDisponible.Si).ToListAsync();
                if (vParqueadero == null)
                {
                    return new NotFoundResult();
                }
                return vParqueadero;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<ActionResult<clsParqueadero>> GetParqueadero(int Id)
        {
            try
            {
                var vParqueadero = await context.Parqueaderos.FirstOrDefaultAsync(x => x.Id == Id);
                if (vParqueadero == null)
                {
                    return new NotFoundResult();
                }
                return vParqueadero;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<ActionResult> InsertParqueadero([FromBody] clsParqueadero pvParqueadero)
        {
            try
            {
                context.Parqueaderos.Add(pvParqueadero);
                await context.SaveChangesAsync();
                return new CreatedAtRouteResult("GetParqueadero", new { Id = pvParqueadero.Id }, pvParqueadero);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<ActionResult> UpdateParqueadero(int Id, [FromBody] clsParqueadero pvParqueadero)
        {
            try
            {
                if (Id != pvParqueadero.Id)
                {
                    return new BadRequestResult();
                }
                context.Entry(pvParqueadero).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();
                return new OkResult();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public ActionResult UpdateStateParqueadero([FromBody] clsParqueadero pvParqueadero)
        {
            try
            {
                context.Attach(pvParqueadero);
                context.Entry(pvParqueadero).Property(x => x.Disponible).IsModified = true;
                context.SaveChanges();
                return new OkResult();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<ActionResult<clsParqueadero>> DeleteParqueadero(int Id)
        {
            try
            {
                var vParqueadero = await context.Parqueaderos.FirstOrDefaultAsync(x => x.Id == Id);
                if (vParqueadero == null)
                {
                    return new NotFoundResult();
                }
                context.Parqueaderos.Remove(vParqueadero);
                await context.SaveChangesAsync();
                return vParqueadero;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
