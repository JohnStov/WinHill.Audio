namespace WinHill.Audio.Test.Streams
{
    using System.Linq;
    using NUnit.Framework;
    using Audio.Streams;
    using NSubstitute;

    [TestFixture]
    class AudioConnectorTest
    {
        [Test]
        public void UnconnectedConnectorYieldsZero()
        {
            var connector = new AudioConnector();

            Assert.That(connector.Take(10), Is.EqualTo(new [] {0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0}));
        }

        [Test]
        public void ConnectedConnectorYieldsStreamValue()
        {
            var connector = new AudioConnector();
            connector.Connect(new ConstStream { Value = 1.23 });

            Assert.That(connector.Take(10), Is.EqualTo(new[] { 1.23, 1.23, 1.23, 1.23, 1.23, 1.23, 1.23, 1.23, 1.23, 1.23 }));
        }

        [Test]
        public void ConnectedThenDisconnectedConnectorYieldsZero()
        {
            var connector = new AudioConnector();
            connector.Connect(new ConstStream { Value = 1.23 });
            connector.Disconnect();

            Assert.That(connector.Take(10), Is.EqualTo(new[] { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 }));
        }

        [Test]
        public void YieldsStreamValueAfterConnecting()
        {
            var connector = new AudioConnector();

            Assert.That(connector.Take(5), Is.EqualTo(new[] { 0.0, 0.0, 0.0, 0.0, 0.0 }));

            connector.Connect(new ConstStream { Value = 2.34 });

            Assert.That(connector.Take(5), Is.EqualTo(new[] { 2.34, 2.34, 2.34, 2.34, 2.34 }));
        }

        [Test]
        public void YieldsZeroAfterDisconnecting()
        {
            var connector = new AudioConnector();
            connector.Connect(new ConstStream { Value = 2.34 });


            Assert.That(connector.Take(5), Is.EqualTo(new[] { 2.34, 2.34, 2.34, 2.34, 2.34 }));

            connector.Disconnect();

            Assert.That(connector.Take(5), Is.EqualTo(new[] { 0.0, 0.0, 0.0, 0.0, 0.0 }));
        }

        [Test]
        public void ConnectingNewStreamYieldsNewStreamValue()
        {
            var connector = new AudioConnector();
            connector.Connect(new ConstStream { Value = 2.34 });


            Assert.That(connector.Take(5), Is.EqualTo(new[] { 2.34, 2.34, 2.34, 2.34, 2.34 }));

            connector.Connect(new ConstStream { Value = 3.45 });

            Assert.That(connector.Take(5), Is.EqualTo(new[] { 3.45, 3.45, 3.45, 3.45, 3.45 }));
        }

        [Test]
        public void CanConnectUnconnectedStream()
        {
            var mockStream = Substitute.For<IConnectableAudioStream>();
            mockStream.Connector = null;

            var connector = new AudioConnector();
            var connected = connector.Connect(mockStream);

            Assert.That(connected, Is.True);
            Assert.That(connector.Connection, Is.SameAs(mockStream));
            Assert.That(mockStream.Connector, Is.SameAs(connector));
        }

        [Test]
        public void CannotConnectConnectedStream()
        {
            var mockStream = Substitute.For<IConnectableAudioStream>();
            var mockConnector = Substitute.For<IAudioConnector>();
            mockStream.Connector.Returns(mockConnector);

            var connector = new AudioConnector();
            var connected = connector.Connect(mockStream);

            Assert.That(connected, Is.False);
            Assert.That(connector.Connection, Is.Null);
            Assert.That(mockStream.Connector, Is.SameAs(mockConnector));
        }

        [Test]
        public void CanReconnectConnectedStream()
        {
            var mockStream = Substitute.For<IConnectableAudioStream>();
            mockStream.Connector = null;

            var connector = new AudioConnector();
            connector.Connect(mockStream);
            
            var connected = connector.Connect(mockStream);

            Assert.That(connected, Is.True);
            Assert.That(connector.Connection, Is.SameAs(mockStream));
            Assert.That(mockStream.Connector, Is.SameAs(connector));
        }

        [Test]
        public void DisconnectingStreamClearsConnector()
        {
            var mockStream = Substitute.For<IConnectableAudioStream>();
            mockStream.Connector = null;
            var connector = new AudioConnector();

            var connected = connector.Connect(mockStream);
            Assert.That(connected, Is.True);

            connector.Disconnect();
            
            Assert.That(connector.Connection, Is.Null);
            Assert.That(mockStream.Connector, Is.Null);
        }

    }
}
