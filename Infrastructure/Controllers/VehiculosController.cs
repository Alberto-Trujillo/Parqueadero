using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parqueadero.Entities;
using Parqueadero.Interfaces;
using Parqueadero.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Domain.Enums.TipoVehiculo;
using static Parqueadero.Entities.clsParqueadero;

namespace Parqueadero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculosController:ControllerBase
    {
        private readonly IVehiculo SrvVehiculo;

        public VehiculosController(IVehiculo vehiculo)
        {
            this.SrvVehiculo = vehiculo;
        }

        [HttpGet]
        public Task<ActionResult<IList<Vehiculo>>> GetVehicles()
        {
            return SrvVehiculo.GetVehicles();
        }

        [HttpGet("{Id}", Name ="GetVehicle")]
        public Task<ActionResult<Vehiculo>> GetVehicle(int Id)
        {
            return SrvVehiculo.GetVehicle(Id);
        }

        [HttpGet("TipoVehiculo/{TipoVehiculo}", Name = "GetVehiclesByTypeVechicle")]
        public Task<ActionResult<IList<Vehiculo>>> GetVehiclesByTypeVechicle(EnumTipoVehiculo TipoVehiculo)
        {
            return SrvVehiculo.GetVehiclesByTypeVechicle(TipoVehiculo);
        }

        [HttpGet("Filter/{Matricula}", Name = "GetVehiclesFilter")]
        public Task<ActionResult<IList<Vehiculo>>> GetVehiclesFilter(String Matricula)
        {
            return SrvVehiculo.GetVehiclesFilter(Matricula);
        }

        [HttpPost]
        public Task<ActionResult> Post([FromBody] Vehiculo pvVehiculo)
        {
            return SrvVehiculo.InsertVehicle(pvVehiculo);
        }

        [HttpPut("{Id}")]
        public Task<ActionResult> Put(int Id, [FromBody] Vehiculo pvVehiculo)
        {
            return SrvVehiculo.UpdateVehicle(Id, pvVehiculo);
        }

        [HttpDelete("{Id}")]
        public Task<ActionResult<Vehiculo>> Delete(int Id)
        {
            return SrvVehiculo.Delete(Id);
        }
    }
}
