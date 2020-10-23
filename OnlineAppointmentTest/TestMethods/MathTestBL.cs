using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OnlineAppointment;

namespace OnlineAppointmentTest.TestMethods
{
    class MathTestBL
    {[SetUp]
        public void Setup()
        { }

        [Test]
        public void testsum()
        {
            var mathBL = new MathBL();
            int result = mathBL.sum(2, 3);
            Assert.IsTrue(result == 7);

        }
    }
}
