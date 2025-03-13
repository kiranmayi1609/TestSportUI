using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using SportTestAPI.Database;
using SportTestAPI.IGenericRepo;

namespace SportTestAPI.ImplementRepo
{
    public class GenericRepo<T, TRequestDto, TResponseDto> : IGenericRepository<T, TRequestDto, TResponseDto> where T : class

    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly DbSet<T> _dbset;

        public GenericRepo(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _dbset = context.Set<T>();
            
        }
        public virtual async Task<TResponseDto> CreateAsync(TRequestDto requestDto)
        {
            if(requestDto==null)
            {
                throw new ArgumentNullException(nameof(requestDto));
            }
            //Convert request DTO to entity 
            var entity = _mapper.Map<T>(requestDto);
            //Add entity to DB
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            //await _dbset.AddAsync(entity);
            //await _context.SaveChangesAsync();

            //Convert entity back to reponse DTO 
            return _mapper.Map<TResponseDto>(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbset.FindAsync(id);
            if (entity! == null)
            {
                _dbset.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TResponseDto>> GetAllAsync()
        {
            var entities = await _dbset.ToListAsync();
            return _mapper.Map<IEnumerable<TResponseDto>>(entities);
        }

        public async Task<TResponseDto> GetByIdAsync(int id)
        {
            var entity = await _dbset.FindAsync(id);
            return _mapper.Map<TResponseDto>(entity);
            
        }

        public async Task UpdateAsync(int id, TRequestDto requestDto)
        {
            var entity = await _dbset.FindAsync(id);
            if (entity == null) return;
            _mapper.Map(requestDto, entity);
            await _context.SaveChangesAsync();
           
        }
    }
}
