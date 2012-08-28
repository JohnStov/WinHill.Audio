namespace WinHill.Audio.Contracts
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Xml.Linq;

    using Blocks;
    using Containers;

    using ReactiveUI;

    using Streams;

    [ContractClassFor(typeof(IAudioBlock))]
    public abstract class AudioBlockContract : IAudioBlock
    {
        public ReactiveCollection<IAudioConnector> Inputs
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

        public string Name
        {
            get { return default(string); }
            set { }
        }

        public Type BlockType { get { return default(Type); } }

        public void NotifyBlockLoading(XElement element)
        {
            Contract.Requires(element != null);
        }

        public void NotifyBlockSaving(XElement element)
        {
            Contract.Requires(element != null);
        }

        public IObservable<XElement> BlockLoading
        {
            get { throw new NotImplementedException(); }
        }

        public IObservable<XElement> BlockSaving
        {
            get { throw new NotImplementedException(); }
        }
    }
}
