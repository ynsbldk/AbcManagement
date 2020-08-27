using AbcManagement.DataAccess.Data;
using AbcManagement.DataAccess.Repo;
using AbcManagement.Entities.Entities;
using AbcManagement.Entities.Repositories;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AbcManagement.DataAccess.Repo
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(AbcDbContext repositoryContext)
           : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Project>> GetAllWithProjectAsync()
        {

            return await myContext.Projects.Include(x => x.Category).Include(x=>x.AppUser).ToListAsync();

        }

        public async Task<Project> GetWithProjectByIdAsync(int id)
        {

            return await myContext.Projects.Include(x => x.Category).SingleOrDefaultAsync(x => x.Id == id);
            
        }
       

        public async Task<IEnumerable<Project>> GetProjects()
        {             
            return await myContext.Projects.Include(x=>x.AppUser).ToListAsync();
           
        }

        private AbcDbContext myContext
        {
            get { return Context as AbcDbContext; }
        }
    }
}
