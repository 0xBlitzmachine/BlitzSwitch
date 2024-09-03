using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace BlitzSwitch.Misc
{
    internal class Collection
    {
        internal static List<Key> allowedHotkeys = new List<Key>()
        {
            Key.F1, Key.F2, Key.F2, Key.F3, Key.F4, Key.F5, Key.F6, Key.F7, Key.F8, Key.F9, Key.F10, Key.F11, Key.F12, Key.Delete, Key.Insert, Key.End, Key.NumLock

        };

        internal static class ColorCollection
        {
            internal static SolidColorBrush enabledColor = Application.Current.TryFindResource("EnabledColor") as SolidColorBrush;
            internal static SolidColorBrush disabledColor = Application.Current.TryFindResource("DisabledColor") as SolidColorBrush;
        };
    }
}
