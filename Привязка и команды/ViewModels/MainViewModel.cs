using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Привязка_и_команды.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        // ---- Поля для автоматических свойств ([ObservableProperty]) ----
        [ObservableProperty]
        private string defaultInput = "Текст с режимом привязки по умолчанию";

        [ObservableProperty]
        private string defaultNote = "Сообщение из визуальной модели";

        [ObservableProperty]
        private string userName = "Алексей";

        [ObservableProperty]
        private int rating = 65;

        [ObservableProperty]
        private bool notificationsEnabled = true;

        [ObservableProperty]
        private string selectedTheme = "Светлая";

        [ObservableProperty]
        private string sessionCode = "LR2-001";

        [ObservableProperty]
        private string currentTime = DateTime.Now.ToString("HH:mm:ss");

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
        private int triggerLevel = 45;

        [ObservableProperty]
        private bool isDangerMode;

        [ObservableProperty]
        private string selectedTriggerItem = "Обычный";

        [ObservableProperty]
        private int commandCount;

        // ---- Коллекции (инициализируются в конструкторе) ----
        public ObservableCollection<string> ThemeOptions { get; }
        public ObservableCollection<string> TriggerItems { get; }

        public MainViewModel()
        {
            ThemeOptions = new ObservableCollection<string> { "Светлая", "Контрастная", "Спокойная" };
            TriggerItems = new ObservableCollection<string> { "Обычный", "Важный", "Критический" };
        }

        // ---- Команды (методы с атрибутом [RelayCommand]) ----
        [RelayCommand]
        private void ResetDefault()
        {
            // Обращаемся к сгенерированным свойствам (DefaultInput, DefaultNote, CommandCount)
            DefaultInput = "Сброшено через команду";
            DefaultNote = "Кнопка использует ICommand";
            CommandCount++;
        }

        [RelayCommand]
        private void SaveTwoWay()
        {
            DefaultNote = $"Сохранено: {UserName}, рейтинг {Rating}";
            CommandCount++;
        }

        [RelayCommand]
        private void GenerateSessionCode()
        {
            SessionCode = "LR2-" + DateTime.Now.ToString("HHmmss");
            CurrentTime = DateTime.Now.ToString("HH:mm:ss");
            CommandCount++;
        }

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

        // Команда с параметром (тип object)
        [RelayCommand]
        private void ApplyExplicitBinding(object parameter)
        {
            if (parameter is TextBox textBox)
            {
                BindingExpression expression = textBox.GetBindingExpression(TextBox.TextProperty);
                expression?.UpdateSource();
            }
            CommandCount++;
        }

        [RelayCommand]
        private void ToggleDanger()
        {
            IsDangerMode = !IsDangerMode;
            CommandCount++;
        }
    }
}