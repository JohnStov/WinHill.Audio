namespace WinHill.Audio.Contracts
{
    using System.Diagnostics.Contracts;

    using WinHill.Audio.Streams;

    [ContractClassFor(typeof(IConnector<>))]
    public abstract class ConnectorContract<T> : IConnector<T>
    {
        public void Disconnect() { }

        public bool IsConnected { get { return default(bool); } }

        public T Channel { get { return default(T); } }
    }
}