using System;
using Android.Content;
using Android.Content.Res;
using Java.Util;

namespace MultilingualXFSample.Droid
{
    public static class LocaleUtil
    {
        public static void SetLocale(Context context, Locale locale)
        {
            Locale.Default = locale;
            Configuration configuration = context.Resources.Configuration;
            configuration.SetLocale(locale);
            configuration.SetLayoutDirection(locale);
            context.CreateConfigurationContext(configuration);
        }
    }
}
