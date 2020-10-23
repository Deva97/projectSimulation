using System;
using System.Collections.Generic;

namespace BookPatient.Models
{
    public partial class Patient
    {
        public int PersonalId { get; set; }
        public string Pname { get; set; }
        public int? Age { get; set; }
        public string Address { get; set; }
        public int? PhoneNumber { get; set; }
    }
}
