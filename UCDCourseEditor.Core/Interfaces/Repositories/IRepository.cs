namespace UCDCourseEditor.Core.Interfaces.Repositories;

public interface IRepository<TDomain> where TDomain : class
{
    Task<TDomain> AddAsync(TDomain  entity);
    Task UpdateAsync(TDomain        entity);
    Task DeleteAsync(int            id);
    Task<TDomain?> GetByIdAsync(int id);
    Task<IEnumerable<TDomain>> GetAllAsync();
}