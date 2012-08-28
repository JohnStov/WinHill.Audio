namespace WinHill.Audio.Configuration
{
    using System.Collections.Generic;

    public interface ITechnology
    {
        string Name { get; }

        IEnumerable<IDevice> Devices { get; }
    }
}