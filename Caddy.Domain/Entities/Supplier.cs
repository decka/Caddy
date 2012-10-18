using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caddy.Domain.Entities
{
    public class Supplier
    {
        public int SupplierID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Suburb { get; set; }
        public string Telephone { get; set; }
        public string Postcode { get; set; }
        public string MYOB { get; set; }
        public string Terms { get; set; }
    }
}
