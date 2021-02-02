using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Parqueadero.Contexts;
using Parqueadero.Entities;
using Parqueadero.Interfaces;
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
    class CobrosTest : BaseTest
    {
        Mock<IParqueadero> mockParqueadero;
        public CobrosTest()
        {
            mockParqueadero = new Mock<IParqueadero>();
            mockParqueadero.Setup(x => x.UpdateStateParqueadero(It.IsAny<clsParqueadero>())).Returns(new OkResult());
        }
        [Test]
        public async Task GetPaymentsTest()
        {
            ApplicationDbContext vDbContextForCreateRegisters = CreateContext("GetPaymentsTest");
            vDbContextForCreateRegisters.Parqueaderos.Add(new clsParqueadero()
            {
                Id = 1,
                TipoVehiculo = EnumTipoVehiculo.Moto,
                Disponible = EnumParqueaderoDisponible.Si
            });
            vDbContextForCreateRegisters.Vehiculos.Add(new Vehiculo() { Id = 1, Matricula = "XXX001", Cilindraje = 1000, TipoVehiculo = EnumTipoVehiculo.Moto });
            vDbContextForCreateRegisters.Cobros.Add(new Cobro() { Id = 1, VehiculoId = 1, Parqueadero = 1, Activo = EnumParqueaderoDisponible.Si });
            await vDbContextForCreateRegisters.SaveChangesAsync();

            ApplicationDbContext vDbContextForGetRegisters = CreateContext("GetPaymentsTest");

            CobroService vSrvCobro = new CobroService(vDbContextForGetRegisters, mockParqueadero.Object);
            var vLstPayments = await vSrvCobro.GetPayments();

            Assert.IsNotNull(vLstPayments);
            Assert.AreEqual(1, vLstPayments.Value.Count);
        }

        [Test]
        public async Task InsertPaymentTest()
        {
            ApplicationDbContext vDbContextForCreateRegisters = CreateContext("InsertPaymentTest");
            vDbContextForCreateRegisters.Parqueaderos.Add(new clsParqueadero()
            {
                Id = 1,
                TipoVehiculo = EnumTipoVehiculo.Moto,
                Disponible = EnumParqueaderoDisponible.Si
            });
            vDbContextForCreateRegisters.Vehiculos.Add(new Vehiculo() { Id = 1, Matricula = "XXX001", Cilindraje = 1000, TipoVehiculo = EnumTipoVehiculo.Moto });
            await vDbContextForCreateRegisters.SaveChangesAsync();

            Cobro vCobro = new Cobro()
            {
                Id = 1,
                VehiculoId = 1,
                Parqueadero = 1,
                Hora_Ingreso = DateTime.Now,
                Hora_Salida = DateTime.Now.AddHours(5),
                ValorTotal = 0,
                Activo = EnumParqueaderoDisponible.Si
            };

            CobroService vSrvCobro = new CobroService(vDbContextForCreateRegisters, mockParqueadero.Object);

            var vResult = await vSrvCobro.InsertPayment(vCobro) as CreatedAtRouteResult;
            Assert.IsNotNull(vResult);
            Assert.AreEqual(201, vResult.StatusCode);
        }

        [Test]
        public async Task UpdatePaymentTest()
        {
            ApplicationDbContext vDbContextForCreateRegisters = CreateContext("UpdatePaymentTest");
            vDbContextForCreateRegisters.Parqueaderos.Add(new clsParqueadero()
            {
                Id = 1,
                TipoVehiculo = EnumTipoVehiculo.Moto,
                Disponible = EnumParqueaderoDisponible.Si
            });
            vDbContextForCreateRegisters.Vehiculos.Add(new Vehiculo() { Id = 1, Matricula = "XXX001", Cilindraje = 500, TipoVehiculo = EnumTipoVehiculo.Moto });
            vDbContextForCreateRegisters.Cobros.Add(new Cobro()
            {
                Id = 1,
                VehiculoId = 1,
                Parqueadero = 1,
                Hora_Ingreso = DateTime.Now,
                Hora_Salida = DateTime.Now.AddHours(5),
                ValorTotal = 0,
                Activo = EnumParqueaderoDisponible.Si
            });
            await vDbContextForCreateRegisters.SaveChangesAsync();

            ApplicationDbContext vDbContextForUpdateRegister = CreateContext("UpdatePaymentTest");

            CobroService vSrvCobro = new CobroService(vDbContextForUpdateRegister, mockParqueadero.Object);

            var vResult = await vSrvCobro.UpdatePayment(1);
            Assert.IsNotNull(vResult);
        }

        [Test]
        public async Task ValidatePaymentTest()
        {
            ApplicationDbContext vDbContextForCreateRegisters = CreateContext("ValidatePaymentTest");
            vDbContextForCreateRegisters.Parqueaderos.Add(new clsParqueadero()
            {
                Id = 1,
                TipoVehiculo = EnumTipoVehiculo.Moto,
                Disponible = EnumParqueaderoDisponible.Si
            });
            Vehiculo vVehiculo = new Vehiculo()
            {
                Id = 1,
                Matricula = "XXX001",
                Cilindraje = 500,
                TipoVehiculo = EnumTipoVehiculo.Moto
            };
            Cobro vCobro = new Cobro()
            {
                Id = 1,
                VehiculoId = 1,
                Vehiculo = vVehiculo,
                Parqueadero = 1,
                Hora_Ingreso = DateTime.Now,
                Hora_Salida = DateTime.Now.AddHours(5),
                ValorTotal = 0,
                Activo = EnumParqueaderoDisponible.Si
            };
            await vDbContextForCreateRegisters.SaveChangesAsync();

            ApplicationDbContext vDbContextForUpdateRegister = CreateContext("ValidatePaymentTest");

            CobroService vSrvCobro = new CobroService(vDbContextForUpdateRegister, mockParqueadero.Object);

            var vResult = vSrvCobro.ValidatePayment(vCobro);
            Assert.IsNotNull(vResult);
            Assert.AreEqual(3000, vResult);
        }

        [Test]
        public async Task ValidarPicoPlacaTest()
        {
            ApplicationDbContext vDbContextForCreateRegisters = CreateContext("ValidarPicoPlacaTest");
            vDbContextForCreateRegisters.Vehiculos.Add(new Vehiculo() { Id = 1, Matricula = "XXX001", Cilindraje = 1000, TipoVehiculo = EnumTipoVehiculo.Moto });
            vDbContextForCreateRegisters.Vehiculos.Add(new Vehiculo() { Id = 2, Matricula = "XXX002", Cilindraje = 1000, TipoVehiculo = EnumTipoVehiculo.Carro });
            vDbContextForCreateRegisters.Vehiculos.Add(new Vehiculo() { Id = 3, Matricula = "XXX003", Cilindraje = 1000, TipoVehiculo = EnumTipoVehiculo.Carro });
            vDbContextForCreateRegisters.PicoPlacas.Add(new PicoPlaca() { Id = 1, Dia = DateTime.Now.DayOfWeek, Numero = 3 });
            await vDbContextForCreateRegisters.SaveChangesAsync();

            ApplicationDbContext vDbContextForGetRegisters = CreateContext("ValidarPicoPlacaTest");

            CobroService vSrvCobro = new CobroService(vDbContextForGetRegisters, mockParqueadero.Object);
            var vResult = vSrvCobro.ValidarPicoPlaca(1);
            Assert.IsNotNull(vResult);
            Assert.IsFalse(vResult);//El primer vehiculo es moto, no tiene pico y placa.

            vResult = vSrvCobro.ValidarPicoPlaca(2);
            Assert.IsNotNull(vResult);
            Assert.IsFalse(vResult);//El primer vehiculo no tiene pico y placa.

            vResult = vSrvCobro.ValidarPicoPlaca(3);
            Assert.IsNotNull(vResult);
            Assert.IsTrue(vResult);
        }
    }
}
