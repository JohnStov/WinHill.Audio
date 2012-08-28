namespace WinHill.Audio.Streams
{
    using System.Diagnostics.Contracts;

    using WinHill.Audio.Contracts;

    [ContractClass(typeof(ConnectableAudioStreamContract))]
    public interface IConnectableAudioStream : IAudioStream
    {
        IAudioConnector Connector { get; set; }
    }
}