using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Parqueadero.Contexts;
using Parqueadero.Controllers;
using Parqueadero.Entities;
using Parqueadero.Services;
using Parqueadero.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Domain.Enums.TipoVehiculo;
using static Parqueadero.Entities.clsParqueadero;

namespace Test.Servicios
{
    public class VehiculosTest: BaseTest
    {
        [Test]
        public async Task GetVehiclesTest()
        {
            ApplicationDbContext vDbContextForCreateRegisters = CreateContext("GetVehiclesTest");
            vDbContextForCreateRegisters.Vehiculos.Add(new Parqueadero.Entities.Vehiculo() { Id = 1, Matricula = "XXX000",
                Cilindraje = 0, TipoVehiculo = EnumTipoVehiculo.Carro });
            vDbContextForCreateRegisters.Vehiculos.Add(new Parqueadero.Entities.Vehiculo() { Id = 2, Matricula = "XXX001",
                Cilindraje = 1000, TipoVehiculo = EnumTipoVehiculo.Moto });
            await vDbContextForCreateRegisters.SaveChangesAsync();


            ApplicationDbContext vDbContextForGetRegisters = CreateContext("GetVehiclesTest");

            VehiculoService vSrvVehiculo = new VehiculoService(vDbContextForGetRegisters);
            var vLstVehicles = await vSrvVehiculo.GetVehicles();

            Assert.IsNotNull(vLstVehicles, "El ActionResult no debe ser Null.");
            Assert.AreEqual(2, vLstVehicles.Value.Count, "El Modelo pasado a la Vista contiene todos los registros de la BD.");
        }

        [Test]
        public async Task NotGetVehiclesByIdTest()
        {
            ApplicationDbContext vDbContextForGetRegisters = CreateContext("GetVehiclesByIdTest");

            VehiculoService vSrvVehiculo = new VehiculoService(vDbContextForGetRegisters);
            var vLstVehicles = await vSrvVehiculo.GetVehicle(1);
            var vIntResult = vLstVehicles.Result as StatusCodeResult;

            Assert.AreEqual(404, vIntResult.StatusCode);
        }

        [Test]
        public async Task InsertVehicleTest()
        {
            ApplicationDbContext vDbContextForCreateRegisters = CreateContext("InsertVehicleTest");
            Vehiculo vVehiculo = new Parqueadero.Entities.Vehiculo() { Id = 10, Matricula = "XXX222", Cilindraje = 0,
                TipoVehiculo = EnumTipoVehiculo.Carro };

            VehiculoService vSrvVehiculo = new VehiculoService(vDbContextForCreateRegisters);

            var vIntResult = await vSrvVehiculo.InsertVehicle(vVehiculo) as CreatedAtRouteResult;
            Assert.IsNotNull(vIntResult);
        }

        [Test]
        public async Task UpdateVehicleTest()
        {
            ApplicationDbContext vDbContextForCreateRegisters = CreateContext("UpdateVehicleTest");
            vDbContextForCreateRegisters.Vehiculos.Add(new Vehiculo() { Id = 10, Matricula = "AAA010", Cilindraje = 950,
                TipoVehiculo = EnumTipoVehiculo.Moto });
            await vDbContextForCreateRegisters.SaveChangesAsync();

            ApplicationDbContext vDbContextForUpdateRegister = CreateContext("UpdateVehicleTest");

            VehiculoService vSrvVehiculo = new VehiculoService(vDbContextForUpdateRegister);
            Vehiculo vVehiculoUpdate = new Vehiculo() { Id = 10, Matricula = "AAA011", Cilindraje = 1800,
                TipoVehiculo = EnumTipoVehiculo.Moto };

            var vResult = await vSrvVehiculo.UpdateVehicle(vVehiculoUpdate.Id, vVehiculoUpdate) as StatusCodeResult;
            Assert.IsNotNull(vResult);
            Assert.AreEqual(200, vResult.StatusCode);
        }

        [Test]
        public async Task DeleteVehicleNotExistTest()
        {
            ApplicationDbContext vDbContextForCreateRegisters = CreateContext("DeleteVehicleNotExistTest");

            VehiculoService vSrvVehiculo = new VehiculoService(vDbContextForCreateRegisters);

            var vResult = await vSrvVehiculo.Delete(1);
            Assert.IsNotNull(vResult.Result);
        }

        [Test]
        public async Task DeleteVehicleTest()
        {
            ApplicationDbContext vDbContextForCreateRegisters = CreateContext("DeleteVehicleTest");
            Vehiculo vVehiculo = new Vehiculo() { Id = 100, Matricula = "CCC111", Cilindraje = 150,
                TipoVehiculo = EnumTipoVehiculo.Moto };
            vDbContextForCreateRegisters.Vehiculos.Add(vVehiculo);
            await vDbContextForCreateRegisters.SaveChangesAsync();

            ApplicationDbContext vDbContextForDeleteRegister = CreateContext("DeleteVehicleTest");

            VehiculoService vSrvVehiculo = new VehiculoService(vDbContextForDeleteRegister);

            var vResult = await vSrvVehiculo.Delete(100);
            Assert.IsNotNull(vResult);
            Assert.AreEqual(vVehiculo.Id, vResult.Value.Id);
        }
    }
}