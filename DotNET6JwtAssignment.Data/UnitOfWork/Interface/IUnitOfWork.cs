using DotNET6JwtAssignment.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNET6JwtAssignment.Data.UnitOfWork.Interface
{
    public interface IUnitOfWork
    {
        IDoctorRepository Doctor { get; }
        IPatientRepository Patient { get; }
        IVisitRepository Visit { get; }
        IUserAuthRepository UserAuth { get; }
        Task Save();
    }
}
