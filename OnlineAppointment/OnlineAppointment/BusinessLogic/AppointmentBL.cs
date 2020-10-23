using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineAppointment.DataAccess;
using OnlineAppointment.Models;

namespace OnlineAppointment.BusinessLogic
{
    public class AppointmentBL
    { private IEntityRepository<Appointment> _appointmentRepo { get; set; }
        private IEntityRepository<Patient> _patientRepo { get; set; }
        public AppointmentBL(IEntityRepository<Appointment> appointmentRepo)
        {
            _appointmentRepo = appointmentRepo;

        }
        public List<Appointment> GetActiveCustomer()
        {
            var result = new List<Appointment>();
            result = _appointmentRepo.GetAllQuerable().Where(s => s.Confirmation == "YES").ToList();
            return result;

        }

        public bool SaveCustomer(Appointment appointment)
        {
          var check=  _patientRepo.GetAllQuerable().First(s => s.PersonalId == appointment.PatientNum);
            if (check != null)
            {
                _appointmentRepo.Insert(appointment);
                return true;
            }
            return false;



        }
    }
}
