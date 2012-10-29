using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caddy.Domain.Entities;

namespace Caddy.Server
{
    class PurchaseDTOAssembler
    {
        public PurchaseDTO CreateDTO(Purchase purchase)
        {
            return new PurchaseDTO { 
                Desription = purchase.Desription, 
                PurchaseDate = purchase.PurchaseDate, 
                Project = purchase.Project.ProjectName, 
                PurchaseID = purchase.PurchaseID, 
                Supplier = purchase.Supplier.Name 
            };
        }

        //public void UpdateDomainObject(DTO DataTransferObject)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
