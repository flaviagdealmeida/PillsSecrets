using System.Threading.Tasks;
using System.Collections.Generic;
using Projeto.Domain.Entities;

namespace Projeto.Infra.Interfaces{
    public interface IUserRepository : IBaseRepository<User>{

        Task<User> GetByEmail(string email);
        Task<List<User>> SearchByEmail(string email);
        Task<List<User>> SearchByName(string email);

    }
}