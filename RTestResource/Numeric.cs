using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomResource
{
    public class CustomResource
    {
        readonly Random _random = new Random(Guid.NewGuid().GetHashCode());

        public int RandomInt(int minValue = 0, int maxValue = 100)
        {
            return _random.Next(minValue, maxValue);
        }

        public double RandomDouble(double minValue = 0.0f, double maxValue = 100.0f)
        {
            return _random.NextDouble() * (maxValue - minValue) + minValue;
        }

        public bool RandomBool() {
            return RandomInt(0, 2) == 0;
        }
    }
}
