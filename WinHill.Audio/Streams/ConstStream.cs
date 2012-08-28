namespace WinHill.Audio.Streams
{
    public class ConstStream : AudioStreamBase
    {
        public double Value { private get; set; }

        protected override double GetNext() { return Value; }
    }
}