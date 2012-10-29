using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caddy.Server
{
    // This class defines the Contract of data the clients are expecting.
    public class PurchaseDTO
    {
        public int PurchaseID { get; set; }
        public string Supplier { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string Project { get; set; }
        public string Desription { get; set; }
    }
}
