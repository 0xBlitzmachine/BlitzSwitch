using System;
using System.Windows.Input;

namespace BlitzSwitch.Hotkey
{
    internal interface IHotkeyManagerBase : IDisposable
    {
        IntPtr HWnd { get; set; }
        Key Hotkey { get; set; }
        int HotkeyID { get; set; }

        bool RegisterHotkey(int id, int fsModifiers, int vk);
        bool UnregisterHotkey(int id);
    }
}
