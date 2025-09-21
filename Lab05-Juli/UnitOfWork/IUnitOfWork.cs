using Lab05_Juli.Repository;

namespace Lab05_Juli.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;
    IMatriculaRepository Matriculas { get; }
    Task<int> Complete();
}