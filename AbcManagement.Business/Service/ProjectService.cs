using AbcManagement.Entities;
using AbcManagement.Entities.Entities;
using AbcManagement.Entities.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AbcManagement.Business.Service
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Project> CreateProject(Project newProject)
        {
            await _unitOfWork.Projects.AddAsync(newProject);
            await _unitOfWork.CommitAsync();
            return newProject;
          
        }

        public async Task DeleteProject(Project project)
        {
            _unitOfWork.Projects.Remove(project);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Project>> GetAllWithProject()
        {
            return await _unitOfWork.Projects.GetAllAsync();
        }

        public async Task<Project> GetProjectById(int id)
        {
            return await _unitOfWork.Projects
              .GetWithProjectByIdAsync(id);
        }

        public async Task<IEnumerable<Project>> GetProjectList()
        {
            return await _unitOfWork.Projects.GetProjects();
        }

        public Task<IEnumerable<Project>> GetProjectsByCategoryId(int categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateProject(Project rojectToBeUpdated, Project project)
        {
            rojectToBeUpdated.Id = project.Id;
            rojectToBeUpdated.Category.Id = project.Category.Id;

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<ApplicationUser>> GetProjectUser()
        {
            return await _unitOfWork.applicationUser();
        }

        public Task<Project> GetProjectById(string id)
        {
            throw new NotImplementedException();
        }

       
    }
}
