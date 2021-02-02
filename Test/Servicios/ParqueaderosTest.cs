using NUnit.Framework;
using Parqueadero.Contexts;
using Parqueadero.Entities;
using Parqueadero.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enums.Disponible;
using static Domain.Enums.TipoVehiculo;
using static Parqueadero.Entities.clsParqueadero;

namespace Test.Servicios
{
    class ParqueaderosTest: BaseTest
    {
        [Test]
        public async Task GetParqueaderosTest()
        {
            ApplicationDbContext vDbContextForCreateRegisters = CreateContext("GetParqueaderosTest");
            vDbContextForCreateRegisters.Parqueaderos.Add(new clsParqueadero()
            {
                Id = 1,
                TipoVehiculo = EnumTipoVehiculo.Moto,
                Disponible = EnumParqueaderoDisponible.Si
            });
            vDbContextForCreateRegisters.Parqueaderos.Add(new clsParqueadero()
            {
                Id = 2,
                TipoVehiculo = EnumTipoVehiculo.Carro,
                Disponible = EnumParqueaderoDisponible.Si
            });
            await vDbContextForCreateRegisters.SaveChangesAsync();

            ApplicationDbContext vDbContextForGetRegisters = CreateContext("GetParqueaderosTest");

            ParqueaderoService vSrvParqueadero= new ParqueaderoService(vDbContextForGetRegisters);
            var vLstParqueaderos= await vSrvParqueadero.GetParqueaderosDisponibles();

            Assert.IsNotNull(vLstParqueaderos);
            Assert.AreEqual(2, vLstParqueaderos.Value.Count);
        }
    }
}
