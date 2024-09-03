using BlitzSwitch.Misc;
using System.Windows;
using System.Windows.Controls;

namespace BlitzSwitch.UserControls
{
    public partial class StatusIndicator : UserControl
    {
        private string[] statusText = new string[2] { "DISABLED", "ENABLED" };
        private bool isStatusActive;
        public bool IsStatusActive
        {
            get => this.isStatusActive;
            set
            {
                this.isStatusActive = value;
                this.refreshVisualComponents(value);
            }
        }

        public StatusIndicator()
        {
            this.InitializeComponent();
            this.Loaded += StatusIndicator_Loaded;
        }

        private void StatusIndicator_Loaded(object sender, RoutedEventArgs e) =>
            this.IsStatusActive = ((MainWindow)Window.GetWindow(this)).isHotkeyListening;

        private void refreshVisualComponents(bool status)
        {
            switch (status)
            {
                case true:
                    this.StatusText.Text = statusText[1];
                    this.StatusBackground.Background = Collection.ColorCollection.enabledColor;
                    break;
                case false:
                    this.StatusText.Text = statusText[0];
                    this.StatusBackground.Background = Collection.ColorCollection.disabledColor;
                    break;
            }
        }
    }
}
