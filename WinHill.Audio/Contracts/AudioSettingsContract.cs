namespace WinHill.Audio.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics.Contracts;

    using ReactiveUI;

    using Configuration;

    [ContractClassFor(typeof(IAudioSettings))]
    public abstract class AudioSettingsContract : IAudioSettings
    {
        public IDisposable SuppressChangeNotifications()
        {
            return default(IDisposable);
        }

        public IObservable<IObservedChange<object, object>> Changing
        {
            get
            {
                return default(IObservable<IObservedChange<object, object>>);
            }
        }

        public IObservable<IObservedChange<object, object>> Changed
        {
            get
            {
                return default(IObservable<IObservedChange<object, object>>);
            }
        }

        public IEnumerable<ITechnology> Technologies
        {
            get
            {
                Contract.Ensures(Contract.Result<IEnumerable<ITechnology>>() != null);
                return default(IEnumerable<ITechnology>);
            }
        }

        public IDevice Device
        {
            get { return default(IDevice); }
            set {}
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

// These events aren't used - needed for compilation
#pragma warning disable 67
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;
#pragma warning restore 67
    }
}