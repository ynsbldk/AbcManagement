using AbcManagement.Entities.Entities;
using AbcManagement.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AbcManagement.Entities
{
    public interface IUnitOfWork : IDisposable
    {
        IProjectRepository Projects { get; }

        ICategoryRepository Categories { get; }

        Task<IEnumerable<ApplicationUser>> applicationUser();

        Task<int> CommitAsync();
    }
}
