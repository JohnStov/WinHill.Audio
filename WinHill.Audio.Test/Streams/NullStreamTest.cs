namespace WinHill.Audio.Test.Streams
{
    using System.Linq;

    using NUnit.Framework;

    using Audio.Streams;

    [TestFixture]
    public class NullStreamTest
    {
        [Test]
        public void NullStreamAlwaysYieldsZero()
        {
            var stream = new NullStream();

            Assert.That(stream.Take(10), Is.EqualTo(new[] { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 }));
        }
    }
}