using Avalonia;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.Styling;
using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace avalonia_new.Services
{
    public static class LanguageManager
    {
        public static void ChangeLanguage(string languageCode)
        {
            CultureInfo newCulture = new CultureInfo(languageCode);
            CultureInfo.CurrentCulture = newCulture;
            CultureInfo.CurrentUICulture = newCulture;

            // Update all current bindings affected by the culture change
           // AvaloniaXamlLoader.Load(Application.Current);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(languageCode);

        }
        public static void Translate(string targetLanguage)
        {
            var translations = App.Current.Resources.MergedDictionaries.OfType<ResourceInclude>().FirstOrDefault(x => x.Source?.OriginalString?.Contains("/Lang/") ?? false);

            if (translations != null)
                App.Current.Resources.MergedDictionaries.Remove(translations);

            // var resource = AssetLoader.Open(new Uri($"avares://LocalizationSample/Assets/Lang/{targetLanguage}.axaml"));

            App.Current.Resources.MergedDictionaries.Add(
                new ResourceInclude(new Uri($"avares://avalonia_new/Assets/Lang/{targetLanguage}.axaml"))
                {
                    Source = new Uri($"avares://avalonia_new/Assets/Lang/{targetLanguage}.axaml")
                });
        }
    }
}
