namespace ConfigurationLibrary
{
    public class Movement
    {
        public bool AutoJump { get; set; } = false;
        public bool Fly { get; set; } = false;
        public Movement(bool autoJump, bool fly)
        {
            AutoJump = autoJump;
            Fly = fly;
        }
    }
}
