using AutoMapper;
using DotNET6JwtAssignment.Common.ActionFilters;
using DotNET6JwtAssignment.Common.Dtos;
using DotNET6JwtAssignment.Data.UnitOfWork.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DotNET6JwtAssignment.API.Controllers;


[Route("api/userauth")]
[ApiController]
public class AuthController : BaseController
{
    public AuthController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork,mapper)
    {
    }

    [HttpPost("register")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationDto userRegistration)
    {
        
        var userResult = await _unitOfWork.UserAuth.RegisterUserAsync(userRegistration);
        return !userResult.Succeeded ? new BadRequestObjectResult(userResult) : StatusCode(201);
    }

    [HttpPost("login")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> Authenticate([FromBody] UserLoginDto user)
    {
        return !await _unitOfWork.UserAuth.ValidateUserAsync(user) 
            ? Unauthorized() 
            : Ok(new { Token = await _unitOfWork.UserAuth.CreateTokenAsync() });
    }

}
