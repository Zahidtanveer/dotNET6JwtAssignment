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
    [Route("api/patient")]
    [Authorize]
    [ApiController]
    public class PatientController : BaseController
    {
        public PatientController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateDoctor([FromBody] DoctorAddUpdateDto patient)
        {
            var patientdata = _mapper.Map<Patient>(patient);
            await _unitOfWork.Patient.CreatePatient(patientdata);
            await _unitOfWork.Save();
            var patientReturn = _mapper.Map<DoctorDto>(patientdata);
            return CreatedAtRoute("PatientById",
                new
                {
                    PatientId = patientReturn.Id
                },
                patientReturn);
        }


        [HttpGet]
        [ResponseCache(CacheProfileName = "30SecondsCaching")]
        public async Task<IActionResult> GetPatients()
        {
            try
            {
                var doctors = await _unitOfWork.Patient.GetAllPatients(trackChanges: false);
                var doctorsDto = _mapper.Map<IEnumerable<PatientDto>>(doctors);
                return Ok(doctorsDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet("{patientId}", Name = "PatientById")]
        public async Task<IActionResult> GetPatient(Guid patientId)
        {
            var patient = await _unitOfWork.Patient.GetPatient(patientId, trackChanges: false);
            if (patient is null)
            {
                return NotFound();
            }
            else
            {
                var patientDto = _mapper.Map<PatientDto>(patient);
                return Ok(patientDto);
            }
        }


        [HttpPut("{patientId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateDoctor(Guid patientId, [FromBody] PatientAddUpdateDto patient)
        {
            var patientData = HttpContext.Items["Patient"] as Patient;
            _mapper.Map(patient, patientData);
            await _unitOfWork.Save();
            return NoContent();
        }

        [HttpDelete("{patientId}", Name = "DeletePatient")]
        public async Task<IActionResult> DeletePatient(Guid patientId)
        {
            var patient = await _unitOfWork.Patient.GetPatient(patientId, trackChanges: false);
            if (patient is null)
            {
                return NotFound();
            }
            else
            {
                await _unitOfWork.Patient.DeletePatient(patient);
                return Ok("Deleted Successfully!");
            }
        }
    }
}
