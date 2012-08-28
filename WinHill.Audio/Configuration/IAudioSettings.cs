using System.ComponentModel;

namespace WinHill.Audio.Configuration
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using Contracts;

    [ContractClass(typeof(AudioSettingsContract))]
    public interface IAudioSettings : INotifyPropertyChanged
    {
        IEnumerable<ITechnology> Technologies { get; }

        IDevice Device { get; set; }

        double SampleRate { get; }

        int Channels { get; }
    }
}