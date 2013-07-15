namespace WinHill.Audio.Test.Streams
{
    using System.Linq;

    using Should.Fluent;

    using Xunit;
    using Audio.Streams;
    using NSubstitute;

    public class AudioConnectorTests
    {
        [Fact]
        public void UnconnectedConnectorYieldsZero()
        {
            var connector = new AudioConnector();

            connector.Take(10).Should().Equal(Enumerable.Repeat(0.0f, 10));
        }

        [Fact]
        public void ConnectedConnectorYieldsStreamValue()
        {
            var connector = new AudioConnector();
            connector.Connect(new AudioStream(() => 1.23f));

            connector.Take(10).Should().Equal(Enumerable.Repeat(1.23f, 10));
        }

        [Fact]
        public void ConnectedThenDisconnectedConnectorYieldsZero()
        {
            var connector = new AudioConnector();
            connector.Connect(new AudioStream(() => 1.23f));
            connector.Disconnect();

            connector.Take(10).Should().Equal(Enumerable.Repeat(0.0f, 10));
        }

        [Fact]
        public void YieldsStreamValueAfterConnecting()
        {
            var connector = new AudioConnector();

            connector.Take(5).Should().Equal(Enumerable.Repeat(0.0f, 5));

            connector.Connect(new AudioStream(() => 2.34f));

            connector.Take(5).Should().Equal(Enumerable.Repeat(2.34f, 5));
        }

        [Fact]
        public void YieldsZeroAfterDisconnecting()
        {
            var connector = new AudioConnector();
            connector.Connect(new AudioStream(() => 2.34f));

            connector.Take(5).Should().Equal(Enumerable.Repeat(2.34f, 5));

            connector.Disconnect();

            connector.Take(5).Should().Equal(Enumerable.Repeat(0.0f, 5));
        }

        [Fact]
        public void ConnectingNewStreamYieldsNewStreamValue()
        {
            var connector = new AudioConnector();
            connector.Connect(new AudioStream(() => 2.34f));


            connector.Take(5).Should().Equal(Enumerable.Repeat(2.34f, 5));

            connector.Connect(new AudioStream(() => 3.45f));

            connector.Take(5).Should().Equal(Enumerable.Repeat(3.45f, 5));
        }

        [Fact]
        public void CanConnectUnconnectedStream()
        {
            var mockStream = Substitute.For<IConnectableAudioStream>();
            mockStream.Connector = null;

            var connector = new AudioConnector();
            var connected = connector.Connect(mockStream);

            connected.Should().Be.True();
            // Should().Be.SameAs doesn't work
            Assert.Same(mockStream, connector.Connection);
            mockStream.Connector.Should().Be.SameAs(connector);
        }

        [Fact]
        public void CannotConnectConnectedStream()
        {
            var mockStream = Substitute.For<IConnectableAudioStream>();
            var mockConnector = Substitute.For<IAudioConnector>();
            mockStream.Connector.Returns(mockConnector);

            var connector = new AudioConnector();
            var connected = connector.Connect(mockStream);

            connected.Should().Be.False();
            connector.Connection.Should().Be.Null();
            mockStream.Connector.Should().Be.SameAs(mockConnector);
        }

        [Fact]
        public void CanReconnectConnectedStream()
        {
            var mockStream = Substitute.For<IConnectableAudioStream>();
            mockStream.Connector = null;

            var connector = new AudioConnector();
            connector.Connect(mockStream);
            
            var connected = connector.Connect(mockStream);

            connected.Should().Be.True();
            // Should().Be.SameAs doesn't work
            Assert.Same(mockStream, connector.Connection);
            mockStream.Connector.Should().Be.SameAs(connector);
        }

        [Fact]
        public void DisconnectingStreamClearsConnector()
        {
            var mockStream = Substitute.For<IConnectableAudioStream>();
            mockStream.Connector = null;
            var connector = new AudioConnector();

            var connected = connector.Connect(mockStream);
            connected.Should().Be.True();

            connector.Disconnect();
            
            connector.Connection.Should().Be.Null();
            mockStream.Connector.Should().Be.Null();
        }

    }
}
