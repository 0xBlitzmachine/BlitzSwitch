using System.Windows;
using System.Windows.Input;

namespace BlitzSwitch
{
    public partial class MainWindow : Window
    {
        public MainWindow()
            => this.InitializeComponent();

        private void HeaderGrid_MouseDown(object sender, MouseButtonEventArgs e)
            => this.DragMove();

        private void MinimizeWindowButton_Click(object sender, RoutedEventArgs e)
            => this.WindowState = WindowState.Minimized;

        private void CloseWindowButton_Click(object sender, RoutedEventArgs e)
            => Application.Current.Shutdown();

        private void HotkeyTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            HotkeyTextBox.Text = e.Key.ToString();
        }
    }
}
