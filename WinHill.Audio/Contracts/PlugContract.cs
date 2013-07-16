namespace WinHill.Audio.Contracts
{
    using System.Diagnostics.Contracts;

    using WinHill.Audio.Streams;

    [ContractClassFor(typeof(IPlug<>))]
    public abstract class PlugContract<T> : IPlug<T>
    {
        public bool ConnectTo(ISocket<T> socket)
        {
            Contract.Requires(socket != null);
            return default(bool);
        }

        public void Disconnect() { }

        public bool IsConnected { get { return default(bool); } }

        public T Channel { get { return default(T); } }
    }
}
