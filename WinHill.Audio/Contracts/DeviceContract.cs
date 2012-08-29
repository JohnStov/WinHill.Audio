namespace WinHill.Audio.Contracts
{
    using System.Diagnostics.Contracts;

    using Configuration;

    [ContractClassFor(typeof(IDevice))]
    public abstract class DeviceContract : IDevice
    {
        public string Name
        {
            get
            {
                Contract.Ensures(!string.IsNullOrWhiteSpace(Contract.Result<string>()));
                return default(string);
            }
        }

        public IPlayback Player
        {
            get { return default (IPlayback); }
        }

        public double SampleRate
        {
            get
            {
                Contract.Ensures(Contract.Result<double>() >= 0.0);
                return default(double);
            }
        }

        public int Channels
        {
            get
            {
                Contract.Ensures(Contract.Result<int>() >= 0);
                return default(int);
            }
        }
    }
}