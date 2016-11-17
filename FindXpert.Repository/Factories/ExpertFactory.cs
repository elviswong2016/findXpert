using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindXpert.Repository.Entities;

namespace FindXpert.Repository.Factories
{
    public class ExpertFactory
    {
        ProjectFactory projectFactory = new ProjectFactory();

        public ExpertFactory()
        {
            
        }

        public DTO.Expert CreateExpert(Expert expert)
        {
            return new DTO.Expert()
            {
                Id          = expert.Id,
                FirstName   = expert.FirstName,
                LastName    = expert.LastName,
                Projects    = expert.Projects.Select(e => projectFactory.CreateProject(e)).ToList()
            };
        }

        public Expert CreateExpert(DTO.Expert expert)
        {
            return new Expert()
            {
                Id = expert.Id,
                FirstName = expert.FirstName,
                LastName = expert.LastName,
                Projects = expert.Projects == null ? new List<Project>() : expert.Projects.Select(e => projectFactory.CreateProject(e)).ToList()
            };
        }
    }
}
