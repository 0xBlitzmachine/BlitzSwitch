using System;
using System.Runtime.InteropServices;

namespace BlitzSwitch.Hotkey
{
    internal static class HotkeyInteropHelper
    {
        // Import native functions from the win32 library
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
    }
}
