using System.Runtime.InteropServices;

namespace InjectMemory
{
    public static class Kernel32
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

    }
}
