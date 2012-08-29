namespace WinHill.Audio.Test.Configuration
{
    using System.Collections.Generic;
    using NSubstitute;
    using NUnit.Framework;
    using Audio.Configuration;
    using Should.Fluent;

    [TestFixture]
    public class AudioSettingsBaseTest
    {
        private class TestAudioSettings : AudioSettingsBase
        {
            protected override IEnumerable<ITechnology> GetTechnologies()
            {
                return new List<ITechnology>();
            }
        }


        [Test]
        public void TechnologiesListIsNotNull()
        {
            var audioSettings = new TestAudioSettings();

            audioSettings.Technologies.Should().Count.Exactly(0);
        }

        [Test]
        public void DeviceIsInitiallyNull()
        {
            var audioSettings = new TestAudioSettings();

            audioSettings.Device.Should().Be.Null();
        }

        [Test]
        public void CanSetDevice()
        {
            var mockDevice = Substitute.For<IDevice>();

            var audioSettings = new TestAudioSettings { Device = mockDevice };
            
            audioSettings.Device.Should().Equal(mockDevice);
        }

        [Test]
        public void SettingDeviceNotifiesPropertyChanged()
        {
            var mockDevice = Substitute.For<IDevice>();

            var audioSettings = new TestAudioSettings();
            var propertyNames = new List<string>();

            audioSettings.PropertyChanged += (_, e) => propertyNames.Add(e.PropertyName);

            audioSettings.Device = mockDevice;

            Assert.Contains("Device", propertyNames);
            Assert.Contains("SampleRate", propertyNames);
            Assert.Contains("Channels", propertyNames);
        }
    }
}
