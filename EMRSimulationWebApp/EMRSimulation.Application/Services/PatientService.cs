using EMRSimulation.Application.Interfaces;
using EMRSimulation.Domain.Dtos;

namespace EMRSimulation.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        { 
            _patientRepository = patientRepository;
        }

        public async Task<int> AddPatientAddsAsync(AddsDto addsDto)
        {
            // Assuming the repository method is asynchronous
            return await _patientRepository.AddPatientAddsAsync(addsDto);
        }

        public async Task<IEnumerable<PatientDto>> GetAllPatientsAsync(int labId)
        {
            return await _patientRepository.GetAllPatientsAsync(labId);
        }

        public async Task<IEnumerable<AddsDto>> GetPatientAdds(int labId, int patientId)
        {
            return await _patientRepository.GetPatientAdds(labId, patientId);
        }

        public async Task<PatientDto> GetPatientById(int Id, int labId)
        {
            return await _patientRepository.GetPatientById(Id, labId);
        }

        public async Task<int> AddPatientMedicationPrnAdministrationAsync(MedicationAdministrationPrnDto addsDto)
        {
            return await _patientRepository.AddPatientMedicationPrnAdministrationAsync(addsDto);
        }

        public async Task<IEnumerable<MedicationAdministrationPrnDto>> GetPatientMedicationPrnAdministrationAsync(int labId, int patientId, int patientMedicationChartId)
        {
            return await _patientRepository.GetPatientMedicationPrnAdministrationAsync(labId, patientId, patientMedicationChartId);
        }

        public async Task<IEnumerable<MedicationPrnChartDto>> GetMedicationPrnChartAsync(int labId, int patientId)
        {
            return await _patientRepository.GetMedicationPrnChartAsync(labId, patientId);
        }

        public async Task<IEnumerable<IvFluidChartDto>> GetIvFluidChartAsync(int labId, int patientId)
        {
            return await _patientRepository.GetIvFluidChartAsync(labId, patientId);
        }

        public async Task<IEnumerable<IvFluidAdministrationDto>> GetIvFluidAdministrationAsync(int labId, int patientId, int ivFluidChartId)
        {
            return await _patientRepository.GetIvFluidAdministrationAsync(labId, patientId, ivFluidChartId);
        }

        public async Task<int> AddPatientIvFluidAdministrationAsync(IvFluidAdministrationDto addsDto)
        {
            return await _patientRepository.AddPatientIvFluidAdministrationAsync(addsDto);
        }

        public async Task<int> DeletePatientAddsAsync(int Id)
        {
            return await _patientRepository.DeletePatientAddsAsync(Id);
        }

        public async Task<int> DeleteIvFluidChartAsync(int Id)
        {
            return await _patientRepository.DeleteIvFluidChartAsync(Id);
        }

        public async Task<int> DeleteIvFluidAdministrationAsync(int Id)
        {
            return await _patientRepository.DeleteIvFluidAdministrationAsync(Id);
        }

        public async Task<int> DeleteMedicationPrnChartAsync(int Id)
        {
            return await _patientRepository.DeleteMedicationPrnChartAsync(Id);
        }

        public async Task<int> DeleteMedicationPrnAdministrationAsync(int Id)
        {
            return await _patientRepository.DeleteMedicationPrnAdministrationAsync(Id);
        }

        public async Task<int> AddIvFluidChartsync(IvFluidChartDto addsDto)
        {
            return await _patientRepository.AddIvFluidChartsync(addsDto);
        }

        public async Task<int> AddMedicationPrnChartAsync(MedicationPrnChartDto addsDto)
        {
            return await _patientRepository.AddMedicationPrnChartAsync(addsDto);
        }

        public async Task<IEnumerable<MedicationDto>> GetMedicationAsync(int labId)
        {
            return await _patientRepository.GetMedicationAsync(labId);
        }

        public async Task<int> AddMedicationAsync(MedicationDto addsDto)
        {
            return await _patientRepository.AddMedicationAsync(addsDto);
        }

        public async Task<int> AddMedicationRegularChartAsync(MedicationRegularChartDto addsDto)
        {
            return await _patientRepository.AddMedicationRegularChartAsync(addsDto);
        }

        public async Task<int> AddPatientMedicationRegularAdministrationAsync(MedicationAdministrationRegularDto addsDto)
        {
            return await _patientRepository.AddPatientMedicationRegularAdministrationAsync(addsDto);
        }

        public async Task<IEnumerable<MedicationRegularChartDto>> GetMedicationRegularChartAsync(int labId, int patientId)
        {
            return await _patientRepository.GetMedicationRegularChartAsync(labId, patientId);
        }

        public async Task<IEnumerable<MedicationAdministrationRegularDto>> GetPatientMedicationRegularAdministrationAsync(int labId, int patientId, int patientMedicationChartId)
        {
            return await _patientRepository.GetPatientMedicationRegularAdministrationAsync(labId, patientId, patientMedicationChartId);
        }

        public async Task<int> DeleteMedicationRegularChartAsync(int Id)
        {
            return await _patientRepository.DeleteMedicationRegularChartAsync(Id);
        }

        public async Task<int> DeleteMedicationRegularAdministrationAsync(int Id)
        {
            return await _patientRepository.DeleteMedicationRegularAdministrationAsync(Id);
        }

        public async Task<int> AddProgressNotesAsync(ProgressNotesDto addsDto)
        {
            return await _patientRepository.AddProgressNotesAsync(addsDto);
        }

        public async Task<int> DeleteProgressNotesAsync(int Id)
        {
            return await _patientRepository.DeleteProgressNotesAsync(Id);
        }

        public async Task<IEnumerable<ProgressNotesDto>> GetProgressNotesAsync(int labId, int patientId)
        {
            return await _patientRepository.GetProgressNotesAsync(labId, patientId);
        }

        public async Task<IvFluidChartDto> GetIvFluidChartByIdAsync(int Id, int labId)
        {
            return await _patientRepository.GetIvFluidChartByIdAsync(Id, labId);
        }

        public async Task<MedicationPrnChartDto> GetMedicationPrnChartByIdAsync(int Id, int labId)
        {
            return await _patientRepository.GetMedicationPrnChartByIdAsync(Id, labId);
        }

        public async Task<MedicationRegularChartDto> GetMedicationRegularChartByIdAsync(int Id, int labId)
        {
            return await _patientRepository.GetMedicationRegularChartByIdAsync(Id, labId);
        }

        public async Task<int> AddPatientAsync(PatientDto addsDto)
        {
            return await _patientRepository.AddPatientAsync(addsDto);
        }

        public async Task<IEnumerable<ClearDataDto>> ClearPatientDataAsync(int labId, int patientId)
        {
            return await _patientRepository.ClearPatientDataAsync(labId, patientId);
        }

        public async Task<IEnumerable<ClearDataDto>> ClearLabDataAsync(int labId)
        {
            return await _patientRepository.ClearLabDataAsync(labId);
        }

        public async Task<int> DeletePatientAsync(int labId, int Id)
        {
            return await _patientRepository.DeletePatientAsync(labId, Id);
        }
    }
}
