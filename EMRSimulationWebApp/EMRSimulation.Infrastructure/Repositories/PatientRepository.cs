using EMRSimulation.Application.Interfaces;
using EMRSimulation.Domain.Dtos;
using EMRSimulation.Infrastructure.Connection;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EMRSimulation.Infrastructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public PatientRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<PatientDto> GetPatientById(int Id, int labId)
        {
            var patient = new PatientDto();

            // Create and open the database connection using the connection factory
            using (var connection = await _dbConnectionFactory.CreateAsync())
            {
                // Ensure we're working with SqlCommand for asynchronous operations
                using (var command = (SqlCommand)connection.CreateCommand())
                {
                    command.CommandText = "GetPatient"; // Assuming stored procedure name is GetPatients
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters to the command
                    command.Parameters.Add(new SqlParameter("@Id", Id));
                    command.Parameters.Add(new SqlParameter("@LabId", labId));

                    // Execute the stored procedure and read the results asynchronously
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {

                            patient.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            patient.LabId = reader.GetInt32(reader.GetOrdinal("LabId"));
                            patient.FirstName = reader.IsDBNull(reader.GetOrdinal("FirstName")) ? null : reader.GetString(reader.GetOrdinal("FirstName"));
                            patient.LastName = reader.IsDBNull(reader.GetOrdinal("LastName")) ? null : reader.GetString(reader.GetOrdinal("LastName"));
                            patient.DateOfBirth = reader.GetDateTime(reader.GetOrdinal("DateOfBirth"));
                            patient.Gender = reader.IsDBNull(reader.GetOrdinal("Gender")) ? null : reader.GetString(reader.GetOrdinal("Gender"));
                            patient.Address = reader.IsDBNull(reader.GetOrdinal("Address")) ? null : reader.GetString(reader.GetOrdinal("Address"));
                            patient.AdmitDate = reader.GetDateTime(reader.GetOrdinal("AdmitDate"));
                            patient.Weight = reader.IsDBNull(reader.GetOrdinal("Weight")) ? null : reader.GetString(reader.GetOrdinal("Weight"));
                            patient.Height = reader.IsDBNull(reader.GetOrdinal("Height")) ? null : reader.GetString(reader.GetOrdinal("Height"));
                            patient.Age = reader.IsDBNull(reader.GetOrdinal("Age")) ? null : reader.GetString(reader.GetOrdinal("Age"));
                            patient.Allergy = reader.IsDBNull(reader.GetOrdinal("Allergy")) ? null : reader.GetString(reader.GetOrdinal("Allergy"));
                            patient.Intolerance = reader.IsDBNull(reader.GetOrdinal("Intolerance")) ? null : reader.GetString(reader.GetOrdinal("Intolerance"));
                            patient.Alerts = reader.IsDBNull(reader.GetOrdinal("Alerts")) ? null : reader.GetString(reader.GetOrdinal("Alerts"));
                            patient.UriNumber = reader.IsDBNull(reader.GetOrdinal("UriNumber")) ? null : reader.GetString(reader.GetOrdinal("UriNumber"));
                            patient.Alert = reader.IsDBNull(reader.GetOrdinal("Alert")) ? null : reader.GetInt32(reader.GetOrdinal("Alert"));
                        }
                    }
                }
            }

            return patient;
        }
        public async Task<IEnumerable<PatientDto>> GetAllPatientsAsync(int labId)
        {
            var patients = new List<PatientDto>();

            // Create and open the database connection using the connection factory
            using (var connection = await _dbConnectionFactory.CreateAsync())
            {
                // Ensure we're working with SqlCommand for asynchronous operations
                using (var command = (SqlCommand)connection.CreateCommand())
                {
                    command.CommandText = "GetPatient"; // Assuming stored procedure name is GetPatients
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters to the command
                    command.Parameters.Add(new SqlParameter("@LabId", labId));

                    // Execute the stored procedure and read the results asynchronously
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var patient = new PatientDto
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                LabId = reader.GetInt32(reader.GetOrdinal("LabId")),
                                FirstName = reader.IsDBNull(reader.GetOrdinal("FirstName")) ? null : reader.GetString(reader.GetOrdinal("FirstName")),
                                LastName = reader.IsDBNull(reader.GetOrdinal("LastName")) ? null : reader.GetString(reader.GetOrdinal("LastName")),
                                DateOfBirth = reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                                Gender = reader.IsDBNull(reader.GetOrdinal("Gender")) ? null : reader.GetString(reader.GetOrdinal("Gender")),
                                Address = reader.IsDBNull(reader.GetOrdinal("Address")) ? null : reader.GetString(reader.GetOrdinal("Address")),
                                AdmitDate = reader.GetDateTime(reader.GetOrdinal("AdmitDate")),
                                Weight = reader.IsDBNull(reader.GetOrdinal("Weight")) ? null : reader.GetString(reader.GetOrdinal("Weight")),
                                Height = reader.IsDBNull(reader.GetOrdinal("Height")) ? null : reader.GetString(reader.GetOrdinal("Height")),
                                Age = reader.IsDBNull(reader.GetOrdinal("Age")) ? null : reader.GetString(reader.GetOrdinal("Age")),
                                Allergy = reader.IsDBNull(reader.GetOrdinal("Allergy")) ? null : reader.GetString(reader.GetOrdinal("Allergy")),
                                Intolerance = reader.IsDBNull(reader.GetOrdinal("Intolerance")) ? null : reader.GetString(reader.GetOrdinal("Intolerance")),
                                Alerts = reader.IsDBNull(reader.GetOrdinal("Alerts")) ? null : reader.GetString(reader.GetOrdinal("Alerts")),
                                UriNumber = reader.IsDBNull(reader.GetOrdinal("UriNumber")) ? null : reader.GetString(reader.GetOrdinal("UriNumber")),
                                Alert = reader.IsDBNull(reader.GetOrdinal("Alert")) ? null : reader.GetInt32(reader.GetOrdinal("Alert"))
                            };

                            patients.Add(patient);
                        }
                    }
                }
            }

            return patients;
        }

        public async Task<IEnumerable<AddsDto>> GetPatientAdds(int labId, int patientId)
        {
            var patients = new List<AddsDto>();

            // Create and open the database connection using the connection factory
            using (var connection = await _dbConnectionFactory.CreateAsync())
            {
                // Ensure we're working with SqlCommand for asynchronous operations
                using (var command = (SqlCommand)connection.CreateCommand())
                {
                    command.CommandText = "GetPatientAdds"; // Assuming stored procedure name is GetPatients
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters to the command
                    command.Parameters.Add(new SqlParameter("@LabId", labId));
                    command.Parameters.Add(new SqlParameter("@PatientId", patientId));

                    // Execute the stored procedure and read the results asynchronously
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var patient = new AddsDto
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                LabId = reader.GetInt32(reader.GetOrdinal("LabId")),
                                PatientId = reader.GetInt32(reader.GetOrdinal("PatientId")),
                                RespiratoryRate = reader.IsDBNull(reader.GetOrdinal("RespiratoryRate")) ? null : reader.GetString(reader.GetOrdinal("RespiratoryRate")),
                                HeartRate = reader.IsDBNull(reader.GetOrdinal("HeartRate")) ? null : reader.GetString(reader.GetOrdinal("HeartRate")),
                                Temperature = reader.IsDBNull(reader.GetOrdinal("Temperature")) ? null : reader.GetString(reader.GetOrdinal("Temperature")),
                                Consciousness = reader.IsDBNull(reader.GetOrdinal("Consciousness")) ? null : reader.GetString(reader.GetOrdinal("Consciousness")),
                                OxygenSaturation = reader.IsDBNull(reader.GetOrdinal("OxygenSaturation")) ? null : reader.GetString(reader.GetOrdinal("OxygenSaturation")),
                                OxygenFlow = reader.IsDBNull(reader.GetOrdinal("OxygenFlow")) ? null : reader.GetString(reader.GetOrdinal("OxygenFlow")),
                                BloodPressure = reader.IsDBNull(reader.GetOrdinal("BloodPressure")) ? null : reader.GetString(reader.GetOrdinal("BloodPressure")),

                                RespiratoryRateValue = reader.IsDBNull(reader.GetOrdinal("RespiratoryRateValue")) ? null : reader.GetInt32(reader.GetOrdinal("RespiratoryRateValue")),
                                OxygenSaturationValue = reader.IsDBNull(reader.GetOrdinal("OxygenSaturationValue")) ? null : reader.GetInt32(reader.GetOrdinal("OxygenSaturationValue")),
                                BloodPressureValue = reader.IsDBNull(reader.GetOrdinal("BloodPressureValue")) ? null : reader.GetInt32(reader.GetOrdinal("BloodPressureValue")),
                                HeartRateValue = reader.IsDBNull(reader.GetOrdinal("HeartRateValue")) ? null : reader.GetInt32(reader.GetOrdinal("HeartRateValue")),
                                TemperatureValue = reader.IsDBNull(reader.GetOrdinal("TemperatureValue")) ? null : reader.GetInt32(reader.GetOrdinal("TemperatureValue")),
                                RespiratoryAlert = reader.IsDBNull(reader.GetOrdinal("RespiratoryAlert")) ? null : reader.GetInt32(reader.GetOrdinal("RespiratoryAlert")),
                                OxygenSaturationAlert = reader.IsDBNull(reader.GetOrdinal("OxygenSaturationAlert")) ? null : reader.GetInt32(reader.GetOrdinal("OxygenSaturationAlert")),
                                BloodPressureAlert = reader.IsDBNull(reader.GetOrdinal("BloodPressureAlert")) ? null : reader.GetInt32(reader.GetOrdinal("BloodPressureAlert")),
                                HeartRateAlert = reader.IsDBNull(reader.GetOrdinal("HeartRateAlert")) ? null : reader.GetInt32(reader.GetOrdinal("HeartRateAlert")),
                                ConsciousnessAlert = reader.IsDBNull(reader.GetOrdinal("ConsciousnessAlert")) ? null : reader.GetInt32(reader.GetOrdinal("ConsciousnessAlert")),
                                TotalScore = reader.IsDBNull(reader.GetOrdinal("TotalScore")) ? null : reader.GetInt32(reader.GetOrdinal("TotalScore"))
                            };

                            patients.Add(patient);
                        }
                    }
                }
            }

            return patients;
        }

        public async Task<int> AddPatientAddsAsync(AddsDto addsDto)
        {
            if (addsDto.Id > 0)
            {
                await UpdatePatientAddsAsync(addsDto);
                return addsDto.Id;
            }
            else
            {
                int newId = await InsertPatientAddsAsync(addsDto);
                return newId;
            }
        }

        public async Task<int> InsertPatientAddsAsync(AddsDto addsDto)
        {
            using (var connection = await _dbConnectionFactory.CreateAsync())
            {
                using (var command = (SqlCommand)connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "InsertPatientAdds"; // Stored procedure name

                    // Add parameters to the command
                    command.Parameters.Add(new SqlParameter("@LabId", addsDto.LabId));
                    command.Parameters.Add(new SqlParameter("@PatientId", addsDto.PatientId));
                    command.Parameters.Add(new SqlParameter("@RespiratoryRate", addsDto.RespiratoryRate ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@HeartRate", addsDto.HeartRate ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Temperature", addsDto.Temperature ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Consciousness", addsDto.Consciousness ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@OxygenSaturation", addsDto.OxygenSaturation ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@OxygenFlow", addsDto.OxygenFlow ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@BloodPressure", addsDto.BloodPressure ?? (object)DBNull.Value));

                    command.Parameters.Add(new SqlParameter("@RespiratoryRateValue", addsDto.RespiratoryRateValue ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@OxygenSaturationValue", addsDto.OxygenSaturationValue ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@BloodPressureValue", addsDto.BloodPressureValue ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@HeartRateValue", addsDto.HeartRateValue ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@TemperatureValue", addsDto.TemperatureValue ?? (object)DBNull.Value));

                    command.Parameters.Add(new SqlParameter("@RespiratoryAlert", addsDto.RespiratoryAlert ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@OxygenSaturationAlert", addsDto.OxygenSaturationAlert ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@BloodPressureAlert", addsDto.BloodPressureAlert ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@HeartRateAlert", addsDto.HeartRateAlert ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@ConsciousnessAlert", addsDto.ConsciousnessAlert ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@TotalScore", addsDto.TotalScore ?? (object)DBNull.Value));

                    // Execute the command and return the new identity value
                    var newId = await command.ExecuteScalarAsync();
                    return (int)newId;
                }
            }
        }

        public async Task UpdatePatientAddsAsync(AddsDto addsDto)
        {
            using (var connection = await _dbConnectionFactory.CreateAsync())
            {
                using (var command = (SqlCommand)connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "UpdatePatientAdds"; // Stored procedure name

                    // Add parameters to the command
                    command.Parameters.Add(new SqlParameter("@Id", addsDto.Id));
                    command.Parameters.Add(new SqlParameter("@LabId", addsDto.LabId));
                    command.Parameters.Add(new SqlParameter("@PatientId", addsDto.PatientId));
                    command.Parameters.Add(new SqlParameter("@RespiratoryRate", addsDto.RespiratoryRate ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@HeartRate", addsDto.HeartRate ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Temperature", addsDto.Temperature ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Consciousness", addsDto.Consciousness ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@OxygenSaturation", addsDto.OxygenSaturation ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@OxygenFlow", addsDto.OxygenFlow ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@BloodPressure", addsDto.BloodPressure ?? (object)DBNull.Value));

                    command.Parameters.Add(new SqlParameter("@RespiratoryRateValue", addsDto.RespiratoryRateValue ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@OxygenSaturationValue", addsDto.OxygenSaturationValue ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@BloodPressureValue", addsDto.BloodPressureValue ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@HeartRateValue", addsDto.HeartRateValue ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@TemperatureValue", addsDto.TemperatureValue ?? (object)DBNull.Value));

                    command.Parameters.Add(new SqlParameter("@RespiratoryAlert", addsDto.RespiratoryAlert ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@OxygenSaturationAlert", addsDto.OxygenSaturationAlert ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@BloodPressureAlert", addsDto.BloodPressureAlert ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@HeartRateAlert", addsDto.HeartRateAlert ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@ConsciousnessAlert", addsDto.ConsciousnessAlert ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@TotalScore", addsDto.TotalScore ?? (object)DBNull.Value));

                    // Execute the command
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<int> AddIvFluidChartsync(IvFluidChartDto addsDto)
        {
            using (var connection = await _dbConnectionFactory.CreateAsync())
            {
                using (var command = (SqlCommand)connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "InsertIvFluidChart"; // Stored procedure name

                    // Add parameters to the command
                    command.Parameters.Add(new SqlParameter("@LabId", addsDto.LabId));
                    command.Parameters.Add(new SqlParameter("@PatientId", addsDto.PatientId));
                    command.Parameters.Add(new SqlParameter("@Date", addsDto.Date ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@FlaskVol", addsDto.FlaskVol ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Strength", addsDto.Strength ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Rate", addsDto.Rate ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Dose", addsDto.Dose ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@OfficerSign", addsDto.OfficerSign ?? (object)DBNull.Value));

                    // Execute the command and return the new identity value
                    var newId = await command.ExecuteScalarAsync();
                    return (int)newId;
                }
            }
        }

        public async Task<int> AddMedicationPrnChartAsync(MedicationPrnChartDto addsDto)
        {
            using (var connection = await _dbConnectionFactory.CreateAsync())
            {
                using (var command = (SqlCommand)connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "InsertMedicationPrnChart"; // Stored procedure name

                    // Add parameters to the command
                    command.Parameters.Add(new SqlParameter("@LabId", addsDto.LabId));
                    command.Parameters.Add(new SqlParameter("@PatientId", addsDto.PatientId));
                    command.Parameters.Add(new SqlParameter("@MedicationId", addsDto.MedicationId));
                    command.Parameters.Add(new SqlParameter("@Dose", addsDto.Dose ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@DoseFrequency", addsDto.DoseFrequency ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@DoseDate", addsDto.DoseDate ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@DoseTime", addsDto.DoseTime ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Indication", addsDto.Indication ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Route", addsDto.Route ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Pharmacy", addsDto.Pharmacy ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Prescriber", addsDto.Prescriber ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@PrescriberSign", addsDto.PrescriberSign ?? (object)DBNull.Value));

                    // Execute the command and return the new identity value
                    var newId = await command.ExecuteScalarAsync();
                    return (int)newId;
                }
            }
        }

        public async Task<int> AddPatientMedicationPrnAdministrationAsync(MedicationAdministrationPrnDto addsDto)
        {
            using (var connection = await _dbConnectionFactory.CreateAsync())
            {
                using (var command = (SqlCommand)connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "InsertMedicationPrnAdministration"; // Stored procedure name

                    // Add parameters to the command
                    command.Parameters.Add(new SqlParameter("@LabId", addsDto.LabId));
                    command.Parameters.Add(new SqlParameter("@PatientId", addsDto.PatientId));
                    command.Parameters.Add(new SqlParameter("@PatientMedicationChartId", addsDto.PatientMedicationChartId));
                    command.Parameters.Add(new SqlParameter("@DoseDate", addsDto.DoseDate ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@DoseTime", addsDto.DoseTime ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Dose", addsDto.Dose ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Route", addsDto.Route ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@StudentSign", addsDto.StudentSign ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Reason", addsDto.Reason ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@CoSign", addsDto.CoSign ?? (object)DBNull.Value));

                    // Execute the command and return the new identity value
                    var newId = await command.ExecuteScalarAsync();
                    return (int)newId;
                }
            }
        }

        public async Task<int> AddMedicationAsync(MedicationDto addsDto)
        {
            using (var connection = await _dbConnectionFactory.CreateAsync())
            {
                using (var command = (SqlCommand)connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "InsertMedication"; // Stored procedure name

                    // Add parameters to the command
                    command.Parameters.Add(new SqlParameter("@LabId", addsDto.LabId));
                    command.Parameters.Add(new SqlParameter("@Name", addsDto.Name));

                    // Execute the command and return the new identity value
                    var newId = await command.ExecuteScalarAsync();
                    return (int)newId;
                }
            }
        }

        public async Task<IEnumerable<MedicationDto>> GetMedicationAsync(int labId)
        {
            var patients = new List<MedicationDto>();

            // Create and open the database connection using the connection factory
            using (var connection = await _dbConnectionFactory.CreateAsync())
            {
                // Ensure we're working with SqlCommand for asynchronous operations
                using (var command = (SqlCommand)connection.CreateCommand())
                {
                    command.CommandText = "GetMedication"; // Assuming stored procedure name is GetPatients
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters to the command
                    command.Parameters.Add(new SqlParameter("@LabId", labId));

                    // Execute the stored procedure and read the results asynchronously
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var patient = new MedicationDto
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                LabId = reader.GetInt32(reader.GetOrdinal("LabId")),
                                Name = reader.GetString(reader.GetOrdinal("Name"))
                            };

                            patients.Add(patient);
                        }
                    }
                }
            }

            return patients;
        }
        public async Task<IEnumerable<MedicationAdministrationPrnDto>> GetPatientMedicationPrnAdministrationAsync(int labId, int patientId, int patientMedicationChartId)
        {
            var patients = new List<MedicationAdministrationPrnDto>();

            // Create and open the database connection using the connection factory
            using (var connection = await _dbConnectionFactory.CreateAsync())
            {
                // Ensure we're working with SqlCommand for asynchronous operations
                using (var command = (SqlCommand)connection.CreateCommand())
                {
                    command.CommandText = "GetMedicationPrnAdministration"; // Assuming stored procedure name is GetPatients
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters to the command
                    command.Parameters.Add(new SqlParameter("@LabId", labId));
                    command.Parameters.Add(new SqlParameter("@PatientId", patientId));
                    command.Parameters.Add(new SqlParameter("@PatientMedicationChartId", patientMedicationChartId));

                    // Execute the stored procedure and read the results asynchronously
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var patient = new MedicationAdministrationPrnDto
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                LabId = reader.GetInt32(reader.GetOrdinal("LabId")),
                                PatientId = reader.GetInt32(reader.GetOrdinal("PatientId")),
                                PatientMedicationChartId = reader.GetInt32(reader.GetOrdinal("PatientMedicationChartId")),
                                DoseDate = reader.GetDateTime(reader.GetOrdinal("DoseDate")),
                                DoseTime = reader.IsDBNull(reader.GetOrdinal("DoseTime")) ? null : reader.GetString(reader.GetOrdinal("DoseTime")),
                                Dose = reader.IsDBNull(reader.GetOrdinal("Dose")) ? null : reader.GetString(reader.GetOrdinal("Dose")),
                                Route = reader.IsDBNull(reader.GetOrdinal("Route")) ? null : reader.GetString(reader.GetOrdinal("Route")),
                                StudentSign = reader.IsDBNull(reader.GetOrdinal("StudentSign")) ? null : reader.GetString(reader.GetOrdinal("StudentSign")),
                                Reason = reader.IsDBNull(reader.GetOrdinal("Reason")) ? null : reader.GetString(reader.GetOrdinal("Reason")),
                                CoSign = reader.IsDBNull(reader.GetOrdinal("CoSign")) ? null : reader.GetString(reader.GetOrdinal("CoSign"))
                            };

                            patients.Add(patient);
                        }
                    }
                }
            }

            return patients;
        }

        public async Task<IEnumerable<MedicationPrnChartDto>> GetMedicationPrnChartAsync(int labId, int patientId)
        {
            var patients = new List<MedicationPrnChartDto>();

            // Create and open the database connection using the connection factory
            using (var connection = await _dbConnectionFactory.CreateAsync())
            {
                // Ensure we're working with SqlCommand for asynchronous operations
                using (var command = (SqlCommand)connection.CreateCommand())
                {
                    command.CommandText = "GetMedicationPrnChart"; // Assuming stored procedure name is GetPatients
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters to the command
                    command.Parameters.Add(new SqlParameter("@LabId", labId));
                    command.Parameters.Add(new SqlParameter("@PatientId", patientId));

                    // Execute the stored procedure and read the results asynchronously
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var patient = new MedicationPrnChartDto
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                LabId = reader.GetInt32(reader.GetOrdinal("LabId")),
                                PatientId = reader.GetInt32(reader.GetOrdinal("PatientId")),
                                MedicationId = reader.GetInt32(reader.GetOrdinal("MedicationId")),
                                MedicationName = reader.GetString(reader.GetOrdinal("MedicationName")),
                                Dose = reader.IsDBNull(reader.GetOrdinal("Dose")) ? null : reader.GetString(reader.GetOrdinal("Dose")),
                                DoseTime = reader.IsDBNull(reader.GetOrdinal("DoseTime")) ? null : reader.GetString(reader.GetOrdinal("DoseTime")),
                                DoseFrequency = reader.IsDBNull(reader.GetOrdinal("DoseFrequency")) ? null : reader.GetString(reader.GetOrdinal("DoseFrequency")),
                                DoseDate = reader.GetDateTime(reader.GetOrdinal("DoseDate")),
                                Indication = reader.IsDBNull(reader.GetOrdinal("Indication")) ? null : reader.GetString(reader.GetOrdinal("Indication")),
                                Route = reader.IsDBNull(reader.GetOrdinal("Route")) ? null : reader.GetString(reader.GetOrdinal("Route")),
                                Pharmacy = reader.IsDBNull(reader.GetOrdinal("Pharmacy")) ? null : reader.GetString(reader.GetOrdinal("Pharmacy")),
                                Prescriber = reader.IsDBNull(reader.GetOrdinal("Prescriber")) ? null : reader.GetString(reader.GetOrdinal("Prescriber")),
                                PrescriberSign = reader.IsDBNull(reader.GetOrdinal("PrescriberSign")) ? null : reader.GetString(reader.GetOrdinal("PrescriberSign"))
                            };

                            patients.Add(patient);
                        }
                    }
                }
            }

            return patients;
        }

        public async Task<IEnumerable<IvFluidChartDto>> GetIvFluidChartAsync(int labId, int patientId)
        {
            var patients = new List<IvFluidChartDto>();

            // Create and open the database connection using the connection factory
            using (var connection = await _dbConnectionFactory.CreateAsync())
            {
                // Ensure we're working with SqlCommand for asynchronous operations
                using (var command = (SqlCommand)connection.CreateCommand())
                {
                    command.CommandText = "GetIvFluidChart"; // Assuming stored procedure name is GetPatients
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters to the command
                    command.Parameters.Add(new SqlParameter("@LabId", labId));
                    command.Parameters.Add(new SqlParameter("@PatientId", patientId));

                    // Execute the stored procedure and read the results asynchronously
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var patient = new IvFluidChartDto
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                LabId = reader.GetInt32(reader.GetOrdinal("LabId")),
                                PatientId = reader.GetInt32(reader.GetOrdinal("PatientId")),
                                Date = reader.GetDateTime(reader.GetOrdinal("Date")),
                                FlaskVol = reader.IsDBNull(reader.GetOrdinal("FlaskVol")) ? null : reader.GetString(reader.GetOrdinal("FlaskVol")),
                                Strength = reader.IsDBNull(reader.GetOrdinal("Strength")) ? null : reader.GetString(reader.GetOrdinal("Strength")),
                                Rate = reader.IsDBNull(reader.GetOrdinal("Rate")) ? null : reader.GetString(reader.GetOrdinal("Rate")),
                                Dose = reader.IsDBNull(reader.GetOrdinal("Dose")) ? null : reader.GetString(reader.GetOrdinal("Dose")),
                                OfficerSign = reader.IsDBNull(reader.GetOrdinal("OfficerSign")) ? null : reader.GetString(reader.GetOrdinal("OfficerSign"))
                            };

                            patients.Add(patient);
                        }
                    }
                }
            }

            return patients;
        }

        public async Task<int> AddPatientIvFluidAdministrationAsync(IvFluidAdministrationDto addsDto)
        {
            using (var connection = await _dbConnectionFactory.CreateAsync())
            {
                using (var command = (SqlCommand)connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "InsertIvFluidAdministration"; // Stored procedure name

                    // Add parameters to the command
                    command.Parameters.Add(new SqlParameter("@LabId", addsDto.LabId));
                    command.Parameters.Add(new SqlParameter("@PatientId", addsDto.PatientId));
                    command.Parameters.Add(new SqlParameter("@IvFluidChartId", addsDto.IvFluidChartId));
                    command.Parameters.Add(new SqlParameter("@StartDate", addsDto.StartDate ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@StartTime", addsDto.StartTime ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@EndDate", addsDto.EndDate ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@EndTime", addsDto.EndTime ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@VolGiven", addsDto.VolGiven ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@PharmacistReview", addsDto.PharmacistReview ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@NurseSign", addsDto.NurseSign ?? (object)DBNull.Value));

                    // Execute the command and return the new identity value
                    var newId = await command.ExecuteScalarAsync();
                    return (int)newId;
                }
            }
        }

        public async Task<IEnumerable<IvFluidAdministrationDto>> GetIvFluidAdministrationAsync(int labId, int patientId, int ivFluidChartId)
        {
            var patients = new List<IvFluidAdministrationDto>();

            // Create and open the database connection using the connection factory
            using (var connection = await _dbConnectionFactory.CreateAsync())
            {
                // Ensure we're working with SqlCommand for asynchronous operations
                using (var command = (SqlCommand)connection.CreateCommand())
                {
                    command.CommandText = "GetIvFluidAdministration"; // Assuming stored procedure name is GetPatients
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters to the command
                    command.Parameters.Add(new SqlParameter("@LabId", labId));
                    command.Parameters.Add(new SqlParameter("@PatientId", patientId));
                    command.Parameters.Add(new SqlParameter("@IvFluidChartId", ivFluidChartId));

                    // Execute the stored procedure and read the results asynchronously
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var patient = new IvFluidAdministrationDto
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                LabId = reader.GetInt32(reader.GetOrdinal("LabId")),
                                PatientId = reader.GetInt32(reader.GetOrdinal("PatientId")),
                                IvFluidChartId = reader.GetInt32(reader.GetOrdinal("IvFluidChartId")),
                                StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate")),
                                StartTime = reader.IsDBNull(reader.GetOrdinal("StartTime")) ? null : reader.GetString(reader.GetOrdinal("StartTime")),
                                EndDate = reader.GetDateTime(reader.GetOrdinal("EndDate")),
                                EndTime = reader.IsDBNull(reader.GetOrdinal("EndTime")) ? null : reader.GetString(reader.GetOrdinal("EndTime")),
                                VolGiven = reader.IsDBNull(reader.GetOrdinal("VolGiven")) ? null : reader.GetString(reader.GetOrdinal("VolGiven")),
                                PharmacistReview = reader.IsDBNull(reader.GetOrdinal("PharmacistReview")) ? null : reader.GetString(reader.GetOrdinal("PharmacistReview")),
                                NurseSign = reader.IsDBNull(reader.GetOrdinal("NurseSign")) ? null : reader.GetString(reader.GetOrdinal("NurseSign"))
                            };

                            patients.Add(patient);
                        }
                    }
                }
            }

            return patients;
        }

        public async Task<(int id, string resultMessage)> DeleteIvFluidChartAsync(int Id)
        {
            int id = 0;
            string resultMessage = "";

            // Create and open the database connection using the connection factory
            using (var connection = await _dbConnectionFactory.CreateAsync())
            {
                // Ensure we're working with SqlCommand for asynchronous operations
                using (var command = (SqlCommand)connection.CreateCommand())
                {
                    command.CommandText = "DeleteIvFluidChart"; // Assuming stored procedure name is GetPatients
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters to the command
                    command.Parameters.Add(new SqlParameter("@Id", Id));

                    // Execute the stored procedure and read the results asynchronously
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            id = reader.GetInt32(reader.GetOrdinal("RowsAffected"));
                            resultMessage = reader.GetString(reader.GetOrdinal("ResultMessage"));
                        }
                    }
                }
            }

            return (id, resultMessage);
        }

        public async Task<int> DeleteIvFluidAdministrationAsync(int Id)
        {
            using (var connection = await _dbConnectionFactory.CreateAsync())
            {
                using (var command = (SqlCommand)connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "DeleteIvFluidAdministration"; // Stored procedure name

                    // Add parameters to the command
                    command.Parameters.Add(new SqlParameter("@Id", Id));

                    // Execute the command and return the new identity value
                    var newId = await command.ExecuteScalarAsync();
                    return (int)newId;
                }
            }
        }

        public async Task<(int id, string resultMessage)> DeleteMedicationPrnChartAsync(int Id)
        {
            int id = 0;
            string resultMessage = "";

            // Create and open the database connection using the connection factory
            using (var connection = await _dbConnectionFactory.CreateAsync())
            {
                // Ensure we're working with SqlCommand for asynchronous operations
                using (var command = (SqlCommand)connection.CreateCommand())
                {
                    command.CommandText = "DeleteMedicationPrnChart"; // Assuming stored procedure name is GetPatients
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters to the command
                    command.Parameters.Add(new SqlParameter("@Id", Id));

                    // Execute the stored procedure and read the results asynchronously
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            id = reader.GetInt32(reader.GetOrdinal("RowsAffected"));
                            resultMessage = reader.GetString(reader.GetOrdinal("ResultMessage"));
                        }
                    }
                }
            }

            return (id, resultMessage);
        }

        public async Task<int> DeleteMedicationPrnAdministrationAsync(int Id)
        {
            using (var connection = await _dbConnectionFactory.CreateAsync())
            {
                using (var command = (SqlCommand)connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "DeleteMedicationPrnAdministration"; // Stored procedure name

                    // Add parameters to the command
                    command.Parameters.Add(new SqlParameter("@Id", Id));

                    // Execute the command and return the new identity value
                    var newId = await command.ExecuteScalarAsync();
                    return (int)newId;
                }
            }
        }

        public async Task<int> AddMedicationRegularChartAsync(MedicationRegularChartDto addsDto)
        {
            using (var connection = await _dbConnectionFactory.CreateAsync())
            {
                using (var command = (SqlCommand)connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "InsertMedicationRegularChart"; // Stored procedure name

                    // Add parameters to the command
                    command.Parameters.Add(new SqlParameter("@LabId", addsDto.LabId));
                    command.Parameters.Add(new SqlParameter("@PatientId", addsDto.PatientId));
                    command.Parameters.Add(new SqlParameter("@MedicationId", addsDto.MedicationId));
                    command.Parameters.Add(new SqlParameter("@Dose", addsDto.Dose ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@DoseFrequency", addsDto.DoseFrequency ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@DoseDate", addsDto.DoseDate ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@DoseTime", addsDto.DoseTime ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Indication", addsDto.Indication ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Route", addsDto.Route ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Pharmacy", addsDto.Pharmacy ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Prescriber", addsDto.Prescriber ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@PrescriberSign", addsDto.PrescriberSign ?? (object)DBNull.Value));

                    // Execute the command and return the new identity value
                    var newId = await command.ExecuteScalarAsync();
                    return (int)newId;
                }
            }
        }

        public async Task<int> AddPatientMedicationRegularAdministrationAsync(MedicationAdministrationRegularDto addsDto)
        {
            using (var connection = await _dbConnectionFactory.CreateAsync())
            {
                using (var command = (SqlCommand)connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "InsertMedicationRegularAdministration"; // Stored procedure name

                    // Add parameters to the command
                    command.Parameters.Add(new SqlParameter("@LabId", addsDto.LabId));
                    command.Parameters.Add(new SqlParameter("@PatientId", addsDto.PatientId));
                    command.Parameters.Add(new SqlParameter("@PatientMedicationChartId", addsDto.PatientMedicationChartId));
                    command.Parameters.Add(new SqlParameter("@DoseDate", addsDto.DoseDate ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@DoseTime", addsDto.DoseTime ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Dose", addsDto.Dose ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Route", addsDto.Route ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@StudentSign", addsDto.StudentSign ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Reason", addsDto.Reason ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@CoSign", addsDto.CoSign ?? (object)DBNull.Value));

                    // Execute the command and return the new identity value
                    var newId = await command.ExecuteScalarAsync();
                    return (int)newId;
                }
            }
        }

        public async Task<IEnumerable<MedicationRegularChartDto>> GetMedicationRegularChartAsync(int labId, int patientId)
        {
            var patients = new List<MedicationRegularChartDto>();

            // Create and open the database connection using the connection factory
            using (var connection = await _dbConnectionFactory.CreateAsync())
            {
                // Ensure we're working with SqlCommand for asynchronous operations
                using (var command = (SqlCommand)connection.CreateCommand())
                {
                    command.CommandText = "GetMedicationRegularChart"; // Assuming stored procedure name is GetPatients
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters to the command
                    command.Parameters.Add(new SqlParameter("@LabId", labId));
                    command.Parameters.Add(new SqlParameter("@PatientId", patientId));

                    // Execute the stored procedure and read the results asynchronously
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var patient = new MedicationRegularChartDto
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                LabId = reader.GetInt32(reader.GetOrdinal("LabId")),
                                PatientId = reader.GetInt32(reader.GetOrdinal("PatientId")),
                                MedicationId = reader.GetInt32(reader.GetOrdinal("MedicationId")),
                                MedicationName = reader.GetString(reader.GetOrdinal("MedicationName")),
                                Dose = reader.IsDBNull(reader.GetOrdinal("Dose")) ? null : reader.GetString(reader.GetOrdinal("Dose")),
                                DoseTime = reader.IsDBNull(reader.GetOrdinal("DoseTime")) ? null : reader.GetString(reader.GetOrdinal("DoseTime")),
                                DoseFrequency = reader.IsDBNull(reader.GetOrdinal("DoseFrequency")) ? null : reader.GetString(reader.GetOrdinal("DoseFrequency")),
                                DoseDate = reader.GetDateTime(reader.GetOrdinal("DoseDate")),
                                Indication = reader.IsDBNull(reader.GetOrdinal("Indication")) ? null : reader.GetString(reader.GetOrdinal("Indication")),
                                Route = reader.IsDBNull(reader.GetOrdinal("Route")) ? null : reader.GetString(reader.GetOrdinal("Route")),
                                Pharmacy = reader.IsDBNull(reader.GetOrdinal("Pharmacy")) ? null : reader.GetString(reader.GetOrdinal("Pharmacy")),
                                Prescriber = reader.IsDBNull(reader.GetOrdinal("Prescriber")) ? null : reader.GetString(reader.GetOrdinal("Prescriber")),
                                PrescriberSign = reader.IsDBNull(reader.GetOrdinal("PrescriberSign")) ? null : reader.GetString(reader.GetOrdinal("PrescriberSign"))

                            };

                            patients.Add(patient);
                        }
                    }
                }
            }

            return patients;
        }

        public async Task<IEnumerable<MedicationAdministrationRegularDto>> GetPatientMedicationRegularAdministrationAsync(int labId, int patientId, int patientMedicationChartId)
        {
            var patients = new List<MedicationAdministrationRegularDto>();

            // Create and open the database connection using the connection factory
            using (var connection = await _dbConnectionFactory.CreateAsync())
            {
                // Ensure we're working with SqlCommand for asynchronous operations
                using (var command = (SqlCommand)connection.CreateCommand())
                {
                    command.CommandText = "GetMedicationRegularAdministration"; // Assuming stored procedure name is GetPatients
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters to the command
                    command.Parameters.Add(new SqlParameter("@LabId", labId));
                    command.Parameters.Add(new SqlParameter("@PatientId", patientId));
                    command.Parameters.Add(new SqlParameter("@PatientMedicationChartId", patientMedicationChartId));

                    // Execute the stored procedure and read the results asynchronously
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var patient = new MedicationAdministrationRegularDto
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                LabId = reader.GetInt32(reader.GetOrdinal("LabId")),
                                PatientId = reader.GetInt32(reader.GetOrdinal("PatientId")),
                                PatientMedicationChartId = reader.GetInt32(reader.GetOrdinal("PatientMedicationChartId")),
                                DoseDate = reader.GetDateTime(reader.GetOrdinal("DoseDate")),
                                DoseTime = reader.IsDBNull(reader.GetOrdinal("DoseTime")) ? null : reader.GetString(reader.GetOrdinal("DoseTime")),
                                Route = reader.IsDBNull(reader.GetOrdinal("Route")) ? null : reader.GetString(reader.GetOrdinal("Route")),
                                Dose = reader.IsDBNull(reader.GetOrdinal("Dose")) ? null : reader.GetString(reader.GetOrdinal("Dose")),
                                StudentSign = reader.IsDBNull(reader.GetOrdinal("StudentSign")) ? null : reader.GetString(reader.GetOrdinal("StudentSign")),
                                Reason = reader.IsDBNull(reader.GetOrdinal("Reason")) ? null : reader.GetString(reader.GetOrdinal("Reason")),
                                CoSign = reader.IsDBNull(reader.GetOrdinal("CoSign")) ? null : reader.GetString(reader.GetOrdinal("CoSign"))
                            };

                            patients.Add(patient);
                        }
                    }
                }
            }

            return patients;
        }

        public async Task<int> DeletePatientAddsAsync(int Id)
        {
            using (var connection = await _dbConnectionFactory.CreateAsync())
            {
                using (var command = (SqlCommand)connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "DeletePatientAdds"; // Stored procedure name

                    // Add parameters to the command
                    command.Parameters.Add(new SqlParameter("@Id", Id));

                    // Execute the command and return the new identity value
                    var newId = await command.ExecuteScalarAsync();
                    return (int)newId;
                }
            }
        }

        public async Task<(int id, string resultMessage)> DeleteMedicationRegularChartAsync(int Id)
        {
            int id = 0;
            string resultMessage = "";

            // Create and open the database connection using the connection factory
            using (var connection = await _dbConnectionFactory.CreateAsync())
            {
                // Ensure we're working with SqlCommand for asynchronous operations
                using (var command = (SqlCommand)connection.CreateCommand())
                {
                    command.CommandText = "DeleteMedicationRegularChart"; // Assuming stored procedure name is GetPatients
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters to the command
                    command.Parameters.Add(new SqlParameter("@Id", Id));

                    // Execute the stored procedure and read the results asynchronously
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            id = reader.GetInt32(reader.GetOrdinal("RowsAffected"));
                            resultMessage = reader.GetString(reader.GetOrdinal("ResultMessage"));
                        }
                    }
                }
            }

            return (id, resultMessage);
        }

        public async Task<int> DeleteMedicationRegularAdministrationAsync(int Id)
        {
            using (var connection = await _dbConnectionFactory.CreateAsync())
            {
                using (var command = (SqlCommand)connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "DeleteMedicationRegularAdministration"; // Stored procedure name

                    // Add parameters to the command
                    command.Parameters.Add(new SqlParameter("@Id", Id));

                    // Execute the command and return the new identity value
                    var newId = await command.ExecuteScalarAsync();
                    return (int)newId;
                }
            }
        }

        public async Task<int> AddProgressNotesAsync(ProgressNotesDto addsDto)
        {
            if (addsDto.Id > 0)
            {
                await UpdateProgressNotesAsync(addsDto);
                return addsDto.Id;
            }
            else
            {
                int newId = await InsertProgressNotesAsync(addsDto);
                return newId;
            }
        }

        public async Task<int> InsertProgressNotesAsync(ProgressNotesDto addsDto)
        {
            using (var connection = await _dbConnectionFactory.CreateAsync())
            {
                using (var command = (SqlCommand)connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "InsertProgressNote"; // Stored procedure name

                    // Add parameters to the command
                    command.Parameters.Add(new SqlParameter("@LabId", addsDto.LabId));
                    command.Parameters.Add(new SqlParameter("@PatientId", addsDto.PatientId));
                    command.Parameters.Add(new SqlParameter("@NotesDate", addsDto.NotesDate ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Notes", addsDto.Notes ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Sign", addsDto.Sign ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@NotesFrom", addsDto.NotesFrom?? (object)DBNull.Value));

                    // Execute the command and return the new identity value
                    var newId = await command.ExecuteScalarAsync();
                    return (int)newId;
                }
            }
        }

        public async Task UpdateProgressNotesAsync(ProgressNotesDto addsDto)
        {
            using (var connection = await _dbConnectionFactory.CreateAsync())
            {
                using (var command = (SqlCommand)connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "UpdateProgressNote"; // Stored procedure name

                    // Add parameters to the command
                    command.Parameters.Add(new SqlParameter("@Id", addsDto.Id));
                    command.Parameters.Add(new SqlParameter("@LabId", addsDto.LabId));
                    command.Parameters.Add(new SqlParameter("@PatientId", addsDto.PatientId));
                    command.Parameters.Add(new SqlParameter("@NotesDate", addsDto.NotesDate ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Notes", addsDto.Notes ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Sign", addsDto.Sign ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@NotesFrom", addsDto.NotesFrom ?? (object)DBNull.Value));

                    // Execute the command
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<int> DeleteProgressNotesAsync(int Id)
        {
            using (var connection = await _dbConnectionFactory.CreateAsync())
            {
                using (var command = (SqlCommand)connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "DeleteProgressNote"; // Stored procedure name

                    // Add parameters to the command
                    command.Parameters.Add(new SqlParameter("@Id", Id));

                    // Execute the command and return the new identity value
                    var newId = await command.ExecuteScalarAsync();
                    return (int)newId;
                }
            }
        }

        public async Task<IEnumerable<ProgressNotesDto>> GetProgressNotesAsync(int labId, int patientId)
        {
            var patients = new List<ProgressNotesDto>();

            // Create and open the database connection using the connection factory
            using (var connection = await _dbConnectionFactory.CreateAsync())
            {
                // Ensure we're working with SqlCommand for asynchronous operations
                using (var command = (SqlCommand)connection.CreateCommand())
                {
                    command.CommandText = "GetProgressNotes"; // Assuming stored procedure name is GetPatients
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters to the command
                    command.Parameters.Add(new SqlParameter("@LabId", labId));
                    command.Parameters.Add(new SqlParameter("@PatientId", patientId));

                    // Execute the stored procedure and read the results asynchronously
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var patient = new ProgressNotesDto
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                LabId = reader.GetInt32(reader.GetOrdinal("LabId")),
                                PatientId = reader.GetInt32(reader.GetOrdinal("PatientId")),
                                NotesDate = reader.GetDateTime(reader.GetOrdinal("NotesDate")),
                                Notes = reader.IsDBNull(reader.GetOrdinal("Notes")) ? null : reader.IsDBNull(reader.GetOrdinal("Notes")) ? null : reader.GetString(reader.GetOrdinal("Notes")),
                                Sign = reader.IsDBNull(reader.GetOrdinal("Sign")) ? null : reader.IsDBNull(reader.GetOrdinal("Sign")) ? null : reader.GetString(reader.GetOrdinal("Sign")),
                                NotesFrom = reader.IsDBNull(reader.GetOrdinal("NotesFrom")) ? null : reader.IsDBNull(reader.GetOrdinal("NotesFrom")) ? null : reader.GetString(reader.GetOrdinal("NotesFrom"))
                            };

                            patients.Add(patient);
                        }
                    }
                }
            }

            return patients;
        }

        public async Task<IEnumerable<ClearDataDto>> ClearPatientDataAsync(int labId, int patientId)
        {
            var patients = new List<ClearDataDto>();

            // Create and open the database connection using the connection factory
            using (var connection = await _dbConnectionFactory.CreateAsync())
            {
                // Ensure we're working with SqlCommand for asynchronous operations
                using (var command = (SqlCommand)connection.CreateCommand())
                {
                    command.CommandText = "ClearPatientData"; // Assuming stored procedure name is GetPatients
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters to the command
                    command.Parameters.Add(new SqlParameter("@LabId", labId));
                    command.Parameters.Add(new SqlParameter("@PatientId", patientId));

                    // Execute the stored procedure and read the results asynchronously
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var patient = new ClearDataDto
                            {
                                ModuleName = reader.GetString(reader.GetOrdinal("TableName")),
                                RowsDeleted = reader.GetInt32(reader.GetOrdinal("RowsDeleted"))
                            };

                            patients.Add(patient);
                        }
                    }
                }
            }

            return patients;
        }

        public async Task<IEnumerable<ClearDataDto>> ClearLabDataAsync(int labId)
        {
            var patients = new List<ClearDataDto>();

            // Create and open the database connection using the connection factory
            using (var connection = await _dbConnectionFactory.CreateAsync())
            {
                // Ensure we're working with SqlCommand for asynchronous operations
                using (var command = (SqlCommand)connection.CreateCommand())
                {
                    command.CommandText = "ClearLabData"; // Assuming stored procedure name is GetPatients
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters to the command
                    command.Parameters.Add(new SqlParameter("@LabId", labId));

                    // Execute the stored procedure and read the results asynchronously
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var patient = new ClearDataDto
                            {
                                ModuleName = reader.GetString(reader.GetOrdinal("TableName")),
                                RowsDeleted = reader.GetInt32(reader.GetOrdinal("RowsDeleted"))
                            };

                            patients.Add(patient);
                        }
                    }
                }
            }

            return patients;
        }

        public async Task<(int id, string resultMessage)> DeleteMedicationAsync(int Id)
        {
            int id = 0;
            string resultMessage = "";

            // Create and open the database connection using the connection factory
            using (var connection = await _dbConnectionFactory.CreateAsync())
            {
                // Ensure we're working with SqlCommand for asynchronous operations
                using (var command = (SqlCommand)connection.CreateCommand())
                {
                    command.CommandText = "DeleteMedication"; // Assuming stored procedure name is GetPatients
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters to the command
                    command.Parameters.Add(new SqlParameter("@Id", Id));

                    // Execute the stored procedure and read the results asynchronously
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {

                            id = reader.GetInt32(reader.GetOrdinal("RowsAffected"));
                            resultMessage = reader.GetString(reader.GetOrdinal("ResultMessage"));
                        }
                    }
                }
            }

            return (id, resultMessage);
        }

        public async Task<IvFluidChartDto> GetIvFluidChartByIdAsync(int Id, int labId)
        {
            var patient = new IvFluidChartDto();

            // Create and open the database connection using the connection factory
            using (var connection = await _dbConnectionFactory.CreateAsync())
            {
                // Ensure we're working with SqlCommand for asynchronous operations
                using (var command = (SqlCommand)connection.CreateCommand())
                {
                    command.CommandText = "GetIvFluidChart"; // Assuming stored procedure name is GetPatients
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters to the command
                    command.Parameters.Add(new SqlParameter("@Id", Id));
                    command.Parameters.Add(new SqlParameter("@LabId", labId));

                    // Execute the stored procedure and read the results asynchronously
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {

                            patient.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            patient.LabId = reader.GetInt32(reader.GetOrdinal("LabId"));
                            patient.PatientId = reader.GetInt32(reader.GetOrdinal("PatientId"));
                            patient.Date = reader.GetDateTime(reader.GetOrdinal("Date"));
                            patient.FlaskVol = reader.IsDBNull(reader.GetOrdinal("FlaskVol")) ? null : reader.GetString(reader.GetOrdinal("FlaskVol"));
                            patient.Strength = reader.IsDBNull(reader.GetOrdinal("Strength")) ? null : reader.GetString(reader.GetOrdinal("Strength"));
                            patient.Rate = reader.IsDBNull(reader.GetOrdinal("Rate")) ? null : reader.GetString(reader.GetOrdinal("Rate"));
                            patient.Dose = reader.IsDBNull(reader.GetOrdinal("Dose")) ? null : reader.GetString(reader.GetOrdinal("Dose"));
                            patient.OfficerSign = reader.IsDBNull(reader.GetOrdinal("OfficerSign")) ? null : reader.GetString(reader.GetOrdinal("OfficerSign"));
                        }
                    }
                }
            }

            return patient;
        }

        public async Task<MedicationPrnChartDto> GetMedicationPrnChartByIdAsync(int Id, int labId)
        {
            var patient = new MedicationPrnChartDto();

            // Create and open the database connection using the connection factory
            using (var connection = await _dbConnectionFactory.CreateAsync())
            {
                // Ensure we're working with SqlCommand for asynchronous operations
                using (var command = (SqlCommand)connection.CreateCommand())
                {
                    command.CommandText = "GetMedicationPrnChart"; // Assuming stored procedure name is GetPatients
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters to the command
                    command.Parameters.Add(new SqlParameter("@Id", Id));
                    command.Parameters.Add(new SqlParameter("@LabId", labId));

                    // Execute the stored procedure and read the results asynchronously
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            patient.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            patient.LabId = reader.GetInt32(reader.GetOrdinal("LabId"));
                            patient.PatientId = reader.GetInt32(reader.GetOrdinal("PatientId"));
                            patient.MedicationId = reader.GetInt32(reader.GetOrdinal("MedicationId"));
                            patient.MedicationName = reader.GetString(reader.GetOrdinal("MedicationName"));
                            patient.Dose = reader.IsDBNull(reader.GetOrdinal("Dose")) ? null : reader.GetString(reader.GetOrdinal("Dose"));
                            patient.DoseTime = reader.IsDBNull(reader.GetOrdinal("DoseTime")) ? null : reader.GetString(reader.GetOrdinal("DoseTime"));
                            patient.DoseFrequency = reader.IsDBNull(reader.GetOrdinal("DoseFrequency")) ? null : reader.GetString(reader.GetOrdinal("DoseFrequency"));
                            patient.DoseDate = reader.GetDateTime(reader.GetOrdinal("DoseDate"));
                            patient.Indication = reader.IsDBNull(reader.GetOrdinal("Indication")) ? null : reader.GetString(reader.GetOrdinal("Indication"));
                            patient.Route = reader.IsDBNull(reader.GetOrdinal("Route")) ? null : reader.GetString(reader.GetOrdinal("Route"));
                            patient.Pharmacy = reader.IsDBNull(reader.GetOrdinal("Pharmacy")) ? null : reader.GetString(reader.GetOrdinal("Pharmacy"));
                            patient.Prescriber = reader.IsDBNull(reader.GetOrdinal("Prescriber")) ? null : reader.GetString(reader.GetOrdinal("Prescriber"));
                            patient.PrescriberSign = reader.IsDBNull(reader.GetOrdinal("PrescriberSign")) ? null : reader.GetString(reader.GetOrdinal("PrescriberSign"));
                        }
                    }
                }
            }

            return patient;
        }

        public async Task<MedicationRegularChartDto> GetMedicationRegularChartByIdAsync(int Id, int labId)
        {
            var patient = new MedicationRegularChartDto();

            // Create and open the database connection using the connection factory
            using (var connection = await _dbConnectionFactory.CreateAsync())
            {
                // Ensure we're working with SqlCommand for asynchronous operations
                using (var command = (SqlCommand)connection.CreateCommand())
                {
                    command.CommandText = "GetMedicationRegularChart"; // Assuming stored procedure name is GetPatients
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters to the command
                    command.Parameters.Add(new SqlParameter("@Id", Id));
                    command.Parameters.Add(new SqlParameter("@LabId", labId));

                    // Execute the stored procedure and read the results asynchronously
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            patient.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            patient.LabId = reader.GetInt32(reader.GetOrdinal("LabId"));
                            patient.PatientId = reader.GetInt32(reader.GetOrdinal("PatientId"));
                            patient.MedicationId = reader.GetInt32(reader.GetOrdinal("MedicationId"));
                            patient.MedicationName = reader.GetString(reader.GetOrdinal("MedicationName"));
                            patient.Dose = reader.IsDBNull(reader.GetOrdinal("Dose")) ? null : reader.GetString(reader.GetOrdinal("Dose"));
                            patient.DoseTime = reader.IsDBNull(reader.GetOrdinal("DoseTime")) ? null : reader.GetString(reader.GetOrdinal("DoseTime"));
                            patient.DoseFrequency = reader.IsDBNull(reader.GetOrdinal("DoseFrequency")) ? null : reader.GetString(reader.GetOrdinal("DoseFrequency"));
                            patient.DoseDate = reader.GetDateTime(reader.GetOrdinal("DoseDate"));
                            patient.Indication = reader.IsDBNull(reader.GetOrdinal("Indication")) ? null : reader.GetString(reader.GetOrdinal("Indication"));
                            patient.Route = reader.IsDBNull(reader.GetOrdinal("Route")) ? null : reader.GetString(reader.GetOrdinal("Route"));
                            patient.Pharmacy = reader.IsDBNull(reader.GetOrdinal("Pharmacy")) ? null : reader.GetString(reader.GetOrdinal("Pharmacy"));
                            patient.Prescriber = reader.IsDBNull(reader.GetOrdinal("Prescriber")) ? null : reader.GetString(reader.GetOrdinal("Prescriber"));
                            patient.PrescriberSign = reader.IsDBNull(reader.GetOrdinal("PrescriberSign")) ? null : reader.GetString(reader.GetOrdinal("PrescriberSign"));
                        }
                    }
                }
            }

            return patient;
        }

        public async Task<int> AddPatientAsync(PatientDto addsDto)
        {
            if (addsDto.Id > 0)
            {
                await UpdatePatientAsync(addsDto);
                return addsDto.Id;
            }
            else
            {
                int newId = await InsertPatientAsync(addsDto);
                return newId;
            }
        }

        public async Task<int> InsertPatientAsync(PatientDto addsDto)
        {
            using (var connection = await _dbConnectionFactory.CreateAsync())
            {
                using (var command = (SqlCommand)connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "InsertPatient"; // Stored procedure name

                    // Add parameters to the command
                    command.Parameters.Add(new SqlParameter("@LabId", addsDto.LabId));
                    command.Parameters.Add(new SqlParameter("@FirstName", addsDto.FirstName ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@LastName", addsDto.LastName ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@DateOfBirth", addsDto.DateOfBirth ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Gender", addsDto.Gender ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Address", addsDto.Address ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@AdmitDate", addsDto.AdmitDate ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Weight", addsDto.Weight ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Height", addsDto.Height ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Age", addsDto.Age ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Allergy", addsDto.Allergy ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Intolerance", addsDto.Intolerance ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@UriNumber", addsDto.UriNumber ?? (object)DBNull.Value));


                    // Execute the command and return the new identity value
                    var newId = await command.ExecuteScalarAsync();
                    return (int)newId;
                }
            }
        }

        public async Task UpdatePatientAsync(PatientDto addsDto)
        {
            using (var connection = await _dbConnectionFactory.CreateAsync())
            {
                using (var command = (SqlCommand)connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "UpdatePatient"; // Stored procedure name

                    // Add parameters to the command
                    command.Parameters.Add(new SqlParameter("@Id", addsDto.Id));
                    command.Parameters.Add(new SqlParameter("@LabId", addsDto.LabId));
                    command.Parameters.Add(new SqlParameter("@FirstName", addsDto.FirstName ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@LastName", addsDto.LastName ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@DateOfBirth", addsDto.DateOfBirth ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Gender", addsDto.Gender ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Address", addsDto.Address ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@AdmitDate", addsDto.AdmitDate ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Weight", addsDto.Weight ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Height", addsDto.Height ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Age", addsDto.Age ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Allergy", addsDto.Allergy ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Intolerance", addsDto.Intolerance ?? (object)DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@UriNumber", addsDto.UriNumber ?? (object)DBNull.Value));

                    // Execute the command
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<int> DeletePatientAsync(int labId, int Id)
        {
            using (var connection = await _dbConnectionFactory.CreateAsync())
            {
                using (var command = (SqlCommand)connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "DeletePatient"; // Stored procedure name

                    // Add parameters to the command
                    command.Parameters.Add(new SqlParameter("@Id", Id));
                    command.Parameters.Add(new SqlParameter("@LabId", labId));

                    // Execute the command and return the new identity value
                    var newId = await command.ExecuteScalarAsync();
                    return (int)newId;
                }
            }
        }
    }
}
