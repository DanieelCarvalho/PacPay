using API_pacPay.Dtos;
using API_pacPay.models;
using AutoMapper;

namespace API_pacPay.Profiles;

public class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<SingUpDto, Address>();
    }
}
