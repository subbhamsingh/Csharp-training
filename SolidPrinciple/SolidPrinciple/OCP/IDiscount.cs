using System;
using System.Collections.Generic;
using System.Text;

namespace SolidPrinciple.OCP
{
    public interface IDiscount
    {
        double Calculate(double amount);
    }
}
