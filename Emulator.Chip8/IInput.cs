namespace Emulator.Chip8
{
    public interface IInput
    {
        bool[] Keys { get; }

        void SetKey(byte index, bool state);
    }
}