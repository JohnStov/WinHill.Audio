namespace WinHill.Audio.Test.Streams
{
    using NSubstitute;

    using Should.Fluent;

    using WinHill.Audio.Streams;

    using Xunit;

    public class PlugTests
    {
        [Fact]
        public void CreatingPlugSetsChannel()
        {
            var stream = Substitute.For<IAudioStream>();
            var plug = new Plug<IAudioStream>(stream);
            Assert.Same(stream, plug.Channel);
        }

        [Fact]
        public void CreatedPlugIsDisconnected()
        {
            var stream = Substitute.For<IAudioStream>();
            var plug = new Plug<IAudioStream>(stream);
            plug.IsConnected.Should().Be.False();
        }

        [Fact]
        public void CreatedPlugCanBeDisconnected()
        {
            var stream = Substitute.For<IAudioStream>();
            var plug = new Plug<IAudioStream>(stream);
            plug.Disconnect();
            plug.IsConnected.Should().Be.False();
        }

        [Fact]
        public void CanConnectPlugToSocket()
        {
            var stream = Substitute.For<IAudioStream>();
            var plug = new Plug<IAudioStream>(stream);
            var socket = new Socket<IAudioStream>();

            plug.ConnectTo(socket).Should().Be.True();
        }

        [Fact]
        public void ConnectedPlugIsConnected()
        {
            var stream = Substitute.For<IAudioStream>();
            var plug = new Plug<IAudioStream>(stream);
            var socket = new Socket<IAudioStream>();

            plug.ConnectTo(socket);
            plug.IsConnected.Should().Be.True();
        }

        [Fact]
        public void ConnectedSocketIsConnected()
        {
            var stream = Substitute.For<IAudioStream>();
            var plug = new Plug<IAudioStream>(stream);
            var socket = new Socket<IAudioStream>();

            plug.ConnectTo(socket);
            socket.IsConnected.Should().Be.True();
        }

        [Fact]
        public void ConnectingSetsSocketChannel()
        {
            var stream = Substitute.For<IAudioStream>();
            var plug = new Plug<IAudioStream>(stream);
            var socket = new Socket<IAudioStream>();

            plug.ConnectTo(socket);
            Assert.Same(stream, socket.Channel);
        }

        [Fact]
        public void CanReconnectSameConnection()
        {
            var stream = Substitute.For<IAudioStream>();
            var plug = new Plug<IAudioStream>(stream);
            var socket = new Socket<IAudioStream>();

            plug.ConnectTo(socket);

            plug.ConnectTo(socket).Should().Be.True();
        }

        [Fact]
        public void CannotConnectToNewSocketWithoutDisconnecting()
        {
            var stream = Substitute.For<IAudioStream>();
            var plug = new Plug<IAudioStream>(stream);
            var socket1 = new Socket<IAudioStream>();
            var socket2 = new Socket<IAudioStream>();

            plug.ConnectTo(socket1);

            plug.ConnectTo(socket2).Should().Be.False();
        }

        [Fact]
        public void CannotConnectNewPlugWithoutDisconnecting()
        {
            var stream1 = Substitute.For<IAudioStream>();
            var plug1 = new Plug<IAudioStream>(stream1);
            var stream2 = Substitute.For<IAudioStream>();
            var plug2 = new Plug<IAudioStream>(stream2);
            var socket = new Socket<IAudioStream>();

            plug1.ConnectTo(socket);

            plug2.ConnectTo(socket).Should().Be.False();
        }

        [Fact]
        public void CanDisconnectPlug()
        {
            var stream = Substitute.For<IAudioStream>();
            var plug = new Plug<IAudioStream>(stream);
            var socket = new Socket<IAudioStream>();

            plug.ConnectTo(socket);

            plug.Disconnect();
            plug.IsConnected.Should().Be.False();
        }

        [Fact]
        public void DisconnectingPlugDisconnectsSocket()
        {
            var stream = Substitute.For<IAudioStream>();
            var plug = new Plug<IAudioStream>(stream);
            var socket = new Socket<IAudioStream>();

            plug.ConnectTo(socket);

            plug.Disconnect();
            socket.IsConnected.Should().Be.False();
        }
    }
}
