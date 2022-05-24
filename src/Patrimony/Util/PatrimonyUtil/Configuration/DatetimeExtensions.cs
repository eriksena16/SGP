using System;

namespace SGP.Patrimony.Util.PatrimonyUtil
{
    public static class DatetimeExtensions
    {
        public static DateTime AddWeeks(this DateTime dateTime, int index)
        {
            dateTime = dateTime.AddDays(DayOfWeek.Monday - dateTime.DayOfWeek);
            return dateTime.AddDays(index * 7);
        }
        public static DateTime GetLastDayOfMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, DateTime.DaysInMonth(dateTime.Year, dateTime.Month));
        }
        public static DateTime ToEndOfDay(this DateTime date)
        {
            return date.Date.AddDays(1).AddTicks(-1);
        }
        public static string ToString_yyyyMMdd(this DateTime d)
        {
            return String.Format("{0:yyyy-MM-dd}", d);
        }
        #region
        //public static string ToString_ddMMyyyy_MMddyyyy(this DateTime? d, Language language)
        //{
        //    return !d.HasValue ? string.Empty : d.Value.ToString_ddMMyyyy_MMddyyyy(language);
        //}
        //public static string ToString_ddMMyyyy_MMddyyyy(this DateTime d, Language language)
        //{
        //    if (language == Language.en_US)
        //    {
        //        if (d.Year == DateTime.UtcNow.Year)
        //            return string.Format("{0:MM/dd/yy}", d);
        //        else
        //            return string.Format("{0:MM/dd/yy}", d);
        //    }
        //    else
        //    {
        //        if (d.Year == DateTime.UtcNow.Year)
        //            return string.Format("{0:dd/MM/yy}", d);
        //        else
        //            return string.Format("{0:dd/MM/yy}", d);
        //    }
        //}
        //public static string ToString_ddMM_MMdd(this DateTime d, Language language)
        //{
        //    if (language == Language.en_US)
        //    {
        //        if (d.Year == DateTime.UtcNow.Year)
        //            return string.Format("{0:MM/dd}", d);
        //        else
        //            return string.Format("{0:MM/dd/yy}", d);
        //    }
        //    else
        //    {
        //        if (d.Year == DateTime.UtcNow.Year)
        //            return string.Format("{0:dd/MM}", d);
        //        else
        //            return string.Format("{0:dd/MM/yy}", d);
        //    }
        //}
        #endregion
        public static string ToString_ddMMyyyy(this DateTime d)
        {
            return string.Format("{0:dd/MM/yyyy}", d);
        }
        public static string ToDate_ddMMyyyy(this string dateString)
        {
            var date = Convert.ToDateTime(dateString);

            return string.Format("{0:dd/MM/yyyy}", date);
        }
        public static string ToDate_ddMMyyyyHmm(this DateTime date)
        {
            return string.Format("{0:dd/MM/yyyy H:mm:ss}", date);
        }
    }
}
