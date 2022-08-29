using DotNET6JwtAssignment.Common.Models;
using DotNET6JwtAssignment.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNET6JwtAssignment.Data.Repository
{
    public class PatientRepository :BaseRepositroy<Patient>, IPatientRepository
    {
        public PatientRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task CreatePatient(Patient patient) => await Create(patient);

        public async Task<IEnumerable<Patient>> GetAllPatients(bool trackChanges) => await FindAll(trackChanges).Result.OrderBy(c => c.Name).ToListAsync();

        public async Task<Patient> GetPatient(Guid patientId, bool trackChanges) => await FindByCondition(c => c.Id.Equals(patientId), trackChanges).Result.SingleOrDefaultAsync();

        public async Task DeletePatient(Patient patient) => await Remove(patient);
    }
}
