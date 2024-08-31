using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace BlitzSwitch
{
    public partial class MainWindow : Window
    {

        private bool isEnabled = false;

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

        private void SetHotkeyButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AbortSettingHotkeyButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void HotkeyTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            SetHotkeyButton.IsEnabled = true;
            AbortSettingHotkeyButton.IsEnabled = true;
        }

        private void HotkeyTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            SetHotkeyButton.IsEnabled = false;
            AbortSettingHotkeyButton.IsEnabled = false;
        }

        private void SwitchStateButton_Click(object sender, RoutedEventArgs e)
        {
            this.isEnabled = !this.isEnabled;
            this.SwitchStateVisually(isEnabled);
        }

        private void SwitchStateVisually(bool isEnabled)
        {
            SolidColorBrush enabledColor = Application.Current.TryFindResource("EnabledColor") as SolidColorBrush;
            SolidColorBrush disabledColor = Application.Current.TryFindResource("DisabledColor") as SolidColorBrush;

            switch (isEnabled)
            {
                case true:
                    this.BorderBrush = enabledColor;
                    this.HeaderGrid.Background = enabledColor;
                    this.HeaderStatusLabel.Text = "ENABLED";
                    SwitchStateButton.Content = "DISABLE";
                    break;
                default:
                    this.BorderBrush = disabledColor;
                    this.HeaderGrid.Background = disabledColor;
                    this.HeaderStatusLabel.Text = "DISABLED";
                    SwitchStateButton.Content = "ENABLE";
                    break;
            }
        }
    }
}
