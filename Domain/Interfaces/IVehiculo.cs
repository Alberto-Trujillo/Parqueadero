using Microsoft.AspNetCore.Mvc;
using Parqueadero.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Domain.Enums.TipoVehiculo;

namespace Parqueadero.Services.Interfaces
{
    public interface IVehiculo
    {
        public Task<ActionResult<IList<Vehiculo>>> GetVehicles();
        public Task<ActionResult<Vehiculo>> GetVehicle(int pvIntId);
        public Task<ActionResult<IList<Vehiculo>>> GetVehiclesByTypeVechicle(EnumTipoVehiculo TipoVehiculo);
        public Task<ActionResult<IList<Vehiculo>>> GetVehiclesFilter(String pvStrMatricula);
        public Task<ActionResult> InsertVehicle([FromBody] Vehiculo pvVehiculo);
        public Task<ActionResult> UpdateVehicle(int pvIntId, [FromBody] Vehiculo pvVehiculo);
        public Task<ActionResult<Vehiculo>> Delete(int pvIntId);
    }
}