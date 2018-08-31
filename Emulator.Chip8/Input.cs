namespace Emulator.Chip8
{
    public class Input
    {
        public bool[] Keys { get; }

        public Input()
        {
            Keys = new bool[16];
        }

        public void SetKey(byte index, bool state)
        {
            Keys[index] = state;
        }
    }
}