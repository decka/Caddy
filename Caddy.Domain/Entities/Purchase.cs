using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caddy.Domain.Entities
{
    public class Purchase
    {
        public int PurchaseID { get; set; }
        public Supplier Supplier { get; set; }
        public DateTime PurchaseDate { get; set; }
        public Project Project { get; set; }
        public string Desription { get; set; }
        public PurchaseState InvState { get; set; }
        public IList<PurchaseEntry> PurchaseEntries { get; set; }
        public string DatabaseKey { get; set; }
    }
}
