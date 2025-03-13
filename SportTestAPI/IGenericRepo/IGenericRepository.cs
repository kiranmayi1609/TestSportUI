using System.Collections.Generic;

namespace SportTestAPI.IGenericRepo
{
    public interface IGenericRepository<T,TRequestDto,TResponseDto> where T : class
    {
        Task<TResponseDto> GetByIdAsync(int id);
        Task<IEnumerable<TResponseDto>> GetAllAsync();

        Task<TResponseDto> CreateAsync(TRequestDto requestDto);

        Task UpdateAsync(int id,TRequestDto requestDto);
        Task DeleteAsync(int id);
    }
}
