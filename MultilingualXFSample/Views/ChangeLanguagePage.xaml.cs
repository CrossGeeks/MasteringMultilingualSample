using MultilingualXFSample.ViewModels;
using Xamarin.Forms;

namespace MultilingualXFSample.Views
{
    public partial class ChangeLanguagePage : ContentPage
    {
        public ChangeLanguagePage()
        {
            InitializeComponent();
            BindingContext = new ChangeLanguageViewModel();
        }
    }
}
