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
    public class VisitRepository : BaseRepositroy<Visit>, IVisitRepository 
    {
        public VisitRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public Task CreateVisit(Visit visit) => Create(visit);

        public async Task<IEnumerable<Visit>> GetAllVisits(bool trackChanges)=> await FindAll(trackChanges).Result.OrderBy(c => c.VisitDate).ToListAsync();

        public async Task<Visit> GetVisit(Guid visitId, bool trackChanges) => await FindByCondition(c => c.Id.Equals(visitId), trackChanges).Result.SingleOrDefaultAsync();
        public async Task DeleteVisit(Visit visit) => await Remove(visit);
    }
}
