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
    [Route("api/visit")]
    [Authorize]
    [ApiController]
    public class VisitsController :BaseController
    {
        public VisitsController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateVisit([FromBody] VisitsAddUpdateDto visit)
        {
            var visitData = _mapper.Map<Visit>(visit);
            await _unitOfWork.Visit.CreateVisit(visitData);
            await _unitOfWork.Save();
            var visitReturn = _mapper.Map<VisitsDto>(visitData);
            return CreatedAtRoute("VisitById",
                new
                {
                    VisitId = visitReturn.Id
                },
                visitReturn);
        }


        [HttpGet]
        [ResponseCache(CacheProfileName = "30SecondsCaching")]
        public async Task<IActionResult> GetVisits()
        {
            try
            {
                var doctors = await _unitOfWork.Visit.GetAllVisits(trackChanges: false);
                var doctorsDto = _mapper.Map<IEnumerable<PatientDto>>(doctors);
                return Ok(doctorsDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet("{visitId}", Name = "VisitById")]
        public async Task<IActionResult> GetVisit(Guid visitId)
        {
            var visit = await _unitOfWork.Visit.GetVisit(visitId, trackChanges: false);
            if (visit is null)
            {
                return NotFound();
            }
            else
            {
                var visitDto = _mapper.Map<VisitsDto>(visit);
                return Ok(visitDto);
            }
        }


        [HttpPut("{visitId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateVisit(Guid visitId, [FromBody] VisitsAddUpdateDto visit)
        {
            var visitData = HttpContext.Items["Visit"] as Visit;
            _mapper.Map(visit, visitData);
            await _unitOfWork.Save();
            return NoContent();
        }
        
        [HttpDelete("{visitId}", Name = "DeleteVisit")]
        public async Task<IActionResult> DeleteVisit(Guid visitId)
        {
            var visit = await _unitOfWork.Visit.GetVisit(visitId, trackChanges: false);
            if (visit is null)
            {
                return NotFound();
            }
            else
            {
                await _unitOfWork.Visit.DeleteVisit(visit);
                return Ok("Deleted Succesfully!");
            }
        }
    }
}
