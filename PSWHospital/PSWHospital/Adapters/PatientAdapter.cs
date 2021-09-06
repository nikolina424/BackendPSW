using PSWHospital.DTOs.Responses;
using PSWHospital.Models;

namespace PSWHospital.Adapters
{
    public class PatientAdapter
    {
        public static PatientResponse PatientToPatientDto(Patient patient)
        {
            PatientResponse patientResponse = new PatientResponse();
            patientResponse.FirstName = patient.FirstName;
            patientResponse.LastName = patient.LastName;
            patientResponse.Feedbacks = patient.Feedbacks;
            patientResponse.IsDeleted = patient.IsDeleted;
            patientResponse.CanceledExamination = patient.CanceledExamination;

            return patientResponse;
        }
    }
}
