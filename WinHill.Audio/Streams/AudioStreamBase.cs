namespace WinHill.Audio.Streams
{
    using System.Collections;
    using System.Collections.Generic;

    public abstract class AudioStreamBase : IAudioStream
    {
        protected AudioStreamBase()
        {
        }

        protected abstract double GetNext();

        private class Enumerator : IEnumerator<double>
        {
            private readonly AudioStreamBase parent;

            public Enumerator(AudioStreamBase parent) { this.parent = parent; }

            public void Dispose() { }

            public bool MoveNext() { return true; }

            public void Reset() { }

            public double Current { get { return parent.GetNext(); } }

            object IEnumerator.Current { get { return Current; } }
        }

        public IEnumerator<double> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}