using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinHill.Audio.Streams
{
    public class Socket<T> : Connector<T>, ISocket<T>
    {
        public override T Channel { get { return IsConnected ? Connection.Channel : default(T); } }

        public bool ConnectTo(IPlug<T> socket)
        {
            return InternalConnectTo(socket);
        }
    }
}
