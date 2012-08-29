namespace WinHill.Audio.Configuration
{
    using System.Collections.Generic;
    using System.ComponentModel;

    public abstract class AudioSettingsBase : IAudioSettings
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected abstract IEnumerable<ITechnology> GetTechnologies();
        
        public IEnumerable<ITechnology> Technologies
        {
            get { return GetTechnologies(); }
        }

        private IDevice device;
        public IDevice Device
        {
            get { return device; }
            set
            {
                if (value != device)
                {
                    device = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Device"));
                        PropertyChanged(this, new PropertyChangedEventArgs("SampleRate"));
                        PropertyChanged(this, new PropertyChangedEventArgs("Channels"));
                    }
                }
            }
        }

        public double SampleRate
        {
            get
            {
                if (device == null)
                    return 0.0;

                return device.SampleRate;
            }
        }

        public int Channels
        {
            get
            {
                if (device == null)
                    return 0;

                return device.Channels;
            }
        }
    }
}
