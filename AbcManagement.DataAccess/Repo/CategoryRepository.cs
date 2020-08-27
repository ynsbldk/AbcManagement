using AbcManagement.DataAccess.Data;
using AbcManagement.Entities.Entities;
using AbcManagement.Entities.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AbcManagement.DataAccess.Repo
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AbcDbContext repositoryContext)
          : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Category>> GetAllWithCategoryAsync()
        {
            return await myContext.Categories.ToListAsync();
        }


        private AbcDbContext myContext
        {
            get { return Context as AbcDbContext; }
        }
    }
}
