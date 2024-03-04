using API_pacPay.Domain.models;
using API_pacPay.infraestrutura;
using API_pacPay.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_pacPay.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(BankContext context) : base(context)
        {
        }


        public Task ChangePassword(User user, string newPassword)
        {
            throw new NotImplementedException();
        }

      public async Task<User> GetByCpf(string cpf)
       {
            return await _bankContext.Usuario.FirstOrDefaultAsync(user => user.Cpf.Equals(cpf));

       }

        public async Task<User> GetByEmail(string email)
        {
            return await _bankContext.Usuario.FirstOrDefaultAsync(user => user.Email.Equals(email));

        }

        public async Task<bool> IsCpfRegistered(string cpf)
        {
            return await _bankContext.Usuario.AnyAsync(user => user.Cpf.Equals(cpf));
        }

        public async Task<bool> IsEmailRegistered(string email)
        {
            return await _bankContext.Usuario.AnyAsync(user => user.Email.Equals(email));
        }
    }
}
