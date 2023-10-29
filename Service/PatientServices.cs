using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inventory.Service.IService;
using inventory.Model;
using inventory.Data;
namespace inventory.Service
{
   public class PatientServices : IPatientServices
   {
        private readonly SQLiteDbContext _dbContext;

        public PatientServices(SQLiteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Patient> CreatePatient(Patient patient)
        {
            _dbContext.Patients.Add(patient);
            _dbContext.SaveChangesAsync();
            return patient;
        }

        public async Task<Patient> GetPatientById(int id)
        {
            return _dbContext.Patients.FirstOrDefault(p => p.Id == id);
        }

        public async Task<List<Patient>> GetAllPatients()
        {
            return _dbContext.Patients.ToList();
        }

        public async Task<Patient> UpdatePatient(int id, Patient updatedPatient)
        {
            var existingPatient = _dbContext.Patients.Find(id);
            if (existingPatient != null)
            {
                existingPatient.Name = updatedPatient.Name;
                existingPatient.Age = updatedPatient.Age;
                _dbContext.SaveChangesAsync();
            }
            return existingPatient;
        }

        public async Task<int> DeletePatient(int id)
        {
            var patientToDelete = _dbContext.Patients.Find(id);
            if (patientToDelete != null)
            {
                _dbContext.Patients.Remove(patientToDelete);
                _dbContext.SaveChangesAsync();
            }
            return 0;
        }
    }

}

