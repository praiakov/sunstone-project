using SunstoneProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SunstoneProject.Application.Interfaces.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        Task<int> Add(TEntity entity);

        Task<BaseEntity> GetById(Guid id);

        Task<IEnumerable<BaseEntity>> GetAll();

        Task Update(TEntity entity);

        Task Delete(Guid id);

        Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);

        Task<int> SaveChanges();
    }
}
