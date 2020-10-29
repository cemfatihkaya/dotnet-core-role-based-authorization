using System;

namespace WebApp.Core.Extensions
{
    public static class ObjectExtensions
    {
        public static int ToInt32(this object value)
        {
            return Convert.ToInt32(value);
        }

        public static bool ToBoolean(this object value)
        {
            return Convert.ToBoolean(value);
        }
    }
}