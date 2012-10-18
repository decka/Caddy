using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caddy.Domain.Entities
{
    public class PurchaseState
    {
        public static readonly PurchaseState OPEN = new PurchaseState("OPEN", "Open");
        public static readonly PurchaseState CLOSED = new PurchaseState("CLOSED", "Closed");
        public static readonly PurchaseState SENDTOMYOB = new PurchaseState("SENDTOMYOB", "Send To MYOB");

        private readonly string name;
        private readonly string value;

        static PurchaseState()
        {
        }

        private PurchaseState(string value, string name)
        {
            this.value = value;
            this.name = name;
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
