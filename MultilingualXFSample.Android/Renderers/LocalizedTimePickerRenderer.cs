using System.ComponentModel;
using Android.App;
using Android.Content;
using Java.Util;
using MultilingualXFSample.Controls;
using MultilingualXFSample.Droid.Renderers;
using MultilingualXFSample.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(LocalizedTimePicker), typeof(LocalizedTimePickerRenderer))]
namespace MultilingualXFSample.Droid.Renderers
{
    public class LocalizedTimePickerRenderer : TimePickerRenderer
    {
        TimePickerDialog _dialog;

        public LocalizedTimePickerRenderer(Context context) : base(context) { }

        protected override TimePickerDialog CreateTimePickerDialog(int hours, int minutes)
        {
            var picker = Element as LocalizedTimePicker;

            var locale = new Locale(LocalizationResourceManager.Instance.CurrentCulture.TwoLetterISOLanguageName);
            LocaleUtil.SetLocale(Context, locale);
            Control.TextLocale = locale;

            _dialog = base.CreateTimePickerDialog(hours, minutes);

            UpdateTextButton((int)DialogButtonType.Positive, picker.PositiveActionText);
            UpdateTextButton((int)DialogButtonType.Negative, picker.NegativeActionText);

            return _dialog;
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            var picker = Element as LocalizedTimePicker;

            if (e.PropertyName == LocalizedTimePicker.PositiveActionTextProperty.PropertyName)
            {
                UpdateTextButton((int)DialogButtonType.Positive, picker.PositiveActionText);

            }else if (e.PropertyName == LocalizedTimePicker.NegativeActionTextProperty.PropertyName)
            {
                UpdateTextButton((int)DialogButtonType.Negative, picker.NegativeActionText);
            }
        }

        public void UpdateTextButton(int buttonIndex, string text)
        {
            _dialog?.SetButton(buttonIndex, text, (sender, e) => { });
        }
    }
}


