using MemoryInjection;
using MemoryAccesor;
using Exceptions;

namespace InjectMemory
{
    public class GameManager
    {
        private MemoryManager memoryAccess;

        private const string GAME_NAME = "AssaultCube";
        private const string WINDOW_NAME = "ac_client";

        private IntPtr gameWindowHandle;

        private bool isOpenedMenu = true;
        private bool isInCategory = true;
        private static bool isFocused = true;

        public IntPtr GameWindowHandle { get => gameWindowHandle; set => gameWindowHandle = value; }
        public bool IsOpenedMenu { get => isOpenedMenu; set => isOpenedMenu = value; }
        public MemoryManager MemoryAccess { get => memoryAccess; set => memoryAccess = value; }
        public bool IsInCategory { get => isInCategory; set => isInCategory = value; }
        public static bool IsFocused { get => isFocused; set => isFocused = value; }

        public GameManager()
        {
            MemoryAccess = new MemoryManager(WINDOW_NAME);
            GameWindowHandle = User32.FindWindow(null, GAME_NAME);

            if (GameWindowHandle == IntPtr.Zero)
            {
                throw new OpenProcessException("Nastala chyba vyhledání procesu!");
            }
        }

        public void ModuleExecutor()
        {
            foreach (var cat in Data.Categories)
            {
                foreach (Module item in cat.Items.Where(it => it.IsSelected))
                {
                    item.Execute();
                }
            }
        }
    }
}