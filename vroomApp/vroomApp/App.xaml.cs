using System.Text.Json.Serialization;

namespace vroomApp
{
    public partial class App : Application
    {
        public static string DatabasePath { get; private set; }
        public App()
        {
            InitializeComponent();
            DatabasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "vroomApp.db");

            MainPage = new MainPage();
            
        }
    }
}
