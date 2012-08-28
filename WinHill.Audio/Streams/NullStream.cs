namespace WinHill.Audio.Streams
{
    public class NullStream : AudioStreamBase
    {
        protected override double GetNext() { return 0.0; }
    }
}