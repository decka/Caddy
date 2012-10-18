using Caddy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caddy.Domain.Abstract
{
    public interface IPurchasesRepository
    {
        IQueryable<Purchase> Purchases { get; }
        Purchase GetPurchaseByID(int purchaseID);
        IQueryable<Purchase> GetPurchasesByPurchaseState(PurchaseState purchaseState);
    }
}
