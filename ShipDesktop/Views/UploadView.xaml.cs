using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ShipDesktop.ViewModels;

namespace ShipDesktop.Views
{
    public partial class UploadView : UserControl
    {
        public UploadView()
        {
            InitializeComponent();
            DataContext = new UploadViewModel();
        }

        

    }
}
