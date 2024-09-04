using System;
using System.Windows.Input;

namespace BlitzSwitch.Hotkey
{
    internal class HotkeyManager : IHotkeyManagerBase
    {
        public IntPtr HWnd { get; set; }
        public Key Hotkey { get; set; }
        public int HotkeyID { get; set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool RegisterHotkey(int id, int fsModifiers, int vk)
        {
            throw new NotImplementedException();
        }

        public bool UnregisterHotkey(int id)
        {
            throw new NotImplementedException();
        }
    }
}
