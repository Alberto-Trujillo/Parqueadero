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
using static Domain.Enums.Disponible;
using static Domain.Enums.TipoVehiculo;
using static Parqueadero.Entities.clsParqueadero;

namespace Parqueadero.Services
{
    public class CobroService : ICobro
    {
        private readonly ApplicationDbContext context;
        private readonly IParqueadero srvParqueadero;

        public CobroService(ApplicationDbContext context, IParqueadero SrvParqueadero)
        {
            this.context = context;
            srvParqueadero = SrvParqueadero;
        }

        public async Task<ActionResult<IList<Entities.Cobro>>> GetPayments()
        {
            try
            {
                return await context.Cobros.Where(x => x.Activo == EnumParqueaderoDisponible.Si).Include(x => x.Vehiculo).ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<ActionResult<Entities.Cobro>> GetPayment(int Id)
        {
            try
            {
                var vCobro = await context.Cobros.Include(x => x.Vehiculo).FirstOrDefaultAsync(x => x.Id == Id);
                if (vCobro == null)
                {
                    return new NotFoundResult();
                }
                return vCobro;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<ActionResult> InsertPayment([FromBody] Entities.Cobro pvCobro)
        {
            try
            {
                if (ValidarPicoPlaca(pvCobro.VehiculoId))
                {
                    return new BadRequestObjectResult("¡El vehiculo se encuentra en pico y placa!");
                }
                pvCobro.Hora_Ingreso = DateTime.Now;
                pvCobro.Activo = EnumParqueaderoDisponible.Si;
                if (UpdateStateParqueadero(pvCobro, EnumParqueaderoDisponible.No))
                {
                    context.Cobros.Add(pvCobro);
                    await context.SaveChangesAsync();
                    return new CreatedAtRouteResult("GetPayment", new { Id = pvCobro.Id }, pvCobro);
                }
                return new ConflictResult();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<ActionResult> UpdatePayment(int Id)
        {
            try
            {
                var vPayment = GetPayment(Id).Result.Value;


                vPayment.Hora_Salida = DateTime.Now;
                vPayment.ValorTotal = ValidatePayment(vPayment);
                vPayment.Activo = EnumParqueaderoDisponible.No;
                context.Entry(vPayment).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                if (UpdateStateParqueadero(vPayment, EnumParqueaderoDisponible.Si))
                {
                    await context.SaveChangesAsync();
                }
                return new OkObjectResult(vPayment);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<ActionResult<Entities.Cobro>> DeletePayment(int Id)
        {
            try
            {
                var vCobro= context.Cobros.FirstOrDefault(x => x.Id == Id);
                if (vCobro == null)
                {
                    return new NotFoundResult();
                }
                context.Cobros.Remove(vCobro);
                await context.SaveChangesAsync();
                return vCobro;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int ValidatePayment(Entities.Cobro pvCobro)
        {
            try
            {
                TimeSpan vTmsTiempoParqueo = pvCobro.Hora_Salida - pvCobro.Hora_Ingreso;
                //TimeSpan result = pvVehiculo.Hora_Salida.Subtract(pvVehiculo.Hora_Ingreso);

                int vIntDias = 0, vIntValorTotal = 0;
                int vIntHoras = Convert.ToInt32(Math.Ceiling(vTmsTiempoParqueo.TotalHours));

                if (vIntHoras >= 24)
                {
                    vIntDias = (vIntHoras / 24);
                    vIntHoras = (vIntHoras % 24);
                }
                if (vIntHoras >= 9)
                {
                    vIntDias += (vIntHoras / 9);
                    vIntHoras = (vIntHoras % 9);
                }

                switch (pvCobro.Vehiculo.TipoVehiculo)
                {
                    case EnumTipoVehiculo.Carro:
                        vIntValorTotal = vIntDias * 8000;//Se calculan los dias con el valor base que es de $8.000 para carros.
                        vIntValorTotal += (vIntHoras * 1000);//Se calculan las horas con el valor base que es de $1.000 para carros.
                        break;
                    case EnumTipoVehiculo.Moto:
                        vIntValorTotal = vIntDias * 4000;//Se calculan los dias con el valor base que es de $4.000 para motos.
                        vIntValorTotal = vIntValorTotal + (vIntHoras * 500);//Se calculan las horas con el valor base que es de $500 para motos.
                        vIntValorTotal += pvCobro.Vehiculo.Cilindraje > 500 ? 2000 : 0;
                        break;
                }

                return vIntValorTotal;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private bool UpdateStateParqueadero(Entities.Cobro pvCobro, EnumParqueaderoDisponible vEnumParqueaderoDisponible)
        {
            try
            {
                Entities.clsParqueadero vParqueadero = new Entities.clsParqueadero()
                {
                    Id = pvCobro.Parqueadero,
                    Disponible = vEnumParqueaderoDisponible
                };
                ActionResult vUpdateParqueadero = srvParqueadero.UpdateStateParqueadero(vParqueadero);
                if (vUpdateParqueadero.ToString() == new OkResult().ToString())
                {
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }

        public bool ValidarPicoPlaca(int pvIntVehiculoId)
        {
            try
            {
                var vVehiculo = context.Vehiculos.FirstOrDefault(x => x.Id == pvIntVehiculoId);
                if(vVehiculo.TipoVehiculo == EnumTipoVehiculo.Carro)
                {
                    var vPicoPlacas = context.PicoPlacas.Where(x => x.Numero == int.Parse(vVehiculo.Matricula.Substring(vVehiculo.Matricula.Length - 1)));
                    foreach (var vPicoPlaca in vPicoPlacas)
                    {
                        if ((DayOfWeek)vPicoPlaca.Dia == DateTime.Now.DayOfWeek)
                            return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
