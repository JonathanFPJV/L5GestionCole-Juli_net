using AutoMapper;
using Lab05_Juli.UnitOfWork;

namespace Lab05_Juli.Service.Implements;

public class GenericService<TEntity, TDto, TCreateDto, TUpdateDto> 
    : IGenericService<TDto, TCreateDto, TUpdateDto>
    where TEntity : class
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GenericService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<TEntity>().GetAll();
        return _mapper.Map<IEnumerable<TDto>>(entities);
    }

    public async Task<TDto?> GetByIdAsync(int id)
    {
        var entity = await _unitOfWork.Repository<TEntity>().GetById(id);
        return _mapper.Map<TDto>(entity);
    }

    public async Task<TDto> CreateAsync(TCreateDto dto)
    {
        var entity = _mapper.Map<TEntity>(dto);
        await _unitOfWork.Repository<TEntity>().Add(entity);
        await _unitOfWork.Complete();
        return _mapper.Map<TDto>(entity);
    }

    public async Task<bool> UpdateAsync(TUpdateDto dto)
    {
        var entity = _mapper.Map<TEntity>(dto);
        await _unitOfWork.Repository<TEntity>().Update(entity);
        await _unitOfWork.Complete();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        await _unitOfWork.Repository<TEntity>().Delete(id);
        await _unitOfWork.Complete();
        return true;
    }
}
