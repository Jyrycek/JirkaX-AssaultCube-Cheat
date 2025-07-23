using MemoryInjection;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace InjectMemory
{
    public class GlobalKeyboardHook
    {
        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc callback, IntPtr hMod, uint dwThreadId);

        // Konstanty pro Windows API
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;

        // Delegát pro callback funkci
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private IntPtr hookId = IntPtr.Zero;
        private LowLevelKeyboardProc keyboardProc;

        // Událost, která se vyvolá při stisknutí klávesy
        public event EventHandler<KeyEventArgs> KeyDown;

        // Událost, která se vyvolá při uvolnění klávesy
        public event EventHandler<KeyEventArgs> KeyUp;

        // Konstruktor třídy
        public GlobalKeyboardHook()
        {
            keyboardProc = HookCallback;
            hookId = SetHook(keyboardProc);

        }

        // Metoda pro zachytávání klávesových událostí
        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                KeyEventArgs args = new KeyEventArgs((Keys)vkCode);

                if (wParam == (IntPtr)WM_KEYDOWN && KeyDown != null)
                {
                    KeyDown.Invoke(this, args);


                }
                else if (wParam == (IntPtr)WM_KEYUP && KeyUp != null)
                {
                    KeyUp.Invoke(this, args);
                }
            }

            return User32.CallNextHookEx(hookId, nCode, wParam, lParam);
        }



        // Metoda pro nastavení hooku pro zachytávání klávesových událostí
        private IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (ProcessModule module = Process.GetCurrentProcess().MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, Kernel32.GetModuleHandle(module.ModuleName), 0);
            }
        }

        // Metoda pro uvolnění hooku pro zachytávání klávesových událostí
        private void Unhook()
        {
            if (hookId != IntPtr.Zero)
            {
                User32.UnhookWindowsHookEx(hookId);
                hookId = IntPtr.Zero;
            }
        }

        // Destruktor třídy
        ~GlobalKeyboardHook()
        {
            Unhook();
        }
    }
}
