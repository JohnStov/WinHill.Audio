
namespace WinHill.Audio.Test.Streams
{
    using System.Linq;
    using NSubstitute;
    using Should.Fluent;
    using WinHill.Audio.Streams;
    using Xunit;

    public class AudioStreamTests
    {
        [Fact]
        public void CanCreateAsNullStream()
        {
            var stream = new AudioStream(() => 0.0f);

            stream.Take(10).Should().Equal(Enumerable.Repeat(0.0f, 10));
        }

        [Fact]
        public void CanCreateAsConstStream()
        {
            var stream = new AudioStream(() => 1.23f);

            stream.Take(10).Should().Equal(Enumerable.Repeat(1.23f, 10));
        }

        [Fact]
        public void ResetStreamHasNoEffect()
        {
            int index = 0;
            var stream = new AudioStream(() => (float)index++);

            var enumerator = stream.GetEnumerator();
            for (var i = 0; i < 5; ++i)
            {
                enumerator.Current.Should().Equal((float)i);
                enumerator.MoveNext();
            }
            enumerator.Reset();
            for (int i = 5; i < 10; ++i)
            {
                enumerator.Current.Should().Equal((float)i);
                enumerator.MoveNext();
            }
        }

        [Fact]
        public void ConnectorDefaultsToNull()
        {
            var stream = new AudioStream(() => 0.0f);
            stream.Connector.Should().Be.Null(); 
        }

        [Fact]
        public void CanSetConnector()
        {
            var mockConnector = Substitute.For<IAudioConnector>();
            var stream = new AudioStream(() => 0.0f) { Connector = mockConnector };
            stream.Connector.Should().Not.Be.Null();
            stream.Connector.Should().Be.SameAs(mockConnector);
        }
    }
}
