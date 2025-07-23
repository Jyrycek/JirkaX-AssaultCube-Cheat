namespace ConfigurationLibrary
{
    public class Combat
    {
        public bool Aimbot { get; set; } = false;
        public bool FastGrenades { get; set; } = false;
        public bool FastReaload { get; set; } = false;

        public Combat(bool aimbot, bool fastGrenades, bool fastReaload)
        {
            Aimbot = aimbot;
            FastGrenades = fastGrenades;
            FastReaload = fastReaload;
        }
    }
}
