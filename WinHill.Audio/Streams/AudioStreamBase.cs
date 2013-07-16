namespace WinHill.Audio.Streams
{
    using System.Collections;
    using System.Collections.Generic;

    public abstract class AudioStreamBase : IAudioStream
    {
        protected abstract float GetNext();

        private class Enumerator : IEnumerator<float>
        {
            private readonly AudioStreamBase parent;

            public Enumerator(AudioStreamBase parent) { this.parent = parent; }

            public void Dispose() { }

            public bool MoveNext() { return true; }

            public void Reset() { }

            public float Current { get { return parent.GetNext(); } }

            object IEnumerator.Current { get { return Current; } }
        }

        public IEnumerator<float> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}