using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projeto.Domain.Entities;
using Projeto.Infra.Context;
using Projeto.Infra.Interfaces;

namespace Projeto.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T: BaseRepository{

        private readonly ManagerContext _context;

        public BaseRepository(ManagerContext context){
            _context = context;
        }

        public virtual async Task<T> Create(T obj){
            _context.Add(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        public virtual async Task<T> Update(T obj){
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return obj;
        }
        public virtual async Task Remove(Long id){
            var obj = await Get (id);

            if (obj != null){
                _context.Remove(obj);
                await _context.SaveChangesAsync();

            }
        }

        public virtual async Task<T> Get(Long id){
            var obj = await _context.Set<T>()
                                    .AsNoTracking()
                                    .Wherew(x=>x.Id == id)
                                    .ToListAsync();

            return obj.FirstOrDefault;

        }

        public virtual async Task<List<T>> Get(){
            var obj = await _context.Set<T>()
                                    .AsNoTracking()
                                    .ToListAsync();
          
            }


    }
   
}