using EMRSimulation.Application.Services;
using EMRSimulation.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EMRSimulationWebApp.Controllers
{
    public class SupervisorController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly ILabService _LabService;
        public SupervisorController(IPatientService patientService, ILabService LabService)
        {
            _patientService = patientService;
            _LabService = LabService;
        }

        public async Task<IActionResult> GetMemberOrder()
        {
            return PartialView("~/views/patient/_patientIvFluidChartAdd.cshtml");
        }

        public async Task<IActionResult> AddIvFluidChart([FromBody] IvFluidChartDto addsDto)
        {
            if (addsDto == null)
            {
                return BadRequest("Patient ADDS data is required.");
            }

            try
            {
                var newId = await _patientService.AddIvFluidChartsync(addsDto);
                return Ok(newId);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while adding the patient adds." + ex);
            }
        }

        public async Task<IActionResult> GetMedicationPrn(int labId)
        {
            var medications = await _patientService.GetMedicationAsync(labId);

            return PartialView("~/views/patient/_patientMedicationPrnAdd.cshtml", medications);
        }

        public async Task<IActionResult> AddMedicationPrnChart([FromBody] MedicationPrnChartDto addsDto)
        {
            if (addsDto == null)
            {
                return BadRequest("Patient ADDS data is required.");
            }

            try
            {
                var newId = await _patientService.AddMedicationPrnChartAsync(addsDto);
                return Ok(newId);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while adding the patient adds." + ex);
            }
        }

        public async Task<IActionResult> GetMedicationRegular(int labId)
        {
            var medications = await _patientService.GetMedicationAsync(labId);
            return PartialView("~/views/patient/_patientMedicationRegularAdd.cshtml", medications);
        }

        public async Task<IActionResult> AddMedicationRegularChart([FromBody] MedicationRegularChartDto addsDto)
        {
            if (addsDto == null)
            {
                return BadRequest("Patient ADDS data is required.");
            }

            try
            {
                var newId = await _patientService.AddMedicationRegularChartAsync(addsDto);
                return Ok(newId);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while adding the patient adds." + ex);
            }
        }

        public async Task<IActionResult> GetSupervisorPatientList(int labId)
        {
            IEnumerable<PatientDto> lstPatients;

            lstPatients = await _patientService.GetAllPatientsAsync(labId);
            return PartialView("~/views/patient/_supervisorPatientList.cshtml", lstPatients);
        }

        public async Task<IActionResult> ClearPatientData(int labId, int patientId)
        {
            try
            {
                var clearedData = await _patientService.ClearPatientDataAsync(labId, patientId);
                return Ok(clearedData);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while delete the Patient data." + ex);
            }
        }

        public async Task<IActionResult> ClearLabData(int labId)
        {
            try
            {
                var clearedData = await _patientService.ClearLabDataAsync(labId);
                return Ok(clearedData);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while delete the Patient data." + ex);
            }
        }

        public async Task<IActionResult> GetSupervisorLabList(int labId)
        {
            LabDto Lab;

            Lab = await _LabService.GetLabById(labId);

            return PartialView("~/views/patient/_supervisorLabList.cshtml", Lab);
        }

        public async Task<IActionResult> GetPatient()
        {
            return PartialView("~/views/patient/_patientAdd.cshtml");
        }

        public async Task<IActionResult> AddPatient([FromBody] PatientDto addsDto)
        {
            if (addsDto == null)
            {
                return BadRequest("Patient data is required.");
            }

            try
            {
                var newId = await _patientService.AddPatientAsync(addsDto);
                return Ok(newId);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while adding the patient adds." + ex);
            }
        }

        public async Task<IActionResult> DeletePatient(int labId, int Id)
        {
            int result = await _patientService.DeletePatientAsync(labId, Id);
            return Ok(result);
        }

        public async Task<IActionResult> GetMedication()
        {
            return PartialView("~/views/patient/_medicationAdd.cshtml");
        }

        public async Task<IActionResult> AddMedication([FromBody] MedicationDto addsDto)
        {
            if (addsDto == null)
            {
                return BadRequest("Medication data is required.");
            }

            try
            {
                var newId = await _patientService.AddMedicationAsync(addsDto);
                return Ok(newId);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while adding the patient adds." + ex);
            }
        }
    }
}
