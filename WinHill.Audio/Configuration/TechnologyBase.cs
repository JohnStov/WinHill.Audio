namespace WinHill.Audio.Configuration
{
    using System.Collections.Generic;

    public abstract class TechnologyBase : ITechnology
    {
        protected TechnologyBase(string name)
        {
            Name = name;
        }
        
        public string Name { get; private set; }

        public abstract IEnumerable<IDevice> Devices { get; }
    }
}