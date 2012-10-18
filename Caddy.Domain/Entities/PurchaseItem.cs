using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caddy.Domain.Entities
{
    public class PurchaseItem
    {
        public int PurchaseEntryID { get; set; }
        public Purchase Purchase { get; set; }
        public DateTime Date { get; set; }
        public string Details { get; set; }
        public int Count { get; set; }
        public Decimal ExGST { get; set; }
        public Decimal GST { get; set; }
        public int CostCodeID { get; set; }
    }
}
