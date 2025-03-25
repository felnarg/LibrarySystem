using InfrastructureProject.DataBaseContext;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using DomainProject.Repository;
using System.Linq;

namespace InfrastructureProject.Repository;

public class LibraryRepository<T> : DomainProject.Repository.IRepository<T> where T : class
{
    private LibraryDbContext? _context;

    public LibraryRepository(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<T> GetByIdAsync(int id)
    {
        T entity = await _context.Set<T>().FindAsync(id);
        if (entity == null)
        {
            throw new KeyNotFoundException($"No se encuentra el id de la entidad {typeof(T).Name} buscada");
        }
        return entity;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        IEnumerable<T> entities = await _context!.Set<T>().ToListAsync();
        return entities;
    }

    public async Task<T> GetFilterAsync(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
    {
        IQueryable<T> query = _context!.Set<T>();

        if (includes != null)
        {
            query = includes(query);
        }

        T? result = await query.FirstOrDefaultAsync(filter);

        if (result == null)
        {
            throw new KeyNotFoundException($"No se encuentra el id de la entidad {typeof(T).Name} buscada");
        }

        return result;
    }

    public async Task AddAsync(T entity)
    {
        await _context!.Set<T>().AddAsync(entity);
        await _context!.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        try
        {
            _context!.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new KeyNotFoundException($"No se encuentra la entidad {typeof(T).Name} buscada");
        }
    }

    public async Task DeleteAsync(int id)
    {
        T entity = await _context!.Set<T>().FindAsync(id);
        if (entity != null)
        {
            _context.Set<T>().Remove(entity);
            await _context!.SaveChangesAsync();
        }
    }
}
