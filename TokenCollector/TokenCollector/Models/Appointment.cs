using System;
using System.Collections.Generic;

namespace TokenCollector.Models
{
    public partial class Appointment
    {
        public int? PatientNum { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public string Confirmation { get; set; }
    }
}
