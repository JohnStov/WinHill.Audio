namespace WinHill.Audio.Streams
{
    using System.Diagnostics.Contracts;
    using Contracts;

    [ContractClass(typeof(AudioConnectorContract))]
    public interface IAudioConnector
    {
        bool Connect(IConnectableAudioStream stream);
        void Disconnect();
        
        IConnectableAudioStream Connection { get; }
    }
}
