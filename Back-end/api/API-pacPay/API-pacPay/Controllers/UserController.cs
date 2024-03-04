using API_pacPay.Domain.Dtos;
using API_pacPay.Domain.models;
using API_pacPay.Repositories.Interfaces;
using API_pacPay.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static System.Net.Mime.MediaTypeNames;


namespace API_pacPay.Controllers;


[ApiController]
[Route("/users")]
public class UserController : ControllerBase
{

    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserController(IUserRepository userRepository, IMapper mapper)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {

        var users = await _userRepository.GetAll();

        return Ok(users);
    }

    [HttpGet]
    [Route("{id}")]

    public async Task<IActionResult> GetId(int id)
    {
        var user = await _userRepository.GetId(id);

        var userProfile = _mapper.Map<ProfileDto>(user);



        return Ok(userProfile);
    }




    /// <summary>
    /// Login do usuario
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [Route("login")]

    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        User user = await _userRepository.GetByCpf(loginDto.Cpf);

        if (user == null) return StatusCode(statusCode: (int)HttpStatusCode.NotFound, value: new
        {
            Message = $"O Cpf {loginDto.Cpf} não está cadastrado em nosso sistema.",
            Moment = DateTime.Now
        });

        bool doesPasswordMatch = PasswordVerificationService.CheckPassword(user.Senha, loginDto.Password);

        if (!doesPasswordMatch) return StatusCode(403);

       // string token = JwtAuth.GenerateToken(user);

        return Ok();
    }



    [HttpDelete]
    [Route("{id}")]

    public async Task<IActionResult> Delete(int id)
    {
        await _userRepository.Delete(id);
        return Ok("Sucesso");
    }


}
