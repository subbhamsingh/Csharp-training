using System;
using System.Collections.Generic;
using System.Text;

namespace SolidPrinciple.OCP
{
    // bad practise
    //If new customer type comes:VIP, Student, Corporate


    public class DiscountCalculator
    {
        public double Calculate(string type, double amount)
        {
            if (type == "Regular")
                return amount * 0.1;

            if (type == "Premium")
                return amount * 0.2;

            return 0;
        }
    }

    class RegularDiscount : IDiscount
    {
        public double Calculate(double amount)
        {
            return amount * 0.1;
        }
    }

    class PremiumDiscount : IDiscount
    {
        public double Calculate(double amount)
        {
            return amount * 0.2;
        }
    }

    // added new customer type without modifying the code
    class VipDiscount : IDiscount
    {
        public double Calculate(double amount)
        {
            return amount * 0.3;
        }
    }
}
