using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotKey
{
    internal class GlobalKeyboardHook
    {
        public delegate int keyboardHookProc(int code, int wparam, ref keyboardHookStruct lparam);
        public struct keyboardHookStruct
        {
            public int vkCode;
            public int scancode;
            public int flags;
            public int time;
            public int dwExtrainfo;

        }

        const int WH_KEYBOARD_LL = 13;
        const int WM_KEYDOWN = 0X100;
        const int WM_KEYUP = 0X101;
        const int WM_SYSKEYDOWN = 0X104;
        const int WM_SYSKEYUP = 0X105;

        public List<Keys> HookedKeys = new List<Keys>();
        IntPtr hhook = IntPtr.Zero;




    }
}
