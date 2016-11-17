using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindXpert.Repository.Repositories
{
    public abstract class DataRepository<T> : DataRepositoryBase<T, FindXpertContext>
        where T : class, new()
    {
    }
}
