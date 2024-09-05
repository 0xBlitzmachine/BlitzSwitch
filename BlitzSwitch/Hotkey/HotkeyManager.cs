using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace BlitzSwitch.Hotkey
{
    public class HotkeyManager : IDisposable, INotifyPropertyChanged
    {

        // Properties
        private HwndSource Source;
        private readonly Window wnd;
        private readonly int HotkeyID = 0;
        private Key hotkey = Key.F1;

        public event PropertyChangedEventHandler PropertyChanged;

        public Key Hotkey
        {
            get => this.hotkey;
            set
            {
                if (this.hotkey != value)
                {
                    this.hotkey = value;
                    OnPropertyChanged(nameof(Hotkey));
                    this.UnregisterHotkey();
                    this.RegisterHotkey();
                }
                else
                {
                    MessageBox.Show("Can't press same key!");
                }
            }
        }

        // Constructor
        public HotkeyManager(Window window)
        {
            window.Closed += Window_Closed;
            this.wnd = window;
            var handle = new WindowInteropHelper(window).Handle;

            this.Source = HwndSource.FromHwnd(handle);
            this.Source.AddHook(this.WndProc);
        }


        // Subscriped Window Event
        private void Window_Closed(object sender, EventArgs e) => this.Dispose();

        // Custom WndProc
        //https://learn.microsoft.com/de-de/windows/win32/inputdev/keyboard-input-notifications
        //Make sure to only react when it receives a window key input notification
        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            const int WM_HOTKEY = 0x0312;
            if (msg == WM_HOTKEY && wParam.ToInt32() == this.HotkeyID)
            {

                // FIX THIS AAAH! Can't set F1 as key anymore 
                // I think, the initial Key is F1 .. When IsHotkeyListening is on false, it just sets handled to true and returns IntPtr.Zero leading the TextBox KeyDown event as handled also.
                // Low Level interception of window messages are handled here first before any other Event can react to it?
                MessageBox.Show("WTF");
                if ((wnd as MainWindow).IsHotkeyListening)
                    MessageBox.Show("Intercepted my function!");

                handled = true;
            }
            return IntPtr.Zero;
        }

        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public bool RegisterHotkey() =>
           HotkeyInteropHelper.RegisterHotKey(this.Source.Handle, id: this.HotkeyID, 0x000, KeyInterop.VirtualKeyFromKey(this.hotkey));

        public bool UnregisterHotkey() =>
            HotkeyInteropHelper.UnregisterHotKey(this.Source.Handle, this.HotkeyID);

        public void Dispose()
        {
            this.UnregisterHotkey();
            this.Source.RemoveHook(this.WndProc);
        }
    }
}
