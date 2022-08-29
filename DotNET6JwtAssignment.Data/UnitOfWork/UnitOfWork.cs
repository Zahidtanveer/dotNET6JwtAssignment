using AutoMapper;
using DotNET6JwtAssignment.Common.Models;
using DotNET6JwtAssignment.Data.Repository;
using DotNET6JwtAssignment.Data.Repository.Interface;
using DotNET6JwtAssignment.Data.UnitOfWork.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNET6JwtAssignment.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _dbContext;

        private IUserAuthRepository _userAuthRepository;
        private IDoctorRepository _doctorRepository;
        private IPatientRepository _patientRepository;
        private IVisitRepository _visitRepository;
        private UserManager<User> _userManager;
        private IMapper _mapper;
        private IConfiguration _configuration;

        public UnitOfWork(ApplicationDbContext dbContext, UserManager<User> userManager, IMapper mapper, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _mapper = mapper;
            _configuration = configuration;
        }

        public IUserAuthRepository UserAuth
        {
            get
            {
                if (_userAuthRepository is null)
                    _userAuthRepository = new UserAuthRepository(_userManager, _configuration, _mapper);
                return _userAuthRepository;
            }
        }


        public IDoctorRepository Doctor
        {
            get
            {
                if (_doctorRepository is null)
                    _doctorRepository = new DoctorRepository(_dbContext);
                return _doctorRepository;
            }
        }
        public IPatientRepository Patient
        {
            get
            {
                if (_patientRepository is null)
                    _patientRepository = new PatientRepository(_dbContext);
                return _patientRepository;
            }
        }

        public IVisitRepository Visit
        {
            get
            {
                if (_visitRepository is null)
                    _visitRepository = new VisitRepository(_dbContext);
                return _visitRepository;
            }
        }

        public Task Save()
        {
           return _dbContext.SaveChangesAsync();
        }
    }
}
