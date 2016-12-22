using System.Windows;

namespace TimeTracker
{
    public partial class MainWindow : Window
    {
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
    }
}