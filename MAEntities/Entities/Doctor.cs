using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAEntities.Entities
{
    public class Doctor : User
    {
        public int DoctorId { get; set; }
        public string Specialization { get; set; }
        public string ClinicLocation { get; set; }
        public string Availability { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
