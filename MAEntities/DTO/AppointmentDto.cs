using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAEntities.DTO
{
    public class AppointmentDto
    {
        public DateTime AppointmentDateTime { get; set; }
        public string AppointmentStatus { get; set; }
        public string Location { get; set; }
    }
}
