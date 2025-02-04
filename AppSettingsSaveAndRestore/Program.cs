namespace AppSettingsSaveAndRestore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppSettings settings = new AppSettings("Light", 12);
            SettingsManager manager = new SettingsManager();

            // Сохраняем настройки
            manager.SaveSettings(settings);

            // Меняем тему и размер шрифта
            settings.SetTheme("Dark");
            settings.SetFontSize(14);

            Console.WriteLine("Current Theme: " + settings.GetTheme()); // Dark
            Console.WriteLine("Current Font Size: " + settings.GetFontSize()); // 14

            // Восстанавливаем предыдущие настройки
            manager.LoadSettings(settings);

            Console.WriteLine("Current Theme: " + settings.GetTheme()); // Light
            Console.WriteLine("Current Font Size: " + settings.GetFontSize()); // 12
        }
    }

    // Класс Memento
    class SettingsMemento
    {
        public readonly string Theme;
        public readonly int FontSize;

        public SettingsMemento(string theme, int fontSize)
        {
            Theme = theme;
            FontSize = fontSize;
        }
    }

    // Класс Originator
    class AppSettings
    {
        private string theme;
        private int fontSize;

        public AppSettings(string theme, int fontSize)
        {
            this.theme = theme;
            this.fontSize = fontSize;
        }

        public void SetTheme(string theme)
        {
            this.theme = theme;
        }

        public void SetFontSize(int fontSize)
        {
            this.fontSize = fontSize;
        }

        public string GetTheme()
        {
            return theme;
        }

        public int GetFontSize()
        {
            return fontSize;
        }

        // Метод для создания хранителя (memento)
        public SettingsMemento CreateMemento()
        {
            return new SettingsMemento(theme, fontSize);
        }

        // Метод для восстановления состояния из хранителя
        public void RestoreFromMemento(SettingsMemento memento)
        {
            theme = memento.Theme;
            fontSize = memento.FontSize;
        }
    }

    // Класс Caretaker
    class SettingsManager
    {
        private SettingsMemento savedSettings;

        public void SaveSettings(AppSettings settings)
        {
            savedSettings = settings.CreateMemento();
        }

        public void LoadSettings(AppSettings settings)
        {
            if (savedSettings != null)
            {
                settings.RestoreFromMemento(savedSettings);
            }
        }
    }
}
