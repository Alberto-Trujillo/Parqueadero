using Microsoft.AspNetCore.Mvc;
using Parqueadero.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parqueadero.Services.Interfaces
{
    public interface ICobro
    {
        public Task<ActionResult<IList<Cobro>>> GetPayments();
        public Task<ActionResult<Cobro>> GetPayment(int Id);
        public Task<ActionResult> InsertPayment([FromBody] Cobro pvCobro);
        public Task<ActionResult> UpdatePayment(int Id);
        public Task<ActionResult<Cobro>> DeletePayment(int Id);
    }
}
