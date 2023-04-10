using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team
{
    public static class Validator
    {
        public static void ValidateIntRange(int value, int min, int max, string message)
        {
            if (value < min || value > max)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ValidateStringLength(int value, int min, int max, string message)
        {
            if (value < min || value > max)
            {
                throw new ArgumentOutOfRangeException(message);
            }
        }
    }
}
