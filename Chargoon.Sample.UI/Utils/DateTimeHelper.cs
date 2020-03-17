using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Chargoon.Sample.UI.Utils
{
    public static class DateTimeHelper
    {
        public static DateTime ToGregorianDate(string shamsiDate)
        {
            char spiliter = '-';
            if (shamsiDate.Contains("/"))
            {
                spiliter = '/';
            }
            var shamsi = shamsiDate.Split(spiliter);
            var y = int.Parse(shamsi[0]);
            var m = int.Parse(shamsi[1]);
            var d = int.Parse(shamsi[2]);
            DateTime dt = new DateTime();
            if (y < 1500)
            {
                PersianCalendar pc = new PersianCalendar();
                dt = new DateTime(y, m, d, pc);
            }
            else
            {
                dt = new DateTime(y, m, d);
            }
            return dt;
        }

        public static string ToJalaliDate(DateTime date)
        {
            try
            {
                PersianCalendar pc = new PersianCalendar();
                var jalali = string.Format("{0}-{1}-{2}", pc.GetYear(date), pc.GetMonth(date).ToString("00"), pc.GetDayOfMonth(date).ToString("00"));
                return jalali;
            }
            catch
            {
                return "";
            }
        }

        public static string ToJalaliDateTime(DateTime date)
        {
            PersianCalendar pc = new PersianCalendar();
            var jalali = string.Format("{0}-{1}-{2}  {3}:{4}", pc.GetYear(date), pc.GetMonth(date).ToString("00"), pc.GetDayOfMonth(date).ToString("00"), date.Hour, date.Minute);
            return jalali;
        }

        public static DateTime GregorianStringToDate(string date, string time)
        {

            char spiliter = '-';
            if (date.Contains("/"))
            {
                spiliter = '/';
            }
            var ymd = date.Split(spiliter);
            var hMs = time.Split(':');
            try
            {
                var convertedDate = new DateTime(int.Parse(ymd[0]), int.Parse(ymd[1]), int.Parse(ymd[2]), int.Parse(hMs[0]), int.Parse(hMs[1]), int.Parse(hMs[2]));
                return convertedDate;
            }

            catch
            {
                var convertedDate = new DateTime(int.Parse(ymd[2]), int.Parse(ymd[0]), int.Parse(ymd[1]), int.Parse(hMs[0]), int.Parse(hMs[1]), int.Parse(hMs[2]));
                return convertedDate;
            }

        }

        public static DateTime JalaliStringToGregorian(string datetime)
        {
            var splitDateTime = datetime.Split('T');
            var date = splitDateTime[0];
            var time = splitDateTime[1];
            char spiliter = '-';
            if (date.Contains("/"))
            {
                spiliter = '/';
            }
            var ymd = date.Split(spiliter);
            var hMs = time.Split(':');
            try
            {
                var GregorianDate = ToGregorianDate(date);
                var miladiDate = new DateTime(GregorianDate.Year, GregorianDate.Month, GregorianDate.Day, int.Parse(hMs[0]), int.Parse(hMs[1]), 0);
                return miladiDate;
            }

            catch
            {
                var miladiDate = new DateTime(int.Parse(ymd[2]), int.Parse(ymd[0]), int.Parse(ymd[1]), int.Parse(hMs[0]), int.Parse(hMs[1]), 0);
                return miladiDate;
            }

        }
    }
}