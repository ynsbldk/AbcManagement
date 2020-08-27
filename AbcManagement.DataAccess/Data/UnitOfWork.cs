using AbcManagement.DataAccess.Repo;
using AbcManagement.Entities;
using AbcManagement.Entities.Entities;
using AbcManagement.Entities.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AbcManagement.DataAccess.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AbcDbContext _context;
        private ProjectRepository _projectRepository;
        private CategoryRepository _categoryRepository;

        public UnitOfWork(AbcDbContext context)
        {
            this._context = context;
        }

        public ICategoryRepository Categories => _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);

        public IProjectRepository Projects => _projectRepository = _projectRepository ?? new ProjectRepository(_context);

        public async Task<IEnumerable<ApplicationUser>> applicationUser()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
