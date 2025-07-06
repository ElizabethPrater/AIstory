using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AIstory.Utilities;

#nullable disable

namespace AIstory.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _playerInput;
        private string _storyLog = "Welcome, adventurer...\n";

        public string PlayerInput
        {
            get => _playerInput;
            set
            {
                _playerInput = value;
                OnPropertyChanged();
            }
        }

        public string StoryLog
        {
            get => _storyLog;
            set
            {
                _storyLog = value;
                OnPropertyChanged();
            }
        }

        public ICommand SubmitCommand { get; }

        public MainViewModel()
        {
            SubmitCommand = new RelayCommand(() => SendInput());
        }

        private async void SendInput()
        {
            // Display player input in the story log
            StoryLog += $"\n> {PlayerInput}\n";

            // Simulated AI response for now
            string response = await Services.AiService.GetAIResponse(PlayerInput);

            // Append response
            StoryLog += $"{response}\n";

            // Clear input box
            PlayerInput = string.Empty;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName!));
    }
}

