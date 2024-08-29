using System.Windows;
using System.Windows.Input;

namespace BlitzSwitch
{
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();
        private void HeaderGrid_MouseDown(object sender, MouseButtonEventArgs e) => this.DragMove();
    }
}
