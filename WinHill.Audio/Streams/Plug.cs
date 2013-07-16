using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinHill.Audio.Streams
{
    using System.Diagnostics.Contracts;

    public class Plug<T> : Connector<T>, IPlug<T>
    {
        private readonly T channel;
        
        public Plug(T channel)
        {
            Contract.Requires(channel != null);
            this.channel = channel;
        }
        
        public override T Channel { get {return channel; } }

        public bool ConnectTo(ISocket<T> socket)
        {
            return InternalConnectTo(socket);
        }
    }
}
