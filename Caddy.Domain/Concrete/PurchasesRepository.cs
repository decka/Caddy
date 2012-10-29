using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caddy.Domain.Abstract;
using Caddy.Domain.Entities;
using System.Data.Linq;

namespace Caddy.Domain.Concrete
{
    class PurchasesRepository : IPurchasesRepository
    {
        protected Table<Purchase> PurchasesTable;
        public IEnumerable<Purchase> Purchases { get { return PurchasesTable.AsQueryable(); } }

        public PurchasesRepository(DataContext dataContext)
        {
            PurchasesTable = dataContext.GetTable<Purchase>();
        }

        public IEnumerable<Purchase> GetByPurchaseState(PurchaseState purchaseState)
        {
            return PurchasesTable.Where(p => p.InvState == purchaseState);
        }

        public IEnumerable<Purchase> GetAll()
        {
            return PurchasesTable;
        }

        public IEnumerable<Purchase> GetByID(int id)
        {
            return PurchasesTable.Where(p => p.PurchaseID == id);
        }

        public IEnumerable<Purchase> GetByDatabaseKeys(List<string> databaseKeys)
        {
            return PurchasesTable.Where(p => databaseKeys.Contains(p.Supplier.MYOB));
        }
        public IEnumerable<Purchase> GetByDatabaseKeysAndSendToMYOB(List<string> databaseKeys)
        {
            return PurchasesTable.Where(p => databaseKeys.Contains(p.DatabaseKey)).Where(p => p.InvState == PurchaseState.SENDTOMYOB);
        }
    }
}
