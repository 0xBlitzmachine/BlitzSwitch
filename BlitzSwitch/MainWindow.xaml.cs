﻿using BlitzSwitch.Misc;
using System.Windows;
using System.Windows.Input;

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
            this.SetHotkeyButton.IsEnabled = true;
            this.AbortSettingHotkeyButton.IsEnabled = true;
        }

        private void HotkeyTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            this.SetHotkeyButton.IsEnabled = false;
            this.AbortSettingHotkeyButton.IsEnabled = false;
        }

        private void SwitchStateButton_Click(object sender, RoutedEventArgs e)
        {
            this.isEnabled = !this.isEnabled;
            this.SwitchStateVisually(isEnabled);
        }

        private void SwitchStateVisually(bool isEnabled)
        {
            switch (isEnabled)
            {
                case true:
                    this.BorderBrush = Collection.ColorCollection.enabledColor;
                    this.HeaderGrid.Background = Collection.ColorCollection.enabledColor;
                    this.HeaderStatusLabel.Text = "ENABLED";
                    SwitchStateButton.Content = "DISABLE";
                    break;
                default:
                    this.BorderBrush = Collection.ColorCollection.disabledColor;
                    this.HeaderGrid.Background = Collection.ColorCollection.disabledColor;
                    this.HeaderStatusLabel.Text = "DISABLED";
                    SwitchStateButton.Content = "ENABLE";
                    break;
            }
        }
    }
}
