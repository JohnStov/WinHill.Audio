namespace WinHill.Audio.Blocks
{
    using System;
    using System.Diagnostics.Contracts;

    [ContractClass(typeof(Contracts.AudioBlockContract))]
    public interface IAudioBlock
    {
        string Name { get; set;  }

        Type BlockType { get; }
    }
}