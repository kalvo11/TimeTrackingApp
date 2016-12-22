using System;
using System.Windows;
using System.Windows.Threading;

namespace TimeTracker
{
    public partial class MainWindow : Window
    {
        double Seconds, Minutes, Hours = 0;
        DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CloseMainWindow()
        {
            MessageBoxResult MsgResult = MessageBox.Show("Sind Sie sicher, dass Sie Beenden wollen?", "Frage", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (MsgResult == MessageBoxResult.Yes)
            {
                Close();
            }
        }

        private void CloseClick(object sender, RoutedEventArgs e)
        {
            CloseMainWindow();
        }

        private void btnWorkStartStop_Click(object sender, RoutedEventArgs e)
        {
            if (!timer.IsEnabled)
            {
                btnWorkStartStop.Content = "Stop";
                timer.Tick += new EventHandler(timer_Tick);
                timer.Interval = new TimeSpan(0, 0, 1);
                timer.Start();
            }
            else
            {
                btnWorkStartStop.Content = "Start";
                timer.Stop();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Seconds++;

            if (Seconds == 60)
            {
                Seconds = 0;
                Minutes++;
            }

            if (Minutes == 60)
            {
                Minutes = 0;
                Hours++;
            }

            lblActiveSessionDuration.Content =
                Hours.ToString() + " Stunden " + Minutes.ToString() + " Minuten " + Seconds.ToString() + " Sekunden";
        }
    }
}