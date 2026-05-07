using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Привязка_и_команды.ViewModels
{
    public partial class OneTimeBindingViewModel : ObservableObject
    {
        [ObservableProperty]
        private string sessionCode = "LR2-001";

        [ObservableProperty]
        private string currentTime = DateTime.Now.ToString("HH:mm:ss");

        [ObservableProperty]
        private int commandCount;

        [RelayCommand]
        private void GenerateSessionCode()
        {
            SessionCode = "LR2-" + DateTime.Now.ToString("HHmmss");
            CurrentTime = DateTime.Now.ToString("HH:mm:ss");
            CommandCount++;
        }
    }
}
