using DotNET6JwtAssignment.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNET6JwtAssignment.Data.Repository.Interface
{
    public interface IVisitRepository
    {
        Task<IEnumerable<Visit>> GetAllVisits(bool trackChanges);
        Task<Visit> GetVisit(Guid patientId, bool trackChanges);
        Task CreateVisit(Visit visit);
        Task DeleteVisit(Visit visit);
    }
}
