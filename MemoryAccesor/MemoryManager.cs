using Swed32;
using System.Diagnostics;
using System.Text;
using System.Numerics;
using Exceptions;

namespace MemoryAccesor
{
    public class MemoryManager
    {
        public static IntPtr processBaseAddress = IntPtr.Zero;
        public static IntPtr LocalPlayerAddress = IntPtr.Zero;
        public static int Process_id { get; set; }
        public static Swed? Mem { get; set; } = null;

        public MemoryManager(string WINDOW_NAME)
        {
            Process_id = GetProcessIdFromName(WINDOW_NAME);

            Mem = new Swed(WINDOW_NAME);

            processBaseAddress = Mem.GetModuleBase(".exe");
            LocalPlayerAddress = ReadPointer(processBaseAddress, 0x0017E0A8);
        }

        public int GetProcessIdFromName(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName);

            if (processes.Length > 0)
            {
                return processes[0].Id;
            }

            throw new OpenProcessException("Chyba otevření procesu!");
        }

        public static void WriteMemory(IntPtr baseAddress, int offset, int dataValue)
        {
            Mem!.WriteBytes(baseAddress + offset, BitConverter.GetBytes(dataValue));
        }
        public static void WriteFloat(IntPtr baseAddress, int offset, float dataValue)
        {
            Mem!.WriteBytes(baseAddress + offset, BitConverter.GetBytes(dataValue));
        }
        public static byte ReadByte(IntPtr baseAddress, int offset)
        {
            return Mem!.ReadBytes(baseAddress + offset, 1)[0];
        }
        public static string ReadString(IntPtr address, int offset)
        {
            return Encoding.UTF8.GetString(Mem!.ReadBytes(address + offset, 16));
        }
        public static int ReadInt(IntPtr address, int offset)
        {
            return Mem!.ReadInt(address, offset);
        }
        public static Vector3 ReadVector3(IntPtr address, int offset)
        {
            return Mem!.ReadVec(address, offset);
        }
        public static float ReadFloat(IntPtr address, int offset)
        {
            return Mem!.ReadFloat(address, offset);
        }
        public static IntPtr ReadPointer(IntPtr address, int offset)
        {
            return Mem.ReadPointer(address, offset);
        }
        public static float[] ReadMatrix(IntPtr address)
        {
            return Mem!.ReadMatrix(address);
        }
    }
}