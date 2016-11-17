using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindXpert.Repository.Entities;

namespace FindXpert.Repository.Factories
{
    public class ProjectFactory
    {
        public ProjectFactory()
        {
            
        }

        public DTO.Project CreateProject(Project project)
        {
            return new DTO.Project()
            {
                Id          = project.Id,
                Date        = project.Date,
                Decription  = project.Decription,
                ExpertId    = project.ExpertId
            };
        }


        public Project CreateProject(DTO.Project project)
        {
            return new Project()
            {
                Id          = project.Id,
                Date        = project.Date,
                Decription  = project.Decription,
                ExpertId    = project.ExpertId
            };
        }

    }
}
