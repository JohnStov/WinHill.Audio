namespace WinHill.Audio.Streams
{
    public abstract class Connector<T> : IConnector<T>
    {
        protected IConnector<T> Connection;

        public void Disconnect()
        {
            if (Connection != null)
            {
                var toDisconnect = Connection;
                Connection = null;
                toDisconnect.Disconnect();
            }
        }

        public bool IsConnected { get { return Connection != null; } }

        protected bool InternalConnectTo(IConnector<T> connector)
        {
            if (Connection == connector)
                return true;

            if (Connection == null && connector is Connector<T>)
            {
                Connection = connector;

                var internalConnector = connector as Connector<T>;
                if (internalConnector.InternalConnectTo(this))
                    return true;

                Connection = null;
            }

            return false;
        }


        public abstract T Channel { get; }
    }
}
