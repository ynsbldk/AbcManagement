using AbcManagement.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AbcManagement.Entities.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {

        Task<IEnumerable<Category>> GetAllWithCategoryAsync();

    }

}
