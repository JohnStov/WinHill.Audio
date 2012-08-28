namespace WinHill.Audio.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    using WinHill.Audio.Blocks;
    using WinHill.Audio.Containers;

    [ContractClassFor(typeof(IAudioBlockProvider))]
    public abstract class AudioBlockProviderContract : IAudioBlockProvider
    {
        public IAudioBlock GetAudioBlock(Type type)
        {
            Contract.Requires(type != null);
            Contract.Requires(type.IsAssignableFrom(typeof(IAudioBlock)));
            return default(IAudioBlock);
        }

        public IAudioBlock GetAudioBlock(Type type, IEnumerable<Tuple<string, string>> properties)
        {
            Contract.Requires(type != null);
            Contract.Requires(type.IsAssignableFrom(typeof(IAudioBlock)));
            Contract.Requires(properties != null);
            return default(IAudioBlock);
        }

        public IAudioBlock GetAudioBlock(string typeName)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(typeName));
            return default(IAudioBlock);
        }

        public IAudioBlock GetAudioBlock(string typeName, IEnumerable<Tuple<string, string>> properties)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(typeName));
            Contract.Requires(properties != null);
            return default(IAudioBlock);
        }

        public IEnumerable<AudioBlockType> GetAudioBlockTypes()
        {
            Contract.Ensures(Contract.Result<IEnumerable<AudioBlockPropertyType>>() != null);
            return default(IEnumerable<AudioBlockType>);
        }

        public void SetBlockProperties(ref IAudioBlock block, IEnumerable<Tuple<string, string>> properties)
        {
            Contract.Requires(block != null);
            Contract.Requires(properties != null);
        }

        public void SetBlockProperty(ref IAudioBlock block, Tuple<string, string> property)
        {
            Contract.Requires(block != null);
            Contract.Requires(property != null);
        }
    }
}