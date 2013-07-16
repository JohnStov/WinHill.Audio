
namespace WinHill.Audio.Test.Streams
{
    using System.Linq;
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

            stream.Take(5).Should().Equal(Enumerable.Range(0, 5).Select(x => (float)x));

            stream.GetEnumerator().Reset();

            stream.Take(5).Should().Equal(Enumerable.Range(5, 5).Select(x => (float)x));
        }
    }
}
