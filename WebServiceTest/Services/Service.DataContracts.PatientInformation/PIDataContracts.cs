using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Service.DataContracts.PatientInformation
{
    [DataContract]
    public class PIDataContracts : IExtensibleDataObject
    {
        #region IExtensibleDataObject implements
        private ExtensionDataObject extensionDataObject_value;
        public ExtensionDataObject ExtensionData
        {
            get
            {
                return extensionDataObject_value;
            }
            set
            {
                extensionDataObject_value = value;
            }
        }
        #endregion

        [DataMember]
        public String SubjectId { get; set; }
        [DataMember]
        public String FirstName { get; set; }
        [DataMember]
        public String LastName { get; set; }
        [DataMember]
        public DateTime DateOfBirth { get; set; }
        [DataMember]
        public String Gender { get; set; }
    }
}
