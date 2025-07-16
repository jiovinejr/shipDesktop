using ShipDesktop.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShipDesktop.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private object? _currentView;
        public object? CurrentView
        {
            get => _currentView;
            set { _currentView = value; OnPropertyChanged(); }
        }

        private string _selectedPage = "Home";
        public string SelectedPage
        {
            get => _selectedPage;
            set { _selectedPage = value; OnPropertyChanged(); }
        }

        public ICommand NavigateCommand { get; }

        public MainViewModel()
        {
            NavigateCommand = new RelayCommand(Navigate);
            CurrentView = new HomeView();
        }

        private void Navigate(object? pageName)
        {
            if (pageName is string page)
            {
                SelectedPage = page;
                switch (page)
                {
                    case "Home":
                        CurrentView = new HomeView();
                        break;
                    case "Upload":
                        CurrentView = new UploadView();
                        break;
                }
            }
        }
    }

}
