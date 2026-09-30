namespace AC1999Launcher
{
    public class AC1999Profile
    {
        public string Name { get; set; } = "";

        public string GamePath { get; set; } = "";

        public string Host { get; set; } = "";

        public string Port { get; set; } = "";

        public bool UseDatabase { get; set; } = true;

        public override string ToString()
        {
            return Name;
        }
    }
}