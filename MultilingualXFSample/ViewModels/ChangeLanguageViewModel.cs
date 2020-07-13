using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Input;
using MultilingualXFSample.Helpers;
using MultilingualXFSample.Models;
using MultilingualXFSample.Resources;
using Xamarin.Forms;

namespace MultilingualXFSample.ViewModels
{
    public class ChangeLanguageViewModel: INotifyPropertyChanged
    {
        public ObservableCollection<Language> Languages { get; set; }
        public Language SelectedLanguage { get; set; }

        public ICommand ChangeLangugeCommand { get; set; }

        public ChangeLanguageViewModel()
        {
            LoadLanguage();
            ChangeLangugeCommand = new Command(async() =>
            {
                LocalizationResourceManager.Instance.SetCulture(CultureInfo.GetCultureInfo(SelectedLanguage.CI));
                LoadLanguage();
                await App.Current.MainPage.DisplayAlert(AppResources.LanguageChanged, "", AppResources.Done);
            });

        }

        void LoadLanguage()
        {
            Languages = new ObservableCollection<Language>()
            {
                {new Language(AppResources.English, "en") },
                {new Language(AppResources.Spanish, "es") },
                {new Language(AppResources.French, "fr") }
            };
            SelectedLanguage = Languages.FirstOrDefault(pro => pro.CI == LocalizationResourceManager.Instance.CurrentCulture.TwoLetterISOLanguageName);
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

    }
}
