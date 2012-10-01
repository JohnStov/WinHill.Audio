namespace WinHill.Audio.Blocks
{
    public interface IOutput
    {
        IAudioBlock Block { get; }

        string Name { get; }

        // connect an input to this output
        bool Connect(IInput output);

        // disconnect and return previously connected input
        IInput Disconnect();

        // the connected input
        IInput Connected { get; }
    }
}