using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projeto.Domain.Entities;
using Projeto.Infra.Context;
using Projeto.Infra.Interfaces;

namespace Projeto.Infra.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository{

         private readonly ManagerContext _context;

        public UserRepository(ManagerContext context) : base (context){
            _context = context;
        }

        public virtual async Task<User> GetByEmail(string email){
            var obj = await _context.Users
                                    .Where
                                    (
                                        x => x.Email.ToLower() == email.ToLower()
                                    )
                                    .AsNoTracking()
                                    .ToListAsync();

            return obj.FirstOrDefault;
        }

       public async Task<List<User>> SearchByEmail(string email){
           var allUsers = await _context.Users
                                        .Where
                                        (
                                            x => x.Email.ToLower().Contains(email.ToLower())
                                        )
                                        .AsNoTracking()
                                        .ToListAsync();


            return allUsers;
        } 

        public virtual async Task<List<User>> SearchByName(string name){
            var allUsers = await _context.Users
                                    .Where
                                    (
                                        x => x.Name.ToLower() == name.ToLower()
                                    )
                                    .AsNoTracking()
                                    .ToListAsync();

            return allUsers;
        }

    }
   
}