using InjectMemory;
using MemoryInjection;
using System.Runtime.InteropServices;

public class WindowFocusHook
{
    [DllImport("user32.dll")]
    private static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, WinEventProc lpfnWinEventProc, uint idProcess, uint idThread, uint dwFlags);

    private delegate IntPtr WinEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);
    private const uint EVENT_SYSTEM_FOREGROUND = 0x0003;

    private IntPtr hookPtr;
    private WinEventProc winEventProc;

    public event EventHandler WindowFocusGained;
    public event EventHandler WindowFocusLost;

    private GameManager gameManager;

    public WindowFocusHook(GameManager gameManager)
    {
        hookPtr = IntPtr.Zero;
        winEventProc = new WinEventProc(WindowEventCallback);

        // Nainstalovat hook pro sledování změn focusu okna
        hookPtr = SetWinEventHook(EVENT_SYSTEM_FOREGROUND, EVENT_SYSTEM_FOREGROUND, IntPtr.Zero, winEventProc, 0, 0, 0);
        this.gameManager = gameManager;

    }

    public void Unhook()
    {
        if (hookPtr != IntPtr.Zero)
        {
            User32.UnhookWinEvent(hookPtr);
            hookPtr = IntPtr.Zero;
        }
    }

    private IntPtr WindowEventCallback(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
    {
        if (eventType == EVENT_SYSTEM_FOREGROUND)
        {
            if (User32.GetForegroundWindow() != gameManager.GameWindowHandle)
            {
                WindowFocusLost?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                WindowFocusGained?.Invoke(this, EventArgs.Empty);
            }
        }

        return IntPtr.Zero;
    }

    // Destruktor třídy pro odregistrování hooku
    ~WindowFocusHook()
    {
        Unhook();
    }
}
