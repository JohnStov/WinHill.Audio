namespace WinHill.Audio.Blocks
{
    using System.Collections.Generic;

    public abstract class AudioBlockBase : IAudioBlock
    {
        private readonly List<IInput> inputs = new List<IInput>();
        private readonly List<IOutput> outputs = new List<IOutput>();

        public string Name { get; set; }

        public System.Type BlockType { get { return this.GetType(); } }

        public IEnumerable<IInput> Inputs { get { return inputs; } }

        public IEnumerable<IOutput> Outputs { get { return outputs; } }
    }
}