namespace WinHill.Audio.Contracts
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using WinHill.Audio.Streams;

    [ContractClassFor(typeof(IConnectableAudioStream))]
    public abstract class ConnectableAudioStreamContract : IConnectableAudioStream
    {
        public IAudioConnector Connector
        {
            get { return default(IAudioConnector); }
            set {}
        }

        public IEnumerator<float> GetEnumerator()
        {
            return default(IEnumerator<float>);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
