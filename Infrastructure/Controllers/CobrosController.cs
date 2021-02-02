using Microsoft.AspNetCore.Mvc;
using Parqueadero.Entities;
using Parqueadero.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parqueadero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CobrosController
    {
        private readonly ICobro SrvCobro;

        public CobrosController(ICobro cobro)
        {
            this.SrvCobro = cobro;
        }

        [HttpGet]
        public Task<ActionResult<IList<Cobro>>> GetPayments()
        {
            return SrvCobro.GetPayments();
        }

        [HttpGet("{Id}", Name = "GetPayment")]
        public Task<ActionResult<Cobro>> GetPayment(int Id)
        {
            return SrvCobro.GetPayment(Id);
        }

        [HttpPost]
        public Task<ActionResult> Post([FromBody] Cobro pvCobro)
        {
            return SrvCobro.InsertPayment(pvCobro);
        }

        [HttpPut("{Id}")]
        public Task<ActionResult> Put(int Id)
        {
            return SrvCobro.UpdatePayment(Id);
        }

        [HttpDelete("{Id}")]
        public Task<ActionResult<Cobro>> Delete(int Id)
        {
            return SrvCobro.DeletePayment(Id);
        }
    }
}
