namespace WinHill.Audio.Test.Streams
{
    using System.Linq;

    using NUnit.Framework;

    using WinHill.Audio.Streams;

    [TestFixture]
    public class ConstStreamTest
    {
        [Test]
        public void DefaultConstStreamAlwaysYieldsZero()
        {
            var stream = new ConstStream();

            Assert.That(stream.Take(10), Is.EqualTo(new [] {0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0}));
        }

        [Test]
        public void ConstStreamAlwaysYieldsValue()
        {
            var stream = new ConstStream { Value = 1.23 };

            Assert.That(stream.Take(10), Is.EqualTo(new[] { 1.23, 1.23, 1.23, 1.23, 1.23, 1.23, 1.23, 1.23, 1.23, 1.23 }));
        }

        [Test]
        public void ChangingValueChangesYieldedValue()
        {
            var stream = new ConstStream { Value = 1.23 };

            Assert.That(stream.Take(5), Is.EqualTo(new[] { 1.23, 1.23, 1.23, 1.23, 1.23 }));

            stream.Value = 2.34;

            Assert.That(stream.Take(5), Is.EqualTo(new[] { 2.34, 2.34, 2.34, 2.34, 2.34 }));
        }
    }
}
