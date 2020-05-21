using System;
using System.Collections.Generic;
using System.Text;

namespace Webapi.Core.Common.Helper
{
    public class DateHelper
    {
        /// <summary>
        /// Stamp转datetime
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static DateTime StampToDateTime(string time)
        {
            time = time.Substring(0, 10);
            double timestamp = Convert.ToInt64(time);
            System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            dateTime = dateTime.AddSeconds(timestamp).ToLocalTime();
            return dateTime;
        }
    }
}
