using Microsoft.EntityFrameworkCore;
using Parqueadero.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class BaseTest
    {
        protected ApplicationDbContext CreateContext(String pvStrNombreDB)
        {
            var vOpciones = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(pvStrNombreDB).Options;
            var vDbContext = new ApplicationDbContext(vOpciones);
            return vDbContext;
        }
    }
}
