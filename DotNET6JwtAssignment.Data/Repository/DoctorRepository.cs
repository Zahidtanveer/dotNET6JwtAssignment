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
    public class DoctorRepository : BaseRepositroy<Doctor>, IDoctorRepository
    {
        public DoctorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task CreateDoctor(Doctor doctor) => await Create(doctor);

        public async Task<IEnumerable<Doctor>> GetAllDoctors(bool trackChanges) => await FindAll(trackChanges).Result.OrderBy(c => c.Name).ToListAsync();

        public async Task<Doctor> GetDoctor(Guid doctorId, bool trackChanges)
        {
            return await FindByCondition(c => c.Id.Equals(doctorId), trackChanges).Result.SingleOrDefaultAsync();
        }
        public async Task DeleteDoctor(Doctor doctor) => await Remove(doctor);
    }
}
