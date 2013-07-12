namespace WinHill.Audio.Blocks
{
    using System.Collections.Immutable;
    using System.Diagnostics.Contracts;

    [ContractClass(typeof(Contracts.AudioBlockContract))]
    public interface IAudioBlock
    {
        IImmutableList<IInput> Inputs { get; }

        IImmutableList<IOutput> Outputs { get; }
    }
}