using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCHttpClient.Models
{
    public partial class Appointment
    {
        public int? PatientNum { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public string Confirmation { get; set; }
    }
    public class AppointmentContext : DbContext
    {
        public DbSet<Appointment> appointments { get; set; }
    }
}