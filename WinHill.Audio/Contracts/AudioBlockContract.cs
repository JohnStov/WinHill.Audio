namespace WinHill.Audio.Contracts
{
    using System;
    using System.Diagnostics.Contracts;

    using Blocks;

    using Streams;

    [ContractClassFor(typeof(IAudioBlock))]
    public abstract class AudioBlockContract : IAudioBlock
    {
/*        public ObservableCollection<IAudioConnector> Inputs
        {
            get { return default(ReactiveCollection<IAudioConnector>); }
        }

        public ReactiveCollection<IConnectableAudioStream> Outputs
        {
            get { return default(ReactiveCollection<IConnectableAudioStream>); }
        }

        [ContractInvariantMethod]
        private void ContractInvariant()
        {
            Contract.Invariant(Inputs.Count + Outputs.Count > 0);   
        }
        */
        public string Name
        {
            get { return default(string); }
            set { }
        }

        public Type BlockType { get { return default(Type); } }
    }
}
