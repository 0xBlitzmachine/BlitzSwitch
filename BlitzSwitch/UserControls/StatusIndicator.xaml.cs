using System.ComponentModel;
using System.Windows.Controls;

namespace BlitzSwitch.UserControls
{
    public partial class StatusIndicator : UserControl, INotifyPropertyChanged
    {
        private bool isStatusActive;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsStatusActive
        {
            get => this.isStatusActive;
            set
            {
                if (this.isStatusActive != value)
                {
                    this.isStatusActive = value;
                    this.OnPropertyChanged(nameof(IsStatusActive));
                }
            }
        }

        public StatusIndicator()
        {
            this.DataContext = this;
            this.InitializeComponent();
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
