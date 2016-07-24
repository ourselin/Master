using Service.Contract.PatientInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.DataContracts.PatientInformation;
using Business.PatientInformation;

namespace Service.PatientInformation
{
    public class PatientInformation : IPatientInformation
    {
        public List<PIDataContracts> GetAllPatientInformation()
        {
            IPIManager manager = new PIManager();
            List<PIDto> lstPatient = manager.GetAllPI();
            List<PIDataContracts> lstPatientContract = null;
            if (lstPatient != null)
            {
                lstPatientContract = new List<PIDataContracts>();
                foreach (var patient in lstPatient)
                {
                    PIDataContracts patientContract = new PIDataContracts();
                    patientContract.FirstName = patient.FirstName;
                    patientContract.LastName = patient.LastName;
                    patientContract.Gender = patient.Gender;
                    patientContract.DateOfBirth = patient.DateOfBirth;
                    patientContract.SubjectId = patient.SubjectId;
                    lstPatientContract.Add(patientContract);
                }   
            }
            return lstPatientContract;
        }

        public PIDataContracts GetPatientInformation(string id)
        {
            IPIManager manager = new PIManager();
            PIDto patient = manager.GetPI(id);
            PIDataContracts patientContract = null;
            if (patient != null)
            {
                patientContract = new PIDataContracts();
                patientContract.FirstName = patient.FirstName;
                patientContract.LastName = patient.LastName;
                patientContract.Gender = patient.Gender;
                patientContract.DateOfBirth = patient.DateOfBirth;
                patientContract.SubjectId = patient.SubjectId;
            }
            return patientContract;
        }
    }
}
