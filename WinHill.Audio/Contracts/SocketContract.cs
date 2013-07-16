namespace WinHill.Audio.Contracts
{
    using System.Diagnostics.Contracts;

    using WinHill.Audio.Streams;

    [ContractClassFor(typeof(ISocket<>))]
    public abstract class SocketContract<T> : ISocket<T>
    {
        public bool ConnectTo(IPlug<T> plug)
        {
            Contract.Requires(plug != null);
            return default(bool);
        }

        public void Disconnect() { }

        public bool IsConnected { get { return default(bool); } }

        public T Channel { get { return default(T); } }
    }
}
