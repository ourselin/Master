using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.PatientInformation
{
    public class PIDto
    {
        public String SubjectId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String Gender { get; set; }
    }

    public interface IPIManager
    {
        PIDto GetPI(String subjectId);
        List<PIDto> GetAllPI();
    }
}
