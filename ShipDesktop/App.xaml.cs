using System.Configuration;
using System.Data;
using System.Windows;
using Npgsql;

namespace ShipDesktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private HttpServer _httpServer = new HttpServer();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Start HTTP server at app launch
            _httpServer.Start("http://100.125.51.23:5000/");

        }
    }

}
