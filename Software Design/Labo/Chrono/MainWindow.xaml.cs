using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Chrono
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly DispatcherTimer timer = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartTimer(object seconder, RoutedEventArgs e)
        {
            TimeSpan time = new TimeSpan(0, 0, 0);
            timer.Interval = TimeSpan.FromSeconds(1); 
            timer.Tick += (s, e) =>
            {
                time = time.Add(TimeSpan.FromSeconds(1));
                Dispatcher.Invoke(() =>
                {
                    timeElapsedLabel.Content = time.ToString(@"hh\:mm\:ss");
                });
            };
            timer.Start();
        }

        private void StopTimer(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }
    }
}