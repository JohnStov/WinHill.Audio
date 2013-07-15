namespace WinHill.Audio.Streams
{
    using System.Collections.Generic;
    using System.Collections;
    using System.Diagnostics.Contracts;

    public class AudioConnector : IAudioConnector, IAudioStream
    {
        private static readonly IConnectableAudioStream NullStream = new AudioStream(() => 0.0f);

        private IConnectableAudioStream stream = NullStream;

        public bool Connect(IConnectableAudioStream inputStream)
        {
            if (inputStream == stream)
                return true;
            
            if (inputStream.Connector == null)
            {
                inputStream.Connector = this;
                stream = inputStream;
                return true;
            }

            return false;
        }

        public void Disconnect()
        {
            if (stream != NullStream)
                stream.Connector = null;

            stream = NullStream;
        }

        public IEnumerator<float> GetEnumerator()
        {
            return stream.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public string Name { get; set; }
        
        public IConnectableAudioStream Connection { get { return stream == NullStream ? null : stream; } }

        [ContractInvariantMethod]
        private void ContractInvariant()
        {
            Contract.Invariant(stream != null);
        }
    }
}
