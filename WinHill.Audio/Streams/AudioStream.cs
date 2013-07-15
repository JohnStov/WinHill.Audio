namespace WinHill.Audio.Streams
{
    using System;

    public class AudioStream : AudioStreamBase
    {
        private readonly Func<float> fn;

        protected override float GetNext() { return fn(); }

        public AudioStream(Func<float> fn)
        {
            this.fn = fn;
        }
    }
}
