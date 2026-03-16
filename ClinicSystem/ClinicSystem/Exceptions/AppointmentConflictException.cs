using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicSystem.Exceptions
{
    public class AppointmentConflictException:Exception
    {
        public override string Message
        {
            get { return "Doctor already has an appointment on this date."; }
        }
    }
}
