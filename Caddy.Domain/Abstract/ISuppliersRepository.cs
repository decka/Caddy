using Caddy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caddy.Domain.Abstract
{
    public interface ISuppliersRepository
    {
        IQueryable<Supplier> Suppliers { get; }
    }
}
