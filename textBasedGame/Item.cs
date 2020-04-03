using System.Security.Cryptography.X509Certificates;

namespace textBasedGame
{
    public class Item
    {
        public Item(string _name, bool useable, string description)
        {
            name = _name;
            UseAble = useable;
            Description = description;
        }

        private string name;

        public string Name
        {
            get => name;
        }

        private bool UseAble { get; }
        
        public bool useAble => UseAble;
        private string Description { get; }

        public string description => Description;
    }
}