using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Привязка_и_команды.ViewModels
{
    public partial class TriggersViewModel : ObservableObject
    {
        [ObservableProperty]
        private int triggerLevel = 45;

        [ObservableProperty]
        private bool isDangerMode;

        [ObservableProperty]
        private string selectedTriggerItem = "Обычный";

        [ObservableProperty]
        private int commandCount;

        public ObservableCollection<string> TriggerItems { get; }

        public TriggersViewModel()
        {
            TriggerItems = new ObservableCollection<string> { "Обычный", "Важный", "Критический" };
        }

        [RelayCommand]
        private void ToggleDanger()
        {
            IsDangerMode = !IsDangerMode;
            CommandCount++;
        }
    }
}
