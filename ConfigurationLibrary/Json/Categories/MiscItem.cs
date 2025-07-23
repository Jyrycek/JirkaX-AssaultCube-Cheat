namespace ConfigurationLibrary
{
    public class MiscItem
    {
        public bool Enabled { get; set; } = false;
        public int Value { get; set; } = 999;
        public MiscItem(bool enabled, int value) 
        {
            Enabled = enabled;
            Value = value;
        }
    }
}