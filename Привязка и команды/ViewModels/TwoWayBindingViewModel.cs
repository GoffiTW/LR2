using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Привязка_и_команды.ViewModels
{
    public partial class TwoWayBindingViewModel : ObservableObject
    {
        [ObservableProperty]
        private string userName = "Алексей";

        [ObservableProperty]
        private int rating = 65;

        [ObservableProperty]
        private bool notificationsEnabled = true;

        [ObservableProperty]
        private string selectedTheme = "Светлая";

        [ObservableProperty]
        private int commandCount;

        public ObservableCollection<string> ThemeOptions { get; }

        public TwoWayBindingViewModel()
        {
            ThemeOptions = new ObservableCollection<string> { "Светлая", "Контрастная", "Спокойная" };
        }

        [RelayCommand]
        private void SaveTwoWay()
        {
            CommandCount++;
        }
    }
}
