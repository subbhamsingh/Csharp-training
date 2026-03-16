using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicSystem.Exceptions
{
    public class PatientNotFoundException:Exception
    {
        public override string Message
        {
            get { return "Patient not found in the system."; }
        }
    }
}
