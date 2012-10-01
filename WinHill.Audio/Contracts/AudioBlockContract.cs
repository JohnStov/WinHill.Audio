namespace WinHill.Audio.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;

    using Blocks;

    [ContractClassFor(typeof(IAudioBlock))]
    public abstract class AudioBlockContract : IAudioBlock
    {
        public IEnumerable<IInput> Inputs
        {
            get { return default(IEnumerable<IInput>); }
        }

        public IEnumerable<IOutput> Outputs
        {
            get { return default(IEnumerable<IOutput>); }
        }

        [ContractInvariantMethod]
        private void ContractInvariant()
        {
            Contract.Invariant(Inputs.Count() + Outputs.Count() > 0);   
        }

        public string Name
        {
            get { return default(string); }
            set { }
        }

        public Type BlockType { get { return default(Type); } }
    }
}
