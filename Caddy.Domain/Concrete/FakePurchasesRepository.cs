using Caddy.Domain.Entities;
using Caddy.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caddy.Domain.Concrete
{
    public class FakePurchasesRepository : IPurchasesRepository
    {
        private static IQueryable<Purchase> FakePurchases = new List<Purchase> { 
            new Purchase { PurchaseID = 1, Supplier = null, PurchaseDate = DateTime.Parse("2012-10-01 06:00"), Project = null, Desription = "Hammer", InvState = PurchaseState.OPEN, PurchasedItems = null }}.AsQueryable();

        public IQueryable<Purchase> Purchases
        {
            get { return FakePurchases; }
        }

        public Purchase GetPurchaseByID(int purchaseID)
        {
            return FakePurchases.Where(x => x.PurchaseID == purchaseID).FirstOrDefault();
        }

        public IQueryable<Purchase> GetPurchasesByPurchaseState(PurchaseState purchaseState)
        {
            return FakePurchases.Where(x => x.InvState == purchaseState).DefaultIfEmpty();
        }
    }
}
