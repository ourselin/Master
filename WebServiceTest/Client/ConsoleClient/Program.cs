using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (PatientInformation.PatientInformationClient proxy = new PatientInformation.PatientInformationClient("PatientInformation"))
            {
                using (new OperationContextScope(proxy.InnerChannel))
                {
                    PatientInformation.PIDataContracts res = proxy.GetPatientInformation("1");
                    PatientInformation.PIDataContracts[] res2 = proxy.GetAllPatientInformation();
                }
            }
        }

    }
}
