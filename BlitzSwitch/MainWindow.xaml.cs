using BlitzSwitch.Misc;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace BlitzSwitch
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private bool isHotkeyListening = false;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsHotkeyListening
        {
            get => this.isHotkeyListening;
            set
            {
                if (this.isHotkeyListening != value)
                {
                    this.isHotkeyListening = value;
                    this.SwitchStateButton.Content = value ? "DISABLE" : "ENABLE";
                    this.OnPropertyChanged(nameof(IsHotkeyListening));
                }
            }
        }

        public MainWindow()
        {
            this.DataContext = this;
            this.InitializeComponent();
        }



        private void HeaderGrid_MouseDown(object sender, MouseButtonEventArgs e) =>
            this.DragMove();

        private void MinimizeWindowButton_Click(object sender, RoutedEventArgs e) =>
            this.WindowState = WindowState.Minimized;

        private void CloseWindowButton_Click(object sender, RoutedEventArgs e) =>
            Application.Current.Shutdown();

        private void HotkeyTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (Collection.allowedHotkeys.Contains(e.Key))
            {
                HotkeyTextBox.Text = e.Key.ToString();
            }
            e.Handled = true;
        }

        private void SetHotkeyButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AbortSettingHotkeyButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void HotkeyTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            this.isHotkeyListening = false;
            this.SetHotkeyButton.IsEnabled = true;
            this.AbortSettingHotkeyButton.IsEnabled = true;
        }

        private void HotkeyTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            this.SetHotkeyButton.IsEnabled = false;
            this.AbortSettingHotkeyButton.IsEnabled = false;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void SwitchStateButton_Click(object sender, RoutedEventArgs e) =>
            this.IsHotkeyListening = !this.IsHotkeyListening;

    }
}
