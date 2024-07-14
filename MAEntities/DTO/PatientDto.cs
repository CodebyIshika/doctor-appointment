using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAEntities.DTO
{
    public class PatientDto : UserDto
    {
        public bool IsUnderTreatment { get; set; }
        public string PreferredSpecialization { get; set; }
        public string PreferredClinicLocation { get; set; }
    }
}
