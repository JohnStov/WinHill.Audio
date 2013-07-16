namespace WinHill.Audio.Test.Streams
{
    using NSubstitute;

    using Should.Fluent;
    using WinHill.Audio.Streams;
    using Xunit;

    public class SocketTests
    {
        [Fact]
        public void CreatingSocketDoesNotSetChannel()
        {
            var socket = new Socket<IAudioStream>();
            socket.Channel.Should().Be.Null();
        }

        [Fact]
        public void CreatedSocketIsDisconnected()
        {
            var socket = new Socket<IAudioStream>();
            socket.IsConnected.Should().Be.False();
        }

        [Fact]
        public void CreatedSocketCanBeDisconnected()
        {
            var socket = new Socket<IAudioStream>();
            socket.Disconnect();
            socket.IsConnected.Should().Be.False();
        }

        [Fact]
        public void CanConnectSocketToPlug()
        {
            var stream = Substitute.For<IAudioStream>();
            var plug = new Plug<IAudioStream>(stream);
            var socket = new Socket<IAudioStream>();

            socket.ConnectTo(plug).Should().Be.True();
        }

        [Fact]
        public void ConnectedSocketIsConnected()
        {
            var stream = Substitute.For<IAudioStream>();
            var plug = new Plug<IAudioStream>(stream);
            var socket = new Socket<IAudioStream>();

            socket.ConnectTo(plug);
            socket.IsConnected.Should().Be.True();
        }

        [Fact]
        public void ConnectedPlugIsConnected()
        {
            var stream = Substitute.For<IAudioStream>();
            var plug = new Plug<IAudioStream>(stream);
            var socket = new Socket<IAudioStream>();

            socket.ConnectTo(plug);
            plug.IsConnected.Should().Be.True();
        }

        [Fact]
        public void ConnectingSetsSocketChannel()
        {
            var stream = Substitute.For<IAudioStream>();
            var plug = new Plug<IAudioStream>(stream);
            var socket = new Socket<IAudioStream>();

            socket.ConnectTo(plug);
            Assert.Same(stream, socket.Channel);
        }

        [Fact]
        public void CanReconnectSameConnection()
        {
            var stream = Substitute.For<IAudioStream>();
            var plug = new Plug<IAudioStream>(stream);
            var socket = new Socket<IAudioStream>();

            socket.ConnectTo(plug);

            socket.ConnectTo(plug).Should().Be.True();
        }

        [Fact]
        public void CannotConnectToNewPlugWithoutDisconnecting()
        {
            var stream1 = Substitute.For<IAudioStream>();
            var plug1 = new Plug<IAudioStream>(stream1);
            var stream2 = Substitute.For<IAudioStream>();
            var plug2 = new Plug<IAudioStream>(stream2);
            var socket = new Socket<IAudioStream>();

            socket.ConnectTo(plug1);

            socket.ConnectTo(plug2).Should().Be.False();
        }

        [Fact]
        public void CannotConnectNewSocketWithoutDisconnecting()
        {
            var stream = Substitute.For<IAudioStream>();
            var plug = new Plug<IAudioStream>(stream);
            var socket1 = new Socket<IAudioStream>();
            var socket2 = new Socket<IAudioStream>();

            socket1.ConnectTo(plug);

            socket2.ConnectTo(plug).Should().Be.False();
        }

        [Fact]
        public void CanDisconnectSocket()
        {
            var stream = Substitute.For<IAudioStream>();
            var plug = new Plug<IAudioStream>(stream);
            var socket = new Socket<IAudioStream>();

            socket.ConnectTo(plug);

            socket.Disconnect();
            socket.IsConnected.Should().Be.False();
        }

        [Fact]
        public void DisconnectingSocketDisconnectsPlug()
        {
            var stream = Substitute.For<IAudioStream>();
            var plug = new Plug<IAudioStream>(stream);
            var socket = new Socket<IAudioStream>();

            socket.ConnectTo(plug);

            socket.Disconnect();
            plug.IsConnected.Should().Be.False();
        }
    }
}
