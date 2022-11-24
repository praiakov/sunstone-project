using Microsoft.EntityFrameworkCore;
using SunstoneProject.Domain.Interfaces;
using SunstoneProject.Domain.Common;
using SunstoneProject.Infrastructure.Persistence.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SunstoneProject.Infrastructure.Persistence.EntityFramework.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        protected readonly SunstoneContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(SunstoneContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public async Task<IEnumerable<BaseEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<BaseEntity> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            //TODO
            throw new NotImplementedException();
        }

        public virtual async Task<int> Add(TEntity entity)
        {
            DbSet.Add(entity);

            return await SaveChanges();
        }

        public virtual async Task Update(TEntity entity)
        {
            DbSet.Update(entity);

            await SaveChanges();
        }

        public virtual async Task Delete(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges() => await Db.SaveChangesAsync();

        public void Dispose() => Db?.Dispose();
    }
}
