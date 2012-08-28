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

        public IEnumerator<double> GetEnumerator()
        {
            return default(IEnumerator<double>);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public string Name
        {
            get { return default(string); }
            set {  }
        }
    }
}
