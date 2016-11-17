using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindXpert.Repository.Contracts;
using FindXpert.Repository.Entities;

namespace FindXpert.Repository.Contracts
{
    public interface IExpertRepository : IDataRepository<Expert>
    {
        /// Any specific functions for IExpertRepository
        
        Expert GetExpertByProjectId(int id);
        
    }
}
