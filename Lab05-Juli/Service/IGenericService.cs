namespace Lab05_Juli.Service;

public interface IGenericService<TDto, TCreateDto, TUpdateDto>
{
    Task<IEnumerable<TDto>> GetAllAsync();
    Task<TDto?> GetByIdAsync(int id);
    Task<TDto> CreateAsync(TCreateDto dto);
    Task<bool> UpdateAsync(TUpdateDto dto);
    Task<bool> DeleteAsync(int id);
}