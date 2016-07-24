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
    class PatientInformation : IPIContracts
    {
        List<PIDataContracts> IPIContracts.GetAllPatientInformation()
        {
            throw new NotImplementedException();
        }

        PIDataContracts IPIContracts.GetPatientInformation(string id)
        {
            IPIManager manager = new PIManager();
            PIDto patient = manager.GetPI(id);
            PIDataContracts patientContract = null;
            if (patient != null)
            {
                patientContract = new PIDataContracts();
                patientContract.SubjectId = patient.SubjectId;
                patientContract.LastName = patient.LastName;
                patientContract.FirstName = patient.FirstName;
                patientContract.DateOfBirth = patient.DateOfBirth;
                patientContract.Gender = patient.Gender;
            }
            return patientContract;
        }
    }
}
