namespace WinHill.Audio.Contracts
{
    using System.Diagnostics.Contracts;
    using Streams;

    [ContractClassFor(typeof(IAudioConnector))]
    public abstract class AudioConnectorContract : IAudioConnector
    {
        public string Name
        {
            get { return default(string); }
            set { }
        }

        public bool Connect(IConnectableAudioStream stream)
        {
            Contract.Requires(stream != null);
            return default(bool);
        }

        public void Disconnect()
        {
        }

        public IConnectableAudioStream Connection
        {
            get { return default(IConnectableAudioStream); }
        }
     }
}
