namespace WinHill.Audio.Configuration
{
    using System;

    public enum PlaybackState
    {
        Unknown,
        Stopped,
        Paused,
        Running
    }

    public interface IPlayback : IDisposable
    {
        PlaybackState PlaybackState { get; }

        void Start();

        void Stop();

        void Pause();
    }
}