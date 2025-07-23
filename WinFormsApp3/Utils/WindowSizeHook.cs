using MemoryInjection;
using System.Diagnostics;
using System.Runtime.InteropServices;
using InjectMemory;

public class WindowSizeHook
{
    [DllImport("user32.dll")]
    private static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, WinEventProc lpfnWinEventProc, uint idProcess, uint idThread, uint dwFlags);

    private const uint WINEVENT_OUTOFCONTEXT = 0x0000;

    private delegate IntPtr WinEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);
    private const uint EVENT_OBJECT_LOCATIONCHANGE = 0x800B;

    private IntPtr hookPtr = IntPtr.Zero;
    private WinEventProc winEventProc;
    private IntPtr targetHwnd;

    public event EventHandler WindowSizeChanged;

    public WindowSizeHook(int processID)
    {
        winEventProc = new WinEventProc(WindowSizeEventCallback);

        // Získat handle (hwnd) okna cílové aplikace
        targetHwnd = Process.GetProcessById(processID).MainWindowHandle;

        // Nainstalovat hook pro sledování změn umístění objektů (včetně změn velikosti oken)
        hookPtr = SetWinEventHook(EVENT_OBJECT_LOCATIONCHANGE, EVENT_OBJECT_LOCATIONCHANGE, IntPtr.Zero, winEventProc, 0, 0, WINEVENT_OUTOFCONTEXT);
    }

    public void Unhook()
    {
        if (hookPtr != IntPtr.Zero)
        {
            User32.UnhookWinEvent(hookPtr);
            hookPtr = IntPtr.Zero;
        }
    }

    private IntPtr WindowSizeEventCallback(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
    {
        // Pokud hwnd odpovídá handle (hwnd) okna cílové aplikace, vyvoláme událost WindowSizeChanged
        if (hwnd == targetHwnd)
        {
            OnWindowSizeChanged(EventArgs.Empty);
        }

        return IntPtr.Zero;
    }

    protected virtual void OnWindowSizeChanged(EventArgs e)
    {
        WindowSizeChanged?.Invoke(this, e);
    }

    ~WindowSizeHook()
    {
        Unhook();
    }
}
