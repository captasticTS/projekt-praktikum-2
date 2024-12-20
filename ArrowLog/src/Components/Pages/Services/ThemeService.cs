using Blazored.LocalStorage;
namespace ArrowLog.Components.Pages.Services
{
    public class ThemeService
    {
        private readonly ILocalStorageService _localStorage;
        private bool _isDarkMode;

        public ThemeService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
            InitializeThemeAsync();
        }

        private async void InitializeThemeAsync()
        {
            var darkMode = await _localStorage.GetItemAsync<bool?>("darkMode");
            if (darkMode.HasValue)
            {
                _isDarkMode = darkMode.Value;
                NotifyStateChanged();
            }
        }
        public bool IsDarkMode
        {
            get => _isDarkMode;
            set
            {
                _isDarkMode = value;
                _localStorage.SetItemAsync("darkMode", value);
                NotifyStateChanged();
            }
        }

        public event Action? OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
