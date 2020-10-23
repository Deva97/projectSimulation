using Moq;
using NUnit.Framework;
using OnlineAppointment.BusinessLogic;
using OnlineAppointment.DataAccess;
using OnlineAppointment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineAppointmentTest.TestMethod
{
    class AppointmentTestBL
    {
        private Mock<IEntityRepository<Appointment>> appointmentRepo;
        private List<Appointment> appointments;
        [SetUp]
        public void Setup()
        {
            appointmentRepo = new Mock<IEntityRepository<Appointment>>();
            appointments = new List<Appointment>();
            appointments.Add(new Appointment() { PatientNum = 3, PatientName = "John", Confirmation = "yes", DoctorName = "dr xxx" });
            appointments.Add(new Appointment() { PatientNum = 4, PatientName = "John1", Confirmation = "yes", DoctorName = "dr xxx1" });
            appointments.Add(new Appointment() { PatientNum = 5, PatientName = "John2", Confirmation = "yes", DoctorName = "dr xxx2" });
         }
        [Test]
        public void TestGetActiveRecords()
        {
            appointmentRepo.Setup(a => a.GetAllQuerable()).Returns(appointments.AsQueryable());

            var appointmentBL = new AppointmentBL(appointmentRepo.Object);
            var appointmentList = appointmentBL.GetActiveCustomer();
            Assert.IsTrue(appointmentList.Count >=0);
            Assert.IsTrue(appointmentList.All(s => s.Confirmation == "yes"));
        }
    }

}
