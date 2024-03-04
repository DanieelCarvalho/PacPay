
using API_pacPay.Domain.models;

namespace API_pacPay.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
         public Task<bool> IsCpfRegistered(string cpf);

        public Task<bool> IsEmailRegistered(string email);
        public Task ChangePassword(User user, string newPassword);

        public Task<User> GetByCpf(string cpf);

        public Task<User> GetByEmail(string email);

    }
}
