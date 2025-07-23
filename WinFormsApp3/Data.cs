using MemoryInjection;
using ConfigManagerSpace;
using ConfigurationLibrary;

namespace InjectMemory
{
    public static class Data
    {
        public static IntPtr
            processBaseAddress,
            LocalPlayerAddress;

        public static int
            flyOffset = 0x5C,
            ammoOffset = 0x138,
            ammo_secondaryOffset = 0x12C,
            healthOffset = 0xEC,
            armorOffset = 0xF0,
            grenadeOffset = 0x144,
            grenadeThrowOffset = 0x168,
            teamOffset = 0x30C,
            reloadOffset = 0x15C,
            y_positionOffset = 0x30,
            viewMatrixOffset = 0x17DF90,
            yawOffset = 0x34,
            pitchOffset = 0x38,
            headPosOffset = 0x04,
            footPosOffset = 0x28,
            nickNameOffset = 0x205;


        private static Dictionary<string, Category> categories_ = new Dictionary<string, Category>();
        private static List<Category> categoryList;

        private static List<Label> labels = new List<Label>();
        private static List<Label> labelsNames = new List<Label>();
        private static List<Label> labelsHealth = new List<Label>();

        private static List<CheckBox> loadBoxes = new List<CheckBox>() { new CheckBox() };
        private static List<CheckBox> saveBoxes = new List<CheckBox>() { new CheckBox() };

        internal static List<Label> Labels { get => labels; set => labels = value; }
        public static Dictionary<string, Category> Categories_ { get => categories_; set => categories_ = value; }
        internal static List<Category> Categories { get => categoryList; set => categoryList = value; }
        public static int PlayerNumber { get => playerNumber; set => playerNumber = value; }
        public static List<Label> LabelsNames { get => labelsNames; set => labelsNames = value; }
        public static List<Label> LabelsHealth { get => labelsHealth; set => labelsHealth = value; }
        public static List<CheckBox> LoadBoxes { get => loadBoxes; set => loadBoxes = value; }
        public static List<CheckBox> SaveBoxes { get => saveBoxes; set => saveBoxes = value; }

        public static string WINDOW_NAME = "AssaultCube";

        private static int playerNumber = 0;

        public static void LoadData(AppConfig readedData)
        {
            Data.Categories_.Add(MemoryInjection.Combat.name, new MemoryInjection.Combat(Labels[0], true));
            Data.Categories_.Add(MemoryInjection.Movement.name, new MemoryInjection.Movement(Labels[1]));
            Data.Categories_.Add(MemoryInjection.Visual.name, new MemoryInjection.Visual(Labels[2]));
            Data.Categories_.Add(MemoryInjection.Misc.name, new MemoryInjection.Misc(Labels[3]));

            Data.Categories_[MemoryInjection.Combat.name].addItem(new Aimbot(Labels[0], readedData.Categories.Combat.Aimbot, true));
            Data.Categories_[MemoryInjection.Combat.name].addItem(new Fast_Grenades(Labels[1], readedData.Categories.Combat.FastGrenades, false));
            Data.Categories_[MemoryInjection.Combat.name].addItem(new Fast_Reload(Labels[2], readedData.Categories.Combat.FastReaload, false));

            Data.Categories_[MemoryInjection.Movement.name].addItem(new Auto_Jump(Labels[0], readedData.Categories.Movement.AutoJump, true));
            Data.Categories_[MemoryInjection.Movement.name].addItem(new Fly(Labels[1], readedData.Categories.Movement.Fly, false));
            //Data.Categories_[Movement.name].addItem(new Module(Labels[2]));

            Data.Categories_[MemoryInjection.Visual.name].addItem(new Esp(Labels[0], readedData.Categories.Visual.Esp, true));
            Data.Categories_[MemoryInjection.Visual.name].addItem(new WireFrame(Labels[1], readedData.Categories.Visual.WireFrame, false));
            Data.Categories_[MemoryInjection.Visual.name].addItem(new Nametags(Labels[2], readedData.Categories.Visual.Nametags, false));

            Data.Categories_[MemoryInjection.Misc.name].addItem(new Infinite_Ammo(Labels[0], readedData.Categories.Misc.InfiniteAmmo.Enabled, true));
            Data.Categories_[MemoryInjection.Misc.name].addItem(new Infinite_Health(Labels[1], readedData.Categories.Misc.InfiniteHealth.Enabled, false));
            Data.Categories_[MemoryInjection.Misc.name].addItem(new Infinite_Armor(Labels[2], readedData.Categories.Misc.InfiniteArmor.Enabled, false));
            Data.Categories_[MemoryInjection.Misc.name].addItem(new Infinite_Grenades(Labels[3], readedData.Categories.Misc.InfiniteGrenades.Enabled, false));
            Data.Categories_[MemoryInjection.Misc.name].addItem(new Team_Changer(labels[4], readedData.Categories.Misc.TeamChanger.Enabled, false));

            Categories = Categories_.Values.ToList();
        }
        public static AppConfig ReadData()
        {
            AppConfig config = new AppConfig
            {
                Categories = new Categories
                {
                    Combat = new ConfigurationLibrary.Combat(Categories_[MemoryInjection.Combat.name].Items[0].IsSelected, Categories_[MemoryInjection.Misc.name].Items[1].IsSelected, Categories_[MemoryInjection.Misc.name].Items[2].IsSelected),
                    Movement = new ConfigurationLibrary.Movement(Categories_[MemoryInjection.Movement.name].Items[0].IsSelected, Categories_[MemoryInjection.Movement.name].Items[1].IsSelected),
                    Visual = new ConfigurationLibrary.Visual(Categories_[MemoryInjection.Visual.name].Items[0].IsSelected, Categories_[MemoryInjection.Visual.name].Items[1].IsSelected, Categories_[MemoryInjection.Visual.name].Items[2].IsSelected),
                    Misc = new ConfigurationLibrary.Misc
                    {
                        InfiniteAmmo = new ConfigurationLibrary.MiscItem(Categories_[MemoryInjection.Misc.name].Items[0].IsSelected, Categories_[MemoryInjection.Misc.name].Items[0].Value),
                        InfiniteHealth = new ConfigurationLibrary.MiscItem(Categories_[MemoryInjection.Misc.name].Items[1].IsSelected, Categories_[MemoryInjection.Misc.name].Items[1].Value),
                        InfiniteArmor = new ConfigurationLibrary.MiscItem(Categories_[MemoryInjection.Misc.name].Items[2].IsSelected, Categories_[MemoryInjection.Misc.name].Items[2].Value),
                        InfiniteGrenades = new ConfigurationLibrary.MiscItem(Categories_[MemoryInjection.Misc.name].Items[3].IsSelected, Categories_[MemoryInjection.Misc.name].Items[3].Value),
                        TeamChanger = new ConfigurationLibrary.TeamChanger(Categories_[MemoryInjection.Misc.name].Items[4].IsSelected)
                    }
                }
            };
            return config;
        }
    }
}
