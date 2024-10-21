using EMRSimulation.Application.Services;
using EMRSimulation.Domain.Dtos;
using EMRSimulationWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Emit;

namespace EMRSimulation.WebApp.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public async Task<IActionResult> GetPatientList(int labId)
        {
            IEnumerable<PatientDto> lstPatients;

            lstPatients = await _patientService.GetAllPatientsAsync(labId);
            return PartialView("~/views/patient/_patientList.cshtml", lstPatients);
        }

        public async Task<IActionResult> GetPatientRecord(int labId, int patientId)
        {
            PatientDto patient;

            patient = await _patientService.GetPatientById(patientId, labId);
            return PartialView("~/views/patient/_patientRecord.cshtml", patient);
        }

        public async Task<IActionResult> GetPatientADDS(int labId, int patientId)
        {
            PatientDto patient;

            patient = await _patientService.GetPatientById(patientId, labId);
            return PartialView("~/views/patient/_patientAddsChart.cshtml", patient);
        }

        public async Task<IActionResult> GetPatientIvFluidChartList(int labId, int patientId)
        {
            PatientIvFluidChartViewModel patientIvFluidChartViewModel = new PatientIvFluidChartViewModel();
            
            IEnumerable<IvFluidChartDto> lstIvFluidChartDto;

            lstIvFluidChartDto = await _patientService.GetIvFluidChartAsync(labId, patientId);
            patientIvFluidChartViewModel.ivFluidChartDtoList = lstIvFluidChartDto;

            
            return PartialView("~/views/patient/_patientIvFluidChartList.cshtml", patientIvFluidChartViewModel);
        }

        public async Task<IActionResult> GetPatientIvFluidChart(int Id, int labId, int patientId)
        {
            PatientDto patient;
            patient = await _patientService.GetPatientById(patientId, labId);

            PatientIvFluidChartViewModel patientIvFluidChartViewModel = new PatientIvFluidChartViewModel();
            patientIvFluidChartViewModel.patientDto = patient;

            IvFluidChartDto lstIvFluidChartDto;

            lstIvFluidChartDto = await _patientService.GetIvFluidChartByIdAsync(Id, labId);
            patientIvFluidChartViewModel.ivFluidChartDto = lstIvFluidChartDto;

            return PartialView("~/views/patient/_patientIvFluidChart.cshtml", patientIvFluidChartViewModel);
        }

        public async Task<IActionResult> AddPatientADDS([FromBody] AddsDto addsDto)
        {
            int result = await _patientService.AddPatientAddsAsync(addsDto);
            return Ok(result);
        }

        public async Task<IActionResult> AddPatientIvFluidAdministration([FromBody] IvFluidAdministrationDto addsDto)
        {
            int result = await _patientService.AddPatientIvFluidAdministrationAsync(addsDto);
            return Ok(result);
        }

        public async Task<IActionResult> GetIvFluidAdministration(int labId, int patientId, int ivFluidChartId)
        {
            IEnumerable<IvFluidAdministrationDto> lstPatients;

            lstPatients = await _patientService.GetIvFluidAdministrationAsync(labId, patientId, ivFluidChartId);

            return PartialView("~/views/patient/_patientIvFluidChartAdminList.cshtml", lstPatients);
        }

        public async Task<IActionResult> DeleteIvFluidAdministration(int Id)
        {
            int result = await _patientService.DeleteIvFluidAdministrationAsync(Id);
            return Ok(result);
        }

        public async Task<IActionResult> GetPatientADDSList(int labId, int patientId)
        {
            PatientAddsListViewModel patientAddsListViewModel = new PatientAddsListViewModel();
            
            IEnumerable<AddsDto> lstAddsDto;
            lstAddsDto = await _patientService.GetPatientAdds(labId, patientId);

            patientAddsListViewModel.AddsDtoList = lstAddsDto;

            return PartialView("~/views/patient/_patientAddsChartList.cshtml", patientAddsListViewModel);
        }

        public async Task<IActionResult> DeletePatientADDS(int Id)
        {
            int result = await _patientService.DeletePatientAddsAsync(Id);
            return Ok(result);
        }

        public async Task<IActionResult> GetPatientMedicationPrnList(int labId, int patientId)
        {
            PatientMedicationPrnListViewModel patientMedicationPrnListViewModel = new PatientMedicationPrnListViewModel();
            
            IEnumerable<MedicationPrnChartDto> lstMedicationPrnChartDto;
            lstMedicationPrnChartDto = await _patientService.GetMedicationPrnChartAsync(labId, patientId);

            patientMedicationPrnListViewModel.MedicationPrnChartDtoList = lstMedicationPrnChartDto;

            return PartialView("~/views/patient/_patientMedicationPrnList.cshtml", patientMedicationPrnListViewModel);
        }

        public async Task<IActionResult> GetPatientMedicationPrn(int Id, int labId, int patientId)
        {
            PatientDto patient;
            patient = await _patientService.GetPatientById(patientId, labId);

            PatientMedicationPrnListViewModel patientMedicationPrnListViewModel = new PatientMedicationPrnListViewModel();
            patientMedicationPrnListViewModel.patientDto = patient;

            MedicationPrnChartDto lstMedicationPrnChartDto;
            lstMedicationPrnChartDto = await _patientService.GetMedicationPrnChartByIdAsync(Id, labId);

            patientMedicationPrnListViewModel.MedicationPrnChartDto = lstMedicationPrnChartDto;

            return PartialView("~/views/patient/_patientMedicationPrn.cshtml", patientMedicationPrnListViewModel);
        }

        public async Task<IActionResult> AddPatientMedicationPrnAdministration([FromBody] MedicationAdministrationPrnDto addsDto)
        {
            int result = await _patientService.AddPatientMedicationPrnAdministrationAsync(addsDto);
            return Ok(result);
        }

        public async Task<IActionResult> GetPatientMedicationPrnAdministration(int labId, int patientId, int patientMedicationChartId)
        {
            IEnumerable<MedicationAdministrationPrnDto> lstPatients;

            lstPatients = await _patientService.GetPatientMedicationPrnAdministrationAsync(labId, patientId, patientMedicationChartId);

            return PartialView("~/views/patient/_patientMedicationPrnAdminList.cshtml", lstPatients);
        }

        public async Task<IActionResult> DeletePatientMedicationPrnAdministration(int Id)
        {
            int result = await _patientService.DeleteMedicationPrnAdministrationAsync(Id);
            return Ok(result);
        }

        public async Task<IActionResult> GetPatientMedicationRegularList(int labId, int patientId)
        {
            PatientMedicationRegularListViewModel patientMedicationRegularListViewModel = new PatientMedicationRegularListViewModel();
            
            IEnumerable<MedicationRegularChartDto> lstMedicationRegularChartDto;
            lstMedicationRegularChartDto = await _patientService.GetMedicationRegularChartAsync(labId, patientId);

            patientMedicationRegularListViewModel.MedicationRegularChartDtoList = lstMedicationRegularChartDto;

            return PartialView("~/views/patient/_patientMedicationRegularList.cshtml", patientMedicationRegularListViewModel);
        }

        public async Task<IActionResult> GetPatientMedicationRegular(int Id, int labId, int patientId)
        {
            PatientDto patient;
            patient = await _patientService.GetPatientById(patientId, labId);

            PatientMedicationRegularListViewModel patientMedicationRegularListViewModel = new PatientMedicationRegularListViewModel();
            patientMedicationRegularListViewModel.patientDto = patient;

            MedicationRegularChartDto lstMedicationRegularChartDto;
            lstMedicationRegularChartDto = await _patientService.GetMedicationRegularChartByIdAsync(Id, labId);

            patientMedicationRegularListViewModel.MedicationRegularChartDto = lstMedicationRegularChartDto;

            return PartialView("~/views/patient/_patientMedicationRegular.cshtml", patientMedicationRegularListViewModel);
        }

        public async Task<IActionResult> AddPatientMedicationRegularAdministration([FromBody] MedicationAdministrationRegularDto addsDto)
        {
            int result = await _patientService.AddPatientMedicationRegularAdministrationAsync(addsDto);
            return Ok(result);
        }

        public async Task<IActionResult> GetPatientMedicationRegularAdministration(int labId, int patientId, int patientMedicationChartId)
        {
            IEnumerable<MedicationAdministrationRegularDto> lstPatients;

            lstPatients = await _patientService.GetPatientMedicationRegularAdministrationAsync(labId, patientId, patientMedicationChartId);

            return PartialView("~/views/patient/_patientMedicationRegularAdminList.cshtml", lstPatients);
        }

        public async Task<IActionResult> DeletePatientMedicationRegularAdministration(int Id)
        {
            int result = await _patientService.DeleteMedicationRegularAdministrationAsync(Id);
            return Ok(result);
        }

        public async Task<IActionResult> GetProgressNoteList(int labId, int patientId)
        {
            IEnumerable<ProgressNotesDto> lstPatients;

            lstPatients = await _patientService.GetProgressNotesAsync(labId, patientId);
            return PartialView("~/views/patient/_patientProgressNoteList.cshtml", lstPatients);
        }

        public async Task <IActionResult> GetProgressNote()
        {   
            return PartialView("~/views/patient/_patientProgressNote.cshtml");
        }

        public async Task<IActionResult> AddProgressNote([FromBody] ProgressNotesDto addsDto)
        {
            int result = await _patientService.AddProgressNotesAsync(addsDto);
            return Ok(result);
        }

        public async Task<IActionResult> DeleteProgressNote(int Id)
        {
            int result = await _patientService.DeleteProgressNotesAsync(Id);
            return Ok(result);
        }

    }

}
