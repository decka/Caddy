using Caddy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caddy.Domain.Abstract
{
    public interface IPurchasesRepository : ICanGetAll<Purchase>, ICanGetByID<Purchase>
    {
        IEnumerable<Purchase> GetByPurchaseState(PurchaseState purchaseState);
        IEnumerable<Purchase> GetByDatabaseKeys(List<string> databaseKeys);
        IEnumerable<Purchase> GetByDatabaseKeysAndSendToMYOB(List<string> databaseKeys);
    }
}
