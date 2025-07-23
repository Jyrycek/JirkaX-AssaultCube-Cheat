namespace ConfigurationLibrary
{
    public class TeamChanger
    {
        public bool Enabled { get; set; } = false;
        public TeamChanger(bool enabled) 
        {
            Enabled = enabled;
        }
    }
}