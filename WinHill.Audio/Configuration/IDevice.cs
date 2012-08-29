namespace WinHill.Audio.Configuration
{
    using System.Diagnostics.Contracts;
    using Contracts;

    [ContractClass(typeof(DeviceContract))]
    public interface IDevice
    {
        string Name { get; }

        IPlayback Player { get; }

        double SampleRate { get; }

        int Channels { get; }
    }
}