using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parqueadero.Contexts;
using Parqueadero.Entities;
using Parqueadero.Interfaces;
using Parqueadero.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Domain.Enums.TipoVehiculo;
using static Parqueadero.Entities.clsParqueadero;

namespace Parqueadero.Services
{
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public class VehiculoService : IVehiculo
    {
        private readonly ApplicationDbContext context;

        public VehiculoService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<ActionResult<IList<Entities.Vehiculo>>> GetVehicles()
        {
            try
            {
                return await context.Vehiculos.ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<ActionResult<Entities.Vehiculo>> GetVehicle(int pvIntId)
        {
            try
            {
                var vVehiculo = await context.Vehiculos.FirstOrDefaultAsync(x => x.Id == pvIntId);
                if (vVehiculo == null)
                {
                    return new NotFoundResult();
                }
                return vVehiculo;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<ActionResult<IList<Entities.Vehiculo>>> GetVehiclesByTypeVechicle(EnumTipoVehiculo TipoVehiculo)
        {
            try
            {
                var vVehiculo = await context.Vehiculos.Where(x => x.TipoVehiculo == TipoVehiculo).ToListAsync();
                if (vVehiculo == null)
                {
                    return new NotFoundResult();
                }
                return vVehiculo;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<ActionResult<IList<Entities.Vehiculo>>> GetVehiclesFilter(String pvStrMatricula)
        {
            try
            {
                var vVehiculo = await context.Vehiculos.Where(x => x.Matricula.Contains(pvStrMatricula)).ToListAsync();
                if (vVehiculo == null)
                {
                    return new NotFoundResult();
                }
                return vVehiculo;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<ActionResult> InsertVehicle([FromBody] Entities.Vehiculo pvVehiculo)
        {
            try
            {
                context.Vehiculos.Add(pvVehiculo);
                await context.SaveChangesAsync();
                return new CreatedAtRouteResult("GetVehicle", new { Id = pvVehiculo.Id }, pvVehiculo);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<ActionResult> UpdateVehicle(int pvIntId, [FromBody] Entities.Vehiculo pvVehiculo)
        {
            try
            {
                if (pvIntId != pvVehiculo.Id)
                {
                    return new BadRequestResult();
                }
                context.Entry(pvVehiculo).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return new OkResult();
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<ActionResult<Entities.Vehiculo>> Delete(int pvIntId)
        {
            try
            {
                var vVehiculo = context.Vehiculos.FirstOrDefault(x => x.Id == pvIntId);
                if (vVehiculo == null)
                {
                    return new NotFoundResult();
                }
                context.Vehiculos.Remove(vVehiculo);
                await context.SaveChangesAsync();
                return vVehiculo;
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }
    }
}
