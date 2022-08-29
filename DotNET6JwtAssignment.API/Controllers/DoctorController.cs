using AutoMapper;
using DotNET6JwtAssignment.Common.ActionFilters;
using DotNET6JwtAssignment.Common.Dtos;
using DotNET6JwtAssignment.Common.Models;
using DotNET6JwtAssignment.Data.UnitOfWork.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNET6JwtAssignment.API.Controllers
{
    [Route("api/doctor")]
    [Authorize]
    [ApiController]
    public class DoctorController :BaseController
    {
        public DoctorController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateDoctor([FromBody] DoctorAddUpdateDto doctor)
        {
            var doctorData = _mapper.Map<Doctor>(doctor);
            await _unitOfWork.Doctor.CreateDoctor(doctorData);
            await _unitOfWork.Save();
            var doctorReturn = _mapper.Map<DoctorDto>(doctorData);
            return CreatedAtRoute("DoctorById",
                new
                {
                    DoctorId = doctorReturn.Id
                },
                doctorReturn);
        }


        [HttpGet]
        [ResponseCache(CacheProfileName = "30SecondsCaching")]
        public async Task<IActionResult> GetDoctors()
        {
            try
            {
                var doctors = await _unitOfWork.Doctor.GetAllDoctors(trackChanges: false);
                var doctorsDto = _mapper.Map<IEnumerable<DoctorDto>>(doctors);
                return Ok(doctorsDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet("{doctorId}", Name = "DoctorById")]
        public async Task<IActionResult> GetDoctor(Guid doctorId)
        {
            var doctor = await _unitOfWork.Doctor.GetDoctor(doctorId, trackChanges: false);
            if (doctor is null)
            {
                return NotFound();
            }
            else
            {
                var doctorDto = _mapper.Map<DoctorDto>(doctor);
                return Ok(doctorDto);
            }
        }


        [HttpPut("{doctorId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateDoctor(Guid doctorId, [FromBody] DoctorAddUpdateDto doctor)
        {
            var doctorData = HttpContext.Items["doctor"] as Doctor;
            _mapper.Map(doctor, doctorData);
            await _unitOfWork.Save();
            return NoContent();
        }
        
        [HttpDelete("{doctorId}", Name = "DeleteDoctor")]
        public async Task<IActionResult> DeleteDoctor(Guid doctorId)
        {
            var doctor = await _unitOfWork.Doctor.GetDoctor(doctorId, trackChanges: false);
            if (doctor is null)
            {
                return NotFound();
            }
            else
            {
                await _unitOfWork.Doctor.DeleteDoctor(doctor);
                return Ok("Deleted Successfully!");
            }
        }
    }
}
