using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static Domain.Enums.Disponible;

namespace Parqueadero.Entities
{
    public class Cobro
    {
        public int Id { get; set; }
        [Required]
        public int VehiculoId { get; set; }
        public Vehiculo Vehiculo { get; set; }
        [Required]
        public short Parqueadero { get; set; }
        public DateTime Hora_Ingreso { get; set; }
        public DateTime Hora_Salida { get; set; }
        public int ValorTotal { get; set; }
        public EnumParqueaderoDisponible Activo { get; set; }
    }
}
