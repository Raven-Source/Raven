using System;
using System.IO;

namespace Raven.Util
{
    /// <summary>
    /// 
    /// </summary>
    public static class EncodeHelper
    {
        public readonly static char[] array = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '-', '_' };

        #region 64位

        /// <summary>
        /// long转64进制
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Parse64Encode(long value)
        {
            int digitIndex = 0;
            long longPositive = value > 0 ? value : value * -1;
            int radix = 64;//64进制
            char[] outDigits = new char[65];
            for (digitIndex = 0; digitIndex <= 64; digitIndex++)
            {
                if (longPositive == 0) { break; }
                outDigits[outDigits.Length - digitIndex - 1] = array[longPositive % radix];
                longPositive /= radix;
            }
            return new string(outDigits, outDigits.Length - digitIndex, digitIndex);
        }

        /// <summary>
        /// 64进制转long
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long Parse64Decode(string value)
        {
            int fromBase = 64;
            value = value.Trim();
            if (string.IsNullOrEmpty(value))
            {
                return 0L;
            }
            string sDigits = new string(array, 0, fromBase);
            long result = 0;
            for (int i = 0; i < value.Length; i++)
            {
                if (!sDigits.Contains(value[i].ToString()))
                {
                    throw new ArgumentException(string.Format("The argument \"{0}\" is not in {1} system", value[i], fromBase));
                }
                else
                {
                    try
                    {
                        int index = 0;
                        for (int xx = 0; xx < array.Length; xx++)
                        {
                            if (array[xx] == value[value.Length - i - 1])
                            {
                                index = xx;
                            }
                        }
                        result += (long)Math.Pow(fromBase, i) * index;//   2
                    }
                    catch
                    {
                        throw new OverflowException("运算溢出");
                    }
                }
            }
            return result;
        }

        #endregion

    }
}
