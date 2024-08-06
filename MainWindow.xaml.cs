using StockObserver.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StockObserver
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RequestServer _server;
        System.Timers.Timer _updateTimer;
        public MainWindow()
        {
            InitializeComponent();

            _server = RequestServer.GetInstance();
            _updateTimer = new System.Timers.Timer(1000);
            _updateTimer.Elapsed += OnTimeout;
            _updateTimer.AutoReset = true;
            _updateTimer.Enabled = true;
            
            Update();
        }

        private void OnTimeout(Object source, ElapsedEventArgs e)
        {
            _server.MakeNewRequest();
            Update();
        }

        public void Update()
        {
            var currentValue = _server.LastRoot.GetDataByColumnId(_server.LastRoot.FindColumnId("CURRENTVALUE"));
            this.Dispatcher.Invoke(() =>
            {
                CurrentValueTextBlock.Text = currentValue;
                LastUpdateText.Text = _server.LastUpdateTime.ToString();
            });
        }
    }
}
