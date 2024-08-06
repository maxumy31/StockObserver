
using System.Windows;
using StockObserver.Requests;
using StockObserver.Requests.Parsing;

namespace StockObserver
{
    public class MainApp : Application
    {
        [STAThread]
        static void Main(string[] args)
        {
            MainApp app = new MainApp();
            MainWindow window = new MainWindow();
            app.Run(window);
        }
    }

}
