using ClinicSystem.RelationShips;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicSystem.Interfaces
{
    public  interface IAvailable
    {
        bool CheckAvailability(DateTime date, List<Appointement> appointements);
    }
}
