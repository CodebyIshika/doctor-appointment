using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAEntities.Entities
{
    public class Patient : User
    {
        public int PatientID { get; set; }
        public bool IsUnderTreatment { get; set; }
        public string PreferredSpecialization { get; set; }
        public string PreferredClinicLocation { get; set; }

        public ICollection<Appointment> Appointments { get; set; }

    }
}
