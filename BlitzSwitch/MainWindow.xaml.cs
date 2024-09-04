using BlitzSwitch.Hotkey;
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

        public HotkeyManager hotkeyManager;

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
            this.Loaded += MainWindow_Loaded;

            this.DataContext = this;

            this.InitializeComponent();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.hotkeyManager = new HotkeyManager(this);
            this.HotkeyTextBox.Text = this.hotkeyManager.Hotkey.ToString();
            this.hotkeyManager.RegisterHotkey();
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
                this.HotkeyTextBox.Text = e.Key.ToString();
            }
            e.Handled = true;
        }

        private void SetHotkeyButton_Click(object sender, RoutedEventArgs e)
        {
            if (hotkeyManager.RegisterHotkey())
                this.IsHotkeyListening = true;
        }

        private void AbortSettingHotkeyButton_Click(object sender, RoutedEventArgs e)
        {
            this.HotkeyTextBox.Text = this.hotkeyManager.Hotkey.ToString();
        }

        private void HotkeyTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            this.IsHotkeyListening = false;
            this.SwitchStateButton.IsEnabled = false;
            this.SetHotkeyButton.IsEnabled = true;
            this.AbortSettingHotkeyButton.IsEnabled = true;
        }

        private void HotkeyTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            this.SwitchStateButton.IsEnabled = true;
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
