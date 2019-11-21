using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleToBinary
{
    public static class BinaryConverter
    {
        public static string DoubleToBinary(double number)
        {
            long integer64bit = BitConverter.DoubleToInt64Bits(number);

            return Convert.ToString(integer64bit, 2).PadLeft(64, '0');
        }
    }
}