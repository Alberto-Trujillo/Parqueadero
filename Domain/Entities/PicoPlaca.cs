using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parqueadero.Entities
{
    public class PicoPlaca
    {

        public int Id { get; set; }

        [Required]
        public DayOfWeek Dia { get; set; }
        [Required]
        [Range(0,9)]
        public short Numero{ get; set; }
    }
}
