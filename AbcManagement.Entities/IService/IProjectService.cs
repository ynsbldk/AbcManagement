using AbcManagement.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AbcManagement.Entities.IService
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetAllWithProject();
        Task<Project> GetProjectById(int id);
        Task<IEnumerable<Project>> GetProjectsByCategoryId(int categoryId);
        Task<Project> CreateProject(Project newProject);
        Task UpdateProject(Project rojectToBeUpdated, Project project);
        Task DeleteProject(Project project);
        Task<IEnumerable<Project>> GetProjectList();
        Task<IEnumerable<ApplicationUser>> GetProjectUser();
    }
}
