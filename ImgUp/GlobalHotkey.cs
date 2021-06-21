using System.Windows.Forms;
using System.Runtime.InteropServices;
using System;

namespace ImgUp
{
    class GlobalHotkey
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        // Either ALT key was held down.
        public const int MOD_ALT = 0x0001;
        // Either CTRL key was held down.
        public const int MOD_CONTROL = 0x0002;
        // Either SHIFT key was held down.
        public const int MOD_SHIFT = 0x0004;
        // Either WINDOWS key was held down.
        public const int MOD_WIN = 0x0008;
        // When the user presses a hot key registered by the RegisterHotKey function.
        public const int WM_HOTKEY = 0x0312;

        private int modifier;
        private int key;
        private IntPtr hWnd;
        private int id;
        
        public GlobalHotkey(int modifier, Keys key, Form form)
        {
            this.modifier = modifier;
            this.key = (int)key;
            this.hWnd = form.Handle;
            id = GetHashCode();
        }

        public bool Register()
        {
            return RegisterHotKey(hWnd, id, modifier, key);
        }

        public bool Unregiser()
        {
            return UnregisterHotKey(hWnd, id);
        }

        public override int GetHashCode()
        {
            return modifier ^ key ^ hWnd.ToInt32();
        }
    }
}
