using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caddy.Domain.Abstract;
using Caddy.Domain.Entities;

namespace Caddy.Domain.Concrete
{
    public class MockPurchasesRepository : IPurchasesRepository
    {
        public List<Purchase> Purchases { get; set; }

        public MockPurchasesRepository(List<Purchase> purchases)
        {
            this.Purchases = purchases;
        }
        public IEnumerable<Purchase> GetByID(int purchaseID)
        {
            return Purchases.Where(p => p.PurchaseID == purchaseID);
        }
        public IEnumerable<Purchase> GetByPurchaseState(PurchaseState purchaseState)
        {
            return Purchases.Where(p => p.InvState == purchaseState);
        }
        public IEnumerable<Purchase> GetAll()
        {
            return Purchases;
        }
        public IEnumerable<Purchase> GetByDatabaseKeys(List<string> databaseKeys)
        {
            return Purchases.Where(p => databaseKeys.Contains(p.Supplier.MYOB));
        }
        public IEnumerable<Purchase> GetByDatabaseKeysAndSendToMYOB(List<string> databaseKeys)
        {
            return Purchases.Where(p => databaseKeys.Contains(p.DatabaseKey)).Where(p => p.InvState == PurchaseState.SENDTOMYOB);
        }
    }
}
