
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
            var stream = new AudioStream(() => 0.0);

            stream.Take(10).Should().Equal(new[] { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 });
        }

        [Fact]
        public void CanCreateAsConstStream()
        {
            var stream = new AudioStream(() => 1.23);

            stream.Take(10).Should().Equal(new[] { 1.23, 1.23, 1.23, 1.23, 1.23, 1.23, 1.23, 1.23, 1.23, 1.23 });
        }

        [Fact]
        public void ResetStreamHasNoEffect()
        {
            int index = 0;
            var stream = new AudioStream(() => (double)index++);

            var enumerator = stream.GetEnumerator();
            for (var i = 0; i < 5; ++i)
            {
                enumerator.Current.Should().Equal(i);
                enumerator.MoveNext();
            }
            enumerator.Reset();
            for (int i = 5; i < 10; ++i)
            {
                enumerator.Current.Should().Equal(i);
                enumerator.MoveNext();
            }
        }

        [Fact]
        public void ConnectorDefaultsToNull()
        {
            var stream = new AudioStream(() => 0.0);
            stream.Connector.Should().Be.Null(); 
        }

        [Fact]
        public void CanSetConnector()
        {
            var mockConnector = Substitute.For<IAudioConnector>();
            var stream = new AudioStream(() => 0.0) { Connector = mockConnector };
            stream.Connector.Should().Not.Be.Null();
            stream.Connector.Should().Be.SameAs(mockConnector);
        }
    }
}
