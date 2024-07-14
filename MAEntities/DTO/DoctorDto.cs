using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAEntities.DTO
{
    public class DoctorDto : UserDto
    {
        public string Specialization { get; set; }
        public string ClinicLocation { get; set; }
        public string Availability { get; set; }
    }
}
