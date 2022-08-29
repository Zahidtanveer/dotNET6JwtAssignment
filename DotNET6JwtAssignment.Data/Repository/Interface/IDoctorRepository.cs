using DotNET6JwtAssignment.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNET6JwtAssignment.Data.Repository.Interface
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetAllDoctors(bool trackChanges);
        Task<Doctor> GetDoctor(Guid doctorId, bool trackChanges);
        Task CreateDoctor(Doctor doctor);
        Task DeleteDoctor(Doctor doctor);
    }
}
