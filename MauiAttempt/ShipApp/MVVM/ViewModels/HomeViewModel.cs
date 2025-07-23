using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShipApp.Service;
using ShipApp.MVVM.Models;

namespace ShipApp.MVVM.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public ObservableCollection<FileUpload> FilesToProcess { get; set; }

        public HomeViewModel() 
        {
            var service = new FileUploadService();
            FilesToProcess = service.GetFilesToProcess();
        }
    }
}
