using NSubstitute;

namespace WinHill.Audio.Test.Streams
{
    using System.Linq;

    using NUnit.Framework;

    using WinHill.Audio.Streams;

    [TestFixture]
    public class AudioStreamTest
    {
        [Test]
        public void CanCreateAsNullStream()
        {
            var stream = new AudioStream(() => 0.0);

            Assert.That(stream.Take(10), Is.EqualTo(new[] { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 }));
        }

        [Test]
        public void CanCreateAsConstStream()
        {
            var stream = new AudioStream(() => 1.23);

            Assert.That(stream.Take(10), Is.EqualTo(new[] { 1.23, 1.23, 1.23, 1.23, 1.23, 1.23, 1.23, 1.23, 1.23, 1.23 }));
        }

        [Test]
        public void ResetStreamHasNoEffect()
        {
            int index = 0;
            var stream = new AudioStream(() => (double)index++);

            var enumerator = stream.GetEnumerator();
            for (var i = 0; i < 5; ++i)
            {
                Assert.That(enumerator.Current, Is.EqualTo((double)i));
                enumerator.MoveNext();
            }
            enumerator.Reset();
            for (int i = 5; i < 10; ++i)
            {
                Assert.That(enumerator.Current, Is.EqualTo((double)i));
                enumerator.MoveNext();
            }
        }

        [Test]
        public void ConnectorDefaultsToNull()
        {
            var stream = new AudioStream(() => 0.0);
            Assert.That(stream.Connector, Is.Null); 
        }

        [Test]
        public void CanSetConnector()
        {
            var mockConnector = Substitute.For<IAudioConnector>();
            var stream = new AudioStream(() => 0.0) { Connector = mockConnector };
            Assert.That(stream.Connector, Is.Not.Null);
            Assert.That(stream.Connector, Is.SameAs(mockConnector));
        }
    }
}
