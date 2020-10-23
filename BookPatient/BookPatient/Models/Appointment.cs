using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookPatient.Models
{
    public partial class Appointment
    {    [Key]
        public int PatientNum { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public string Confirmation { get; set; }
    }
}
