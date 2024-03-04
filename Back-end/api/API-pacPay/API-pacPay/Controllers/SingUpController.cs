using API_pacPay.Domain.Dtos;
using API_pacPay.Domain.models;
using API_pacPay.Repositories;
using API_pacPay.Repositories.Interfaces;
using API_pacPay.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_pacPay.Controllers;

[ApiController]
[Route("/singup")]
public class SingUpController : ControllerBase
{

     private readonly IUserRepository _userRepository;
     private readonly IMapper  _mapper;
     private readonly IAddressRepository _addressRepository;

    public SingUpController(IUserRepository userRepository, IMapper mapper, IAddressRepository addressRepository)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _addressRepository = addressRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] SingUpDto bodyData)
    {
        SignupService Validar = new SignupService();

       List<string> Validacao = Validar.ValidacaoCadastro(bodyData);
        if (Validacao.Any()) throw new Exception(string.Join(',', Validacao));

        if (await _userRepository.IsCpfRegistered(bodyData.Cpf))
            throw new Exception("cpfAlreadyRegistered");

        if (await _userRepository.IsEmailRegistered(bodyData.Email))
            throw new Exception("emailAlreadyRegistered"); ;

        User newUser = _mapper.Map<User>(bodyData);


        //SingUpDto usuario =  await _userRepository.Add(bodyData);
        await _userRepository.Add(newUser);

        var newAddress = _mapper.Map<Address>(bodyData, opts =>
        {
            opts.AfterMap((src, dest) => dest.UserId = newUser.Id);
        });
        await _addressRepository.Add(newAddress);
                
        return CreatedAtAction(nameof(Criar), new { id = newUser.Id }, newUser);

    }

}
