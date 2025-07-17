using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ShipDesktop.ViewModels
{
    public class UploadViewModel : BaseViewModel
    {
        private string? _droppedFilePath;
        public string? DroppedFilePath
        {
            get => _droppedFilePath;
            set
            {
                _droppedFilePath = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(HasFile));
                (LogFileCommand as RelayCommand)?.RaiseCanExecuteChanged();
            }
        }

        public bool HasFile => !string.IsNullOrWhiteSpace(DroppedFilePath);

        public ICommand LogFileCommand { get; }

        public UploadViewModel()
        {
            LogFileCommand = new RelayCommand(_ => LogFile(), _ => HasFile);
        }

        private void LogFile()
        {
            Console.WriteLine($"📄 File to log: {DroppedFilePath}");
            // You could also log to a file or service here
        }
    }

}
