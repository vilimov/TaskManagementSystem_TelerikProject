using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Exeption;
using Team.Model.Enum;

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
        public static PriorityType ParsePriorityTypeParameter(string value, string errorMsg)
        {
            //bool.TryParse(value, out bool result);
            if (PriorityType.TryParse(value, true, out PriorityType result))
            {
                return result;
            }
            else
            {
                throw new InvalidUserInputException(errorMsg);
            }
        }
    }
    
}
