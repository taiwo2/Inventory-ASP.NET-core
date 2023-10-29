using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inventory.Model;
namespace inventory.Service.IService
{
    public interface IPatientServices
    {
    public Task<Patient> CreatePatient(Patient patient);
    public Task<Patient> GetPatientById(int id);
    public Task<List<Patient>> GetAllPatients();
    public Task<Patient> UpdatePatient(int id, Patient updatedPatient);
    public Task<int> DeletePatient(int id);
    }
}