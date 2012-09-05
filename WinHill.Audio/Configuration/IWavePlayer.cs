namespace WinHill.Audio.Configuration
{
    using System;

    public interface IWavePlayer : IDisposable
    {
        PlaybackState PlaybackState { get; }

        void Play();

        void Stop();

        void Pause();
    }
}