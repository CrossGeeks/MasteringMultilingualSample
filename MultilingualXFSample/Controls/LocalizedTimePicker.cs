using System;
using MultilingualXFSample.Resources;
using Xamarin.Forms;

namespace MultilingualXFSample.Controls
{
    public class LocalizedTimePicker : TimePicker
    {
		public static readonly BindableProperty PositiveActionTextProperty = BindableProperty.Create(nameof(PositiveActionText), typeof(string), typeof(LocalizedDatePicker), AppResources.Update);

		public string PositiveActionText
		{
			get { return (string)GetValue(PositiveActionTextProperty); }
			set
			{
				SetValue(PositiveActionTextProperty, value);
			}
		}

		public static readonly BindableProperty NegativeActionTextProperty = BindableProperty.Create(nameof(NegativeActionText), typeof(string), typeof(LocalizedDatePicker), AppResources.Cancel);

		public string NegativeActionText
		{
			get { return (string)GetValue(NegativeActionTextProperty); }
			set
			{
				SetValue(NegativeActionTextProperty, value);
			}
		}
	}
}
