using System;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Привязка_и_команды.ViewModels
{
    public partial class OneWayBindingsViewModel : ObservableObject
    {
        [ObservableProperty]
        private int progress = 40;

        [ObservableProperty]
        private string oneWayText = "Источник изменяется только командой";

        [ObservableProperty]
        private string sourceFromTarget = "Введите текст в поле OneWayToSource";

        [ObservableProperty]
        private string updateOnPropertyChanged = "Меняется сразу";

        [ObservableProperty]
        private string updateOnLostFocus = "Меняется после потери фокуса";

        [ObservableProperty]
        private string updateExplicit = "Меняется после команды";

        [ObservableProperty]
        private int commandCount;

        [RelayCommand]
        private void IncreaseProgress()
        {
            Progress = Math.Min(100, Progress + 10);
            OneWayText = $"Прогресс увеличен до {Progress}%";
            CommandCount++;
        }

        [RelayCommand]
        private void DecreaseProgress()
        {
            Progress = Math.Max(0, Progress - 10);
            OneWayText = $"Прогресс уменьшен до {Progress}%";
            CommandCount++;
        }

        [RelayCommand]
        private void ApplyExplicitBinding(object parameter)
        {
            if (parameter is TextBox textBox)
            {
                var expression = textBox.GetBindingExpression(TextBox.TextProperty);
                expression?.UpdateSource();
            }
            CommandCount++;
        }
    }
}
