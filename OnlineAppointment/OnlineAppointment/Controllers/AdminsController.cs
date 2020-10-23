using System;
using System.Collections;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OnlineAppointment.Models;
using Microsoft.Extensions.Configuration;

namespace OnlineAppointment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly AppointmentContext _context;
        readonly string LOG_CONFIG_FILE = @"log4net.config";
        readonly log4net.ILog _log = log4net.LogManager.GetLogger(typeof(AdminsController));
        
        [NonAction]
        public void Log4NetMessage(string type, string message)
        {
            string logMessage = message;
            switch (type)
            {
                case "Info":
                    _log.Info(logMessage);
                    break;
                case "Error":
                    _log.Error(logMessage);
                    break;
                case "Fatal":
                    _log.Fatal(logMessage);
                    break;
                default:
                    _log.Info(logMessage);
                    break;
            }
        }
        public IConfiguration _configuration;
      
        public AdminsController(IConfiguration config,AppointmentContext context)
        {
            _configuration = config;
            _context = context;
        }
        // GET: api/Admins
        [HttpGet]
        public IEnumerable GetPateints()
        {
            return _context.Patient.ToList();
        }

        // GET: api/Admins/5
        [HttpGet("{id}")]
        public string GetDoctor(int id, String req)
        {
            Log4NetMessage("info","AdminController HttpGet");
            var obj = _context.Patient.Find(id);
            var doc = _context.Doctor.FirstOrDefault(b => b.Available == "YES" && b.Speciality == req);
            Appointment appoint = new Appointment { PatientNum = obj.PersonalId, PatientName = obj.Pname, DoctorName = doc.Name, Confirmation = "YES" };
            _context.Appointment.Add(appoint);
            _context.SaveChanges();
            return appoint.ToString();
            
            
        }

        // PUT: api/Admins/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public void PutAdmin(int id, Admin admin)
        {
           
        }

        // POST: api/Admins
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult PostAdmin(Appointment appointment)
        {
            int userid = (int)appointment.PatientNum;
            string inq = "ENT";
            var patient = _context.Patient.Find(userid);
            if (patient == null)
                return BadRequest("Invalid request.User not found.Please register");
            else
            {
                Appointment appoint = new Appointment();
                appoint.PatientNum = userid;
                appoint.PatientName = patient.Pname;
                var doc = _context.Doctor.FirstOrDefault(b => b.Speciality == inq);
                if (doc == null) return BadRequest();
                appoint.DoctorName = doc.Name;
                appoint.Confirmation = doc.Available;
                _context.Appointment.Add(appoint);
                _context.SaveChanges();




            }
            return Ok();
        }
      

        // DELETE: api/Admins/5
        [HttpDelete("{id}")]
        
        public  String DeleteAdmin(int id)
        {
            Patient obj = _context.Patient.Find(id);
            _context.Patient.Remove(obj);
            _context.SaveChanges();
            return "Deleted Sucessfull";
            
        }
        
        private bool AdminExists(int id)
        {
            return _context.Admin.Any(e=>e.UserId==id);
        }
    }
}
