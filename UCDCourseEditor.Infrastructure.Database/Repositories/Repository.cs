using Microsoft.EntityFrameworkCore;
using UCDCourseEditor.Core.Interfaces.Repositories;
using UCDCourseEditor.Core.Models;
using UCDCourseEditor.Infrastructure.Database.Data;

namespace UCDCourseEditor.Infrastructure.Database.Repositories;

public abstract class Repository<TDomain, TEntity> : IRepository<TDomain>
    where TDomain : class, IEntity
    where TEntity : class
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<TEntity>       _dbSet;

    protected Repository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }
    
    public virtual async Task<TDomain> AddAsync(TDomain entity)
    {
        var entityToAdd = MapToEntity(entity);
        await _dbSet.AddAsync(entityToAdd);
        await _context.SaveChangesAsync();
        
        return MapToDomain(entityToAdd);
        
    }
    
    public virtual async Task UpdateAsync(TDomain entity)
    {
        var entityToUpdate = MapToEntity(entity);
        _dbSet.Update(entityToUpdate);
        await _context.SaveChangesAsync();
    }
    
    public virtual async Task DeleteAsync(int id)
    {
        var entityToDelete = await _dbSet.FindAsync(id);
        if (entityToDelete != null)
        {
            _dbSet.Remove(entityToDelete);
            await _context.SaveChangesAsync();
        }
        
    }
    
    public virtual async Task<TDomain?> GetByIdAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        
        return entity == null ? null : MapToDomain(entity);
    }
    
    public virtual async Task<IEnumerable<TDomain>> GetAllAsync()
    {
        var entities = await _dbSet.ToListAsync();
        var domains = entities.Select(MapToDomain);
        return domains;
    }
    
    protected abstract TEntity MapToEntity(TDomain domain);
    protected abstract TDomain MapToDomain(TEntity entity);
}