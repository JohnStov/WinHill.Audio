namespace WinHill.Audio.Streams
{
    using System;

    public class AudioStream : AudioStreamBase
    {
        private readonly Func<double> fn;

        protected override double GetNext() { return fn(); }

        public AudioStream(Func<double> fn)
        {
            this.fn = fn;
        }
    }
}
