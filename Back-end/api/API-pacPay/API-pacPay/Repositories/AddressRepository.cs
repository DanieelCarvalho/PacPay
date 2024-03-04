using API_pacPay.Domain.models;
using API_pacPay.infraestrutura;
using API_pacPay.Repositories.Interfaces;

namespace API_pacPay.Repositories;

public class AddressRepository : BaseRepository<Address>, IAddressRepository
{
    public AddressRepository(BankContext bankContext) : base(bankContext)
    {
    }
}
