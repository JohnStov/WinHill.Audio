namespace WinHill.Audio.Blocks
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    [ContractClass(typeof(Contracts.AudioBlockContract))]
    public interface IAudioBlock
    {
        string Name { get; set;  }

        Type BlockType { get; }

        IEnumerable<IInput> Inputs { get; }

        IEnumerable<IOutput> Outputs { get; }
    }
}