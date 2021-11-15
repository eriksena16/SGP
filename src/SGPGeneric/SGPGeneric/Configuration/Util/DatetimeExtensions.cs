
//using LuxGenerics.Entities;
//using System;

//namespace LuxGenerics.Utils
//{
//    public static class DatetimeExtensions
//    {
//        public static string ToString_ddMMyyyy_MMddyyyy(this DateTime? d, Language language)
//        {
//            return !d.HasValue ? string.Empty : d.Value.ToString_ddMMyyyy_MMddyyyy(language);
//        }
//        public static string ToString_ddMMyyyy_MMddyyyy(this DateTime d, Language language)
//        {
//            if (language == Language.en_US)
//            {
//                if (d.Year == DateTime.UtcNow.Year)
//                    return string.Format("{0:MM/dd/yy}", d);
//                else
//                    return string.Format("{0:MM/dd/yy}", d);
//            }
//            else
//            {
//                if (d.Year == DateTime.UtcNow.Year)
//                    return string.Format("{0:dd/MM/yy}", d);
//                else
//                    return string.Format("{0:dd/MM/yy}", d);
//            }
//        }
//    }
//}
