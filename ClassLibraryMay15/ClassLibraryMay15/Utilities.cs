using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryMay15
{
    public static class Utilities
    {
        public static bool IsZeroOrPositive(int value)
        {
            bool result;

            if (value < 0)
            {
                result = false;
            }
            else
            {
                result = true;
            }

            return result;
        }
        // overloaded method to allow for both int and double values
        public static bool IsZeroOrPositive(double value)
        {
            bool result;

            if (value < 0)
            {
                result = false;
            }
            else
            {
                result = true;
            }

            return result;
        }
    }
}
