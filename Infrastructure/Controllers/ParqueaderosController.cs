using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parqueadero.Entities;
using Parqueadero.Interfaces;
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
    public class ParqueaderosController:ControllerBase
    {
        private readonly IParqueadero SrvParqueadero;

        public ParqueaderosController(IParqueadero parqueadero)
        {
            this.SrvParqueadero = parqueadero;
        }

        [HttpGet]
        public Task<ActionResult<IList<clsParqueadero>>> GetParqueaderos()
        {
            return SrvParqueadero.GetParqueaderos();
        }

        [HttpGet("Disponibles")]
        public Task<ActionResult<IList<clsParqueadero>>> GetParqueaderosDisponibles()
        {
            return SrvParqueadero.GetParqueaderosDisponibles();
        }

        [HttpGet("Disponibles/{TipoVehiculo}", Name = "GetParqueaderosDisponibles")]
        public Task<ActionResult<IList<clsParqueadero>>> GetParqueaderosDisponiblesByTypeVehicle(EnumTipoVehiculo TipoVehiculo)
        {
            return SrvParqueadero.GetParqueaderosDisponiblesByTypeVehicle(TipoVehiculo);
        }

        [HttpGet("{Id}", Name = "GetParqueadero")]
        public Task<ActionResult<clsParqueadero>> GetParqueaderos(int Id)
        {
            return SrvParqueadero.GetParqueadero(Id);
        }

        [HttpPost]
        public Task<ActionResult> Post([FromBody] clsParqueadero pvParqueadero)
        {
            return SrvParqueadero.InsertParqueadero(pvParqueadero);
        }

        [HttpPut("{Id}")]
        public Task<ActionResult> Put(int Id, [FromBody] clsParqueadero pvParqueadero)
        {
            return SrvParqueadero.UpdateParqueadero(Id, pvParqueadero);
        }

        [HttpDelete("{Id}")]
        public Task<ActionResult<clsParqueadero>> Delete(int Id)
        {
            return SrvParqueadero.DeleteParqueadero(Id);
        }
    }
}
