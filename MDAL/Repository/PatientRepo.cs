using AutoMapper;
using MAEntities.Context;
using MAEntities.DTO;
using MDAL.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDAL.Repository
{
    public class PatientRepo : IPatientRepo
    {
        private readonly MedContext _context;
        private readonly IMapper _mapper;

        public PatientRepo(MedContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PatientDto>> GetAllPatients()
        {
            var patients = await _context.Patients.ToListAsync();
            return _mapper.Map<List<PatientDto>>(patients);
        }

        public async Task<PatientDto> GetPatientById(int patientId)
        {
            var patient = await _context.Patients.FindAsync(patientId);
            return _mapper.Map<PatientDto>(patient);
        }

        public async Task UpdatePatient(int patientId, PatientDto patientDto)
        {
            var existingPatient = await _context.Patients.FindAsync(patientId);
            if (existingPatient == null)
            {
                throw new Exception($"Patient not found. Update failed.");
            }

            _mapper.Map(patientDto, existingPatient);

            await _context.SaveChangesAsync();
        }
    }
}
