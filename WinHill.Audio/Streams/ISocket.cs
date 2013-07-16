namespace WinHill.Audio.Streams
{
    using System.Diagnostics.Contracts;
    using Contracts;

    [ContractClass(typeof(SocketContract<>))]
    public interface ISocket<T> : IConnector<T>
    {
        bool ConnectTo(IPlug<T> stream);
    }
}
