using System;
using System.Linq;
using Android.App;
using Android.Text;
using Android.Text.Style;
using MultilingualXFSample.Droid;
using Plugin.CurrentActivity;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using static MultilingualXFSample.Effects.PickerDoneButtonEffect;

[assembly: ResolutionGroupName("MyCompany")]
[assembly: ExportEffect(typeof(AndroidPickerDoneButtonEffect), nameof(PickerDoneButton))]
namespace MultilingualXFSample.Droid
{
    public class AndroidPickerDoneButtonEffect : PlatformEffect
	{
		AlertDialog _dialog;
		PickerDoneButton _effect;

		protected override void OnAttached()
		{
			_effect = (PickerDoneButton)Element.Effects.FirstOrDefault(e => e is PickerDoneButton);

			if (_effect != null && Control != null && Element is Picker)
			{
                 Control.Click += ShowDialog;
			}
		}

        private void ShowDialog(object sender, EventArgs e)
        {
			var model = Element as Picker;
			if (_dialog == null && model != null)
			{
				using (var builder = new AlertDialog.Builder(CrossCurrentActivity.Current.Activity))
				{
					if (!model.IsSet(Picker.TitleColorProperty))
					{
						builder.SetTitle(model.Title ?? "");
					}
					else
					{
						var title = new SpannableString(model.Title ?? "");
						title.SetSpan(new ForegroundColorSpan(model.TitleColor.ToAndroid()), 0, title.Length(), SpanTypes.ExclusiveExclusive);

						builder.SetTitle(title);
					}

					string[] items = model.Items.ToArray();
					builder.SetItems(items, (s, e) => ((IElementController)model).SetValueFromRenderer(Picker.SelectedIndexProperty, e.Which));

					builder.SetNegativeButton(_effect.ButtonTitle, (o, args) => { });

					((IElementController)model).SetValueFromRenderer(VisualElement.IsFocusedPropertyKey, true);

					_dialog = builder.Create();
				}
				_dialog.SetCanceledOnTouchOutside(true);
				_dialog.DismissEvent += (sender, args) =>
				{
					(model as IElementController)?.SetValueFromRenderer(VisualElement.IsFocusedPropertyKey, false);
					_dialog?.Dispose();
					_dialog = null;
				};
				_dialog.Show();
			}
		}

        protected override void OnDetached()
		{
			Control.Click -= ShowDialog;
		}
	}
}
