using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static Domain.Enums.Disponible;
using static Domain.Enums.TipoVehiculo;

namespace Parqueadero.Entities
{
    public class clsParqueadero
    {
        public int Id { get; set; }
        
        [Required]
        public EnumTipoVehiculo TipoVehiculo { get; set; }
        public EnumParqueaderoDisponible Disponible { get; set; }
    }
}
