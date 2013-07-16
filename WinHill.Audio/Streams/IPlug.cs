namespace WinHill.Audio.Streams
{
    using System.Diagnostics.Contracts;

    using WinHill.Audio.Contracts;

    [ContractClass(typeof(PlugContract<>))]
    public interface IPlug<T> : IConnector<T>
    {
        bool ConnectTo(ISocket<T> socket);
    }
}