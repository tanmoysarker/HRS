﻿using EMRSimulation.Domain.Dtos;

namespace EMRSimulation.Application.Services
{
    public interface IPatientService
    {
        Task<PatientDto> GetPatientById(int Id, int labId);
        Task<IEnumerable<PatientDto>> GetAllPatientsAsync(int labId);
        Task<int> AddPatientAsync(PatientDto addsDto);
        Task<IEnumerable<AddsDto>> GetPatientAdds(int labId, int patientId);
        Task<int> AddPatientAddsAsync(AddsDto addsDto);
        
        Task<int> AddMedicationPrnChartAsync(MedicationPrnChartDto addsDto);
        Task<int> AddPatientMedicationPrnAdministrationAsync(MedicationAdministrationPrnDto addsDto);
        Task<IEnumerable<MedicationPrnChartDto>> GetMedicationPrnChartAsync(int labId, int patientId);
        Task<IEnumerable<MedicationAdministrationPrnDto>> GetPatientMedicationPrnAdministrationAsync(int labId, int patientId, int patientMedicationChartId);

        Task<int> DeletePatientAsync(int labId, int Id);
        Task<int> DeletePatientAddsAsync(int Id);
        Task<int> DeleteMedicationPrnChartAsync(int Id);
        Task<int> DeleteMedicationPrnAdministrationAsync(int Id);

        Task<int> AddMedicationRegularChartAsync(MedicationRegularChartDto addsDto);
        Task<int> AddPatientMedicationRegularAdministrationAsync(MedicationAdministrationRegularDto addsDto);
        Task<IEnumerable<MedicationRegularChartDto>> GetMedicationRegularChartAsync(int labId, int patientId);
        Task<IEnumerable<MedicationAdministrationRegularDto>> GetPatientMedicationRegularAdministrationAsync(int labId, int patientId, int patientMedicationChartId);
        Task<int> DeleteMedicationRegularChartAsync(int Id);
        Task<int> DeleteMedicationRegularAdministrationAsync(int Id);

        Task<IvFluidChartDto> GetIvFluidChartByIdAsync(int Id, int labId);
        Task<IEnumerable<IvFluidChartDto>> GetIvFluidChartAsync(int labId, int patientId);
        Task<IEnumerable<IvFluidAdministrationDto>> GetIvFluidAdministrationAsync(int labId, int patientId, int ivFluidChartId);
        Task<int> AddPatientIvFluidAdministrationAsync(IvFluidAdministrationDto addsDto);
        Task<int> DeleteIvFluidChartAsync(int Id);
        Task<int> DeleteIvFluidAdministrationAsync(int Id);
        Task<int> AddIvFluidChartsync(IvFluidChartDto addsDto);
        Task<IEnumerable<MedicationDto>> GetMedicationAsync(int labId);
        Task<int> AddMedicationAsync(MedicationDto addsDto);

        Task<int> AddProgressNotesAsync(ProgressNotesDto addsDto);
        Task<IEnumerable<ProgressNotesDto>> GetProgressNotesAsync(int labId, int patientId);
        Task<int> DeleteProgressNotesAsync(int Id);

        Task<MedicationPrnChartDto> GetMedicationPrnChartByIdAsync(int Id, int labId);
        Task<MedicationRegularChartDto> GetMedicationRegularChartByIdAsync(int Id, int labId);
        Task<IEnumerable<ClearDataDto>> ClearPatientDataAsync(int labId, int patientId);
        Task<IEnumerable<ClearDataDto>> ClearLabDataAsync(int labId);
    }
}
