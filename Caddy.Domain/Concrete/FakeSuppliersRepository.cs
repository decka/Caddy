using Caddy.Domain.Entities;
using Caddy.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caddy.Domain.Concrete
{
    public class FakeSuppliersRepository : ISuppliersRepository
    {
        private static IQueryable<Supplier> FakeSuppliers = new List<Supplier> { new Supplier {
            SupplierID = 1, Name = "Bunnings", Address = "Burwood Rd", Suburb = "Hawthorn", Telephone = "03 9818 1234", Postcode = "3122", MYOB = "BUN(1)", Terms = "GST + 10%" }}.AsQueryable();

        IQueryable<Supplier> ISuppliersRepository.Suppliers
        {
            get { return FakeSuppliers; }
        }
    }
}
