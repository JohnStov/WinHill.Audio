namespace WinHill.Audio.Contracts
{
    using System.Collections.Immutable;
    using System.Diagnostics.Contracts;
    using System.Linq;

    using Blocks;

    [ContractClassFor(typeof(IAudioBlock))]
    public abstract class AudioBlockContract : IAudioBlock
    {
        public IImmutableList<IInput> Inputs
        {
            get { return default(IImmutableList<IInput>); }
        }

        public IImmutableList<IOutput> Outputs
        {
            get { return default(IImmutableList<IOutput>); }
        }

        [ContractInvariantMethod]
        private void ContractInvariant()
        {
            Contract.Invariant(Inputs.Count() + Outputs.Count() > 0);   
        }
    }
}
