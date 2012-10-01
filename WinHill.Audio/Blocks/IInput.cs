namespace WinHill.Audio.Blocks
{
    public interface IInput
    {
        IAudioBlock Block { get; }
        
        string Name { get; }

        // connect an output to this input
        bool Connect(IOutput output);

        // disconnect and return previously connected output
        IOutput Disconnect();

        // the connected output
        IOutput Connected { get; }
    }
}
