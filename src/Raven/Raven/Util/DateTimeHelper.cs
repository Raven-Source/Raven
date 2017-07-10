using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raven.Util
{
    /// <summary>
    /// 
    /// </summary>
    public static class DateTimeHelper
    {
        /// <summary>
        /// Unix时间戳
        /// </summary>
        public static readonly DateTime UnixTimestamp = new DateTime(1970, 1, 1);
        
        /// <summary>
        /// 获取当前时间的毫秒数（向下取整）
        /// </summary>
        /// <returns></returns>
        public static long GetCurrentTimeTotalMilliseconds()
        {
            return Convert.ToInt64(Math.Floor(DateTime.Now.Subtract(UnixTimestamp).TotalMilliseconds));
        }
        

        /// <summary>
        /// 获取当前时间的天数（向下取整）
        /// </summary>
        /// <returns></returns>
        public static long GetCurrentTimeTotalDays()
        {
            return Convert.ToInt64(Math.Floor(DateTime.Now.Subtract(UnixTimestamp).TotalDays));
        }
        
        /// <summary>
        /// 获取指定日期的天数（向下取整）
        /// </summary>
        /// <param name="appointDay"></param>
        /// <returns></returns>
        public static long GetAppointTimeTotalDays(DateTime appointDay)
        {
            return Convert.ToInt64(Math.Floor(appointDay.Subtract(UnixTimestamp).TotalDays));
        }
        

    }

}
