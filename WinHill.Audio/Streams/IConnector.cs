namespace WinHill.Audio.Streams
{
    using System.Diagnostics.Contracts;

    using WinHill.Audio.Contracts;

    [ContractClass(typeof(ConnectorContract<>))]
    public interface IConnector<out T>
    {
        void Disconnect();

        bool IsConnected { get; }

        T Channel { get; }
    }
}
