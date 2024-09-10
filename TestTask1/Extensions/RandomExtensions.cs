using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxesAndPallest.Extensions
{
    public static class RandomExtensions
    {
        public static double GetRandomValue(this Random _random, double minValue, double maxValue)
        {
            if (minValue < maxValue)
            {
                return _random.NextDouble() * (maxValue - minValue) + minValue;
            }
            else
            {
                throw new ArgumentException("Parameters minValue (1st parameter) must be less than 2nd one");
            }

        }
    }
}
