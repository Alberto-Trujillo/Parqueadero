using Microsoft.AspNetCore.Mvc;
using Parqueadero.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Domain.Enums.TipoVehiculo;

namespace Parqueadero.Interfaces
{
    public interface IParqueadero
    {
        public Task<ActionResult<IList<clsParqueadero>>> GetParqueaderos();
        public Task<ActionResult<IList<clsParqueadero>>> GetParqueaderosDisponibles();
        public Task<ActionResult<IList<clsParqueadero>>> GetParqueaderosDisponiblesByTypeVehicle(EnumTipoVehiculo TipoVehiculo);
        public Task<ActionResult<clsParqueadero>> GetParqueadero(int Id);
        public Task<ActionResult> InsertParqueadero([FromBody] clsParqueadero pvParqueadero);
        public Task<ActionResult> UpdateParqueadero(int Id, [FromBody] clsParqueadero pvParqueadero);
        public ActionResult UpdateStateParqueadero([FromBody] clsParqueadero pvParqueadero);
        public Task<ActionResult<clsParqueadero>> DeleteParqueadero(int Id);
    }
}
