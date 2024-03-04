using API_pacPay.Dtos;
using API_pacPay.models;
using AutoMapper;

namespace API_pacPay.Profiles;

public class UserProfile : Profile
{
    public UserProfile() 
    {
        CreateMap<SingUpDto,User>();

        CreateMap<User, ProfileDto>();
       


        CreateMap<LoginDto, User>();
        CreateMap<User, LoginDto>();
      
    }


}
