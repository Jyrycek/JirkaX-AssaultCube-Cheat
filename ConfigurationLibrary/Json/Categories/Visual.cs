namespace ConfigurationLibrary
{
    public class Visual
    {
        public bool Esp { get; set; } = false;
        public bool WireFrame { get; set; } = false;
        public bool Nametags { get; set; } = false;
        public Visual(bool esp, bool wireFrame, bool nametags)
        {
            Esp = esp;
            WireFrame = wireFrame;
            Nametags = nametags;
        }
    }
}