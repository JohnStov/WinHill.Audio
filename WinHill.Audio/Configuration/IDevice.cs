﻿namespace WinHill.Audio.Configuration
{
    using System.Diagnostics.Contracts;
    using Contracts;

    [ContractClass(typeof(DeviceContract))]
    public interface IDevice
    {
        string Name { get; }

        IWavePlayer Player { get; }

        double SampleRate { get; }

        int Channels { get; }
    }
}