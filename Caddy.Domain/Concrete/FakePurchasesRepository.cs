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
            new Purchase { PurchaseID = 1, Supplier = null, PurchaseDate = DateTime.Parse("2012-10-01 06:00"), Project = null, Desription = "Hammer", InvState = PurchaseState.OPEN, PurchasedItems = null },
            new Purchase { PurchaseID = 2, Supplier = null, PurchaseDate = DateTime.Parse("2012-10-02 06:00"), Project = null, Desription = "Nail", InvState = PurchaseState.SENDTOMYOB, PurchasedItems = null },
            new Purchase { PurchaseID = 3, Supplier = null, PurchaseDate = DateTime.Parse("2012-10-03 06:00"), Project = null, Desription = "Router", InvState = PurchaseState.CLOSED, PurchasedItems = null }
        }.AsQueryable();

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
        
        public IQueryable<Purchase> GetPurchasesToSendToMYOB()
        {
            return FakePurchases.Where(x => x.InvState == PurchaseState.SENDTOMYOB).DefaultIfEmpty();
        }
    }
}
