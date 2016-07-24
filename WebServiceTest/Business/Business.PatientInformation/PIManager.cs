using DAL.PatientInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.PatientInformation
{
    public class PIManager : IPIManager
    {
        List<Patient> myList;
        public PIManager()
        {
            myList = new List<Patient>()
            {
                new Patient() { Id = "1", Dob = DateTime.Now, Firstname = "nicolas", Lastname = "novellas", Gender = "M" },
                new Patient() { Id = "2", Dob = DateTime.Now, Firstname = "pierre", Lastname = "paul", Gender = "M" },
                new Patient() { Id = "3", Dob = DateTime.Now, Firstname = "fabrice", Lastname = "lamy", Gender = "M" },
                new Patient() { Id = "4", Dob = DateTime.Now, Firstname = "yann", Lastname = "toupin", Gender = "M" },
                new Patient() { Id = "5", Dob = DateTime.Now, Firstname = "sonia", Lastname = "choubrac", Gender = "F" },
                new Patient() { Id = "6", Dob = DateTime.Now, Firstname = "adeline", Lastname = "brasseur", Gender = "F" },
                new Patient() { Id = "7", Dob = DateTime.Now, Firstname = "olivier", Lastname = "revelat", Gender = "M" }
            };

        }

        List<PIDto> IPIManager.GetAllPI()
        {
            try
            {
                using (DEMOEntities ctx = new DEMOEntities())
                {
                    var patients = (
                                        from p in myList//ctx.Patient
                                        select new PIDto()
                                        {
                                            SubjectId = p.Id,
                                            FirstName = p.Firstname,
                                            LastName = p.Lastname,
                                            DateOfBirth = p.Dob,
                                            Gender = p.Gender
                                        }
                                   ).ToList();
                   return patients;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        PIDto IPIManager.GetPI(string subjectId)
        {
            try
            {
                using (DEMOEntities ctx = new DEMOEntities())
                {
                    var patients = (
                                        from p in myList//ctx.Patient
                                        where p.Id == subjectId
                                        select new PIDto()
                                        {
                                            SubjectId = p.Id,
                                            FirstName = p.Firstname,
                                            LastName = p.Lastname,
                                            DateOfBirth = p.Dob,
                                            Gender = p.Gender
                                        }
                                   );


                    PIDto result = patients.FirstOrDefault();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
