using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Resources;
using System.Security.Policy;
using System.Threading.Tasks;
using static Domain.Enums.TipoVehiculo;
using static Parqueadero.Entities.clsParqueadero;

namespace Parqueadero.Entities
{
    public class Vehiculo: IValidatableObject
    {
        public int Id { get; set; }
        [Required]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "¡La matricula es erronea, debe contener 6 digitos!")]
        public String Matricula { get; set; }
        [Required]
        [Range(0,1,ErrorMessage ="¡Debe ingresar el valor '0' para carro y '1' para moto!")]
        public EnumTipoVehiculo TipoVehiculo { get; set; }
        public int Cilindraje { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(TipoVehiculo == EnumTipoVehiculo.Moto)
            {
                if (Cilindraje <= 0)
                yield return new ValidationResult("¡Debe de ingresar cilindraje de la moto!");


                //Si finaliza en letra es Moto, de lo contrario es Carro.
                byte vBytMatriculaFinal = 0;
                if (byte.TryParse(Matricula.Substring(Matricula.Length - 1), out vBytMatriculaFinal))
                    yield return new ValidationResult("¡La matricula de moto debe terminar en letras!");
            }
        }
    }
}
