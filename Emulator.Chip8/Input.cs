namespace Emulator.Chip8
{
    public class Input
    {
        public bool[] Keys { get; }

        public Input()
        {
            Keys = new bool[16];
        }
    }
}