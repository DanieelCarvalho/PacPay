using API_pacPay.Domain.Dtos;
using API_pacPay.Domain.models;
using AutoMapper;

namespace API_pacPay.Profiles;

public class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<SingUpDto, Address>();
    }
}
