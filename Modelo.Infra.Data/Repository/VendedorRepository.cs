using System;
using System.Collections.Generic;
using System.Text;
using Vendr.Domain.Entities;
using Vendr.Infra.Data.Context;
using Vendr.Domain.Interfaces;
namespace Vendr.Infra.Data.Repository
{
    public class VendedorRepository : BaseRepositoryAsync<Vendedor>
    {
        public VendedorRepository(DBContext context)
            : base(context)
        { }
    }
}
