using Caddy.Domain.Entities;
using Caddy.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caddy.Domain.Concrete
{
    public class FakeProjectsRepository : IProjectsRepository
    {
        private static IQueryable<Project> FakeProjects = new List<Project> {
            new Project { ProjectID = 1, ProjectName = "Smith Street" }}.AsQueryable();
    
        public IQueryable<Project> Projects
        { 
            get { return FakeProjects; }
        }
    }
}
