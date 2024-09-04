using System;
using System.Windows.Input;
using System.Windows.Interop;

namespace BlitzSwitch.Hotkey
{
    internal class HotkeyManager : IDisposable
    {
        private HwndSource Source;
        private readonly int HotkeyID = 0;
        private Key hotkey;

        public Key Hotkey
        {
            get => this.hotkey;
            set
            {
                if (this.hotkey != value)
                {
                    this.RegisterHotkey();
                    this.hotkey = value;
                    this.UnregisterHotkey();
                }
            }
        }

        public HotkeyManager() { }

        public bool RegisterHotkey() =>
            HotkeyInteropHelper.RegisterHotKey(this.Source.Handle, id: this.HotkeyID, 0x000, KeyInterop.VirtualKeyFromKey(this.hotkey));

        public bool UnregisterHotkey() =>
            HotkeyInteropHelper.UnregisterHotKey(this.Source.Handle, this.HotkeyID);

        public void Dispose()
        {
        }
    }
}
