using AbcManagement.Entities;
using AbcManagement.Entities.Entities;
using AbcManagement.Entities.IService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AbcManagement.Business.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Category> CreateCategory(Category newCategory)
        {

            await _unitOfWork.Categories.AddAsync(newCategory);
            await _unitOfWork.CommitAsync();
            return newCategory;

        }

        public async Task DeleteCategory(Category category)
        {
            _unitOfWork.Categories.Remove(category);
            await _unitOfWork.CommitAsync(); ;
        }

        public async Task<IEnumerable<Category>> GetAllWithProject()
        {
            return await _unitOfWork.Categories.GetAllAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _unitOfWork.Categories.GetByIdAsync(id);
        }

        public Task<IEnumerable<Category>> GetProjectsByCategoryId(int categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateCategory(Category categoryToBeUpdated)
        {
            throw new NotImplementedException();

        }
    }
}
