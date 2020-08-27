using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AbcManagement.Entities.Entities;

namespace AbcManagement.Entities.Repositories
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<Project> GetWithProjectByIdAsync(int id);

        Task<IEnumerable<Project>> GetAllWithProjectAsync();

        Task<IEnumerable<Project>> GetProjects();
    }
}
