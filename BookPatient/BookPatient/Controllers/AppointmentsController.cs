using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookPatient.Models;
using System.Collections;

namespace BookPatient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly appointmentContext _context;

        public AppointmentsController(appointmentContext context)
        {
            _context = context;
        }

        // GET: api/Appointments
        [HttpGet]
        public IEnumerable GetAppointment()
        {
            return _context.Appointment.ToList();
        }

        // GET: api/Appointments/5
        [HttpGet("{id}")]
        public async void GetAppointment(int id)
        {   

        }

        // PUT: api/Appointments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public void PutAppointment(int id)
        {

            

        }

        // POST: api/Appointments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public String PostAppointment([FromBody] Patient patient)
        {
            _context.Patient.Add(patient);
            _context.SaveChanges();
            return "Sucessfully Added";
        }

        // DELETE: api/Appointments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Appointment>> DeleteAppointment(int id)
        {
            var appointment = await _context.Appointment.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            _context.Appointment.Remove(appointment);
            await _context.SaveChangesAsync();

            return appointment;
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointment.Any(e => e.PatientNum == id);
        }
    }
}
