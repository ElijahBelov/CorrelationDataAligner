using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrelationDataAligner.Converters
{
    class DateConverter
    {
        public static DateTime GetDate(string date)
        {
            return DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        public static DateTime GetExcelDate(string date) {
            return DateTime.FromOADate(double.Parse(date));
        }

        internal static string GetString(DateTime date)
        {
            return String.Format("{0:0}", date.ToOADate());
        }
    }
}
