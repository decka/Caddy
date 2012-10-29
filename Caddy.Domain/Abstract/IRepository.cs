using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caddy.Domain.Abstract
{
    public interface ICanGetAll<T>
    {
        IEnumerable<T> GetAll();
    }

    public interface ICanGetByID<T>
    {
        IEnumerable<T> GetByID(int id);
    }
}
