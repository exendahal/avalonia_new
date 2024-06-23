using Avalonia.Preferences;

namespace avalonia_new.Services
{
    public static class PreferenceService
    {
        private static Preferences _preferences = new Preferences();
        public static void SetValue(string key, string value)
        {
           _preferences.Set(key, value);
        }
        public static string? GetValue(string key)
        {
            if (_preferences.ContainsKey(key))
            {
                return _preferences.Get(key, string.Empty);
            }
            return string.Empty;
        }
    }
}
