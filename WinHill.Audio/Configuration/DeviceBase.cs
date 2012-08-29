namespace WinHill.Audio.Configuration
{
    using System;
    
    public abstract class DeviceBase : IDevice, IDisposable
    {
        public abstract string Name { get; }

        public IPlayback Player { get; protected set; }

        public virtual double SampleRate { get; set; }

        public virtual int Channels { get; set; }

        public void Dispose()
        {
            Player.Dispose();
        }
    }
}