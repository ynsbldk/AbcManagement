using AbcManagement.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AbcManagement.Entities.IService
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllWithProject();
        Task<Category> GetCategoryById(int id);
        Task<IEnumerable<Category>> GetProjectsByCategoryId(int categoryId);
        Task<Category> CreateCategory(Category newCategory);
        Task UpdateCategory(Category categoryToBeUpdated);
        Task DeleteCategory(Category category);
    }
}
