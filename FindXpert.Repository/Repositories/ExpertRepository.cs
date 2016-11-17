using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindXpert.Repository.Contracts;
using FindXpert.Repository.Entities;

namespace FindXpert.Repository.Repositories
{

    public class ExpertRepository : DataRepository<Expert>, IExpertRepository
    {
        protected override Expert AddEntity(FindXpertContext entityContext, Expert entity)
        {
            return entityContext.Experts.Add(entity);
        }

        protected override Expert UpdateEntity(FindXpertContext entityContext, Expert entity)
        {
            return (from e in entityContext.Experts
                where e.Id == entity.Id
                select e).FirstOrDefault();
        }

        protected override IEnumerable<Expert> GetEntities(FindXpertContext entityContext)
        {
            return from e in entityContext.Experts
                select e;
        }

        protected override Expert GetEntity(FindXpertContext entityContext, int id)
        {
            var query = (from e in entityContext.Experts
                where e.Id == id
                select e);

            var results = query.FirstOrDefault();

            return results;
        }


        //////////////////////////////////////////////////////////////

        public Expert GetExpertByProjectId(int id)
        {
            using (FindXpertContext entityContext = new FindXpertContext())
            {
                var query = from e in entityContext.Experts
                            from p in e.Projects
                            where p.Id == id
                            select e;

                return query.FirstOrDefault();
            }
        }

    }
}
