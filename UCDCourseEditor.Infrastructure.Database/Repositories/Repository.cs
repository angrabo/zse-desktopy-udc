using Microsoft.EntityFrameworkCore;
using UCDCourseEditor.Core.Interfaces.Repositories;
using UCDCourseEditor.Core.Models;
using UCDCourseEditor.Infrastructure.Database.Data;

namespace UCDCourseEditor.Infrastructure.Database.Repositories;

public abstract class Repository<TDomain, TEntity> : IRepository<TDomain>
    where TDomain : class, IEntity
    where TEntity : class
{
    protected readonly ApplicationDbContext Context;
    protected readonly DbSet<TEntity>       DbSet;

    protected Repository(ApplicationDbContext context)
    {
        Context = context;
        DbSet = Context.Set<TEntity>();
    }

    public abstract Task<TDomain> AddAsync(TDomain entity);
    public abstract Task<TDomain> UpdateAsync(TDomain entity);
    public abstract Task DeleteAsync(int id);
    public abstract Task<TDomain> GetByIdAsync(int id);
    public abstract Task<IEnumerable<TDomain>> GetAllAsync();
    
    protected abstract TEntity MapToEntity(TDomain domain);
    protected abstract TDomain MapToDomain(TEntity entity);
}