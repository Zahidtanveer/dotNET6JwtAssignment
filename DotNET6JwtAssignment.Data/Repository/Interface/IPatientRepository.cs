using DotNET6JwtAssignment.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNET6JwtAssignment.Data.Repository.Interface
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAllPatients(bool trackChanges);
        Task<Patient> GetPatient(Guid patientId, bool trackChanges);
        Task CreatePatient(Patient patient);
        Task DeletePatient(Patient patient);
    }
}
