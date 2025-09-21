using System.Collections;
using Lab05_Juli.Models;
using Lab05_Juli.Repository;
using Lab05_Juli.Repository.Implements;

namespace Lab05_Juli.UnitOfWork.Implements;

public class UnitOfWork : IUnitOfWork
{
    private Hashtable? _repositories;
    private readonly GestioncoleContext _context;
    public IMatriculaRepository Matriculas { get; }

    public UnitOfWork(GestioncoleContext context)
    {
        _context = context;
        _repositories = new Hashtable();
        
        Matriculas = new MatriculaRepository(_context);
    }

    public async Task<int> Complete()
    {
        return await _context.SaveChangesAsync();
    }

    public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
    {
        var type = typeof(TEntity).Name;

        if (_repositories!.ContainsKey(type))
        {
            return (IGenericRepository<TEntity>)_repositories[type]!;
        }

        var repositoryType = typeof(GenericRepository<>);
        var repositoryInstance = Activator.CreateInstance(
            repositoryType.MakeGenericType(typeof(TEntity)), _context);

        if (repositoryInstance != null)
        {
            _repositories.Add(type, repositoryInstance);
            return (IGenericRepository<TEntity>)repositoryInstance;
        }

        throw new Exception($"No se pudo crear el repositorio para el tipo {type}");
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}