using AutoMapper;
using DotNET6JwtAssignment.Data.UnitOfWork.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DotNET6JwtAssignment.API.Controllers;

public class BaseController : ControllerBase
{
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly IMapper _mapper;
    

    public BaseController(IUnitOfWork unitOfWork,IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
}
