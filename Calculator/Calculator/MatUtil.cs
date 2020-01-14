using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class MatUtil
    {
        public static string DoubleToHex(double value)
        {
            if (value == 0 || double.IsInfinity(value) || double.IsNaN(value))
                return value.ToString();

            StringBuilder hex = new StringBuilder();

            long bytes = BitConverter.ToInt64(BitConverter.GetBytes(value), 0);

            bool negative = bytes < 0;
            bytes &= long.MaxValue;

            int exp = ((int)(bytes >> 52) & 0x7FF) - 0x3FF;
            bytes = (bytes & 0xFFFFFFFFFFFFF) | 0x10000000000000;

            if (exp < 0)
            {
                exp = -exp - 1;
                hex.Append("0.").Append('0', exp / 4);
                bytes <<= 3 - exp % 4;
                hex.Append(bytes.ToString("x").TrimEnd('0'));
            }
            else
            {
                bytes <<= (exp % 4);
                exp &= ~3;
                hex.Append(bytes.ToString("x"));
                if (exp >= 52)
                    hex.Append('0', (exp - 52) / 4);
                else
                {
                    hex.Insert(exp / 4 + 1, '.');
                    hex = new StringBuilder(hex.ToString().TrimEnd('0').TrimEnd('.'));
                }
            }
            if (negative) hex.Insert(0, '-');
            return hex.ToString();
        }

        public static bool isInGivenBase(String str, int bas)
        {
            if (bas > 16)
                return false;

            else if (bas <= 10)
            {
                for (int i = 0; i < str.Length; i++)
                    if (!(str[i] >= '0' &&
                          str[i] < ('0' + bas)))
                        return false;
            }

            else
            {
                for (int i = 0; i < str.Length; i++)
                    if (!((str[i] >= '0' &&
                            str[i] < ('0' + bas)) ||
                           (str[i] >= 'A' &&
                            str[i] < ('A' + bas - 10))
                        ))
                        return false;
            }
            return true;
        }

    }
}
