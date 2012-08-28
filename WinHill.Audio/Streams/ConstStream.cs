namespace WinHill.Audio.Streams
{
    public class ConstStream : AudioStreamBase
    {
        public double Value { get; set; }

        protected override double GetNext() { return Value; }
    }
}