namespace Emulator.Chip8
{
    public interface IGraphics
    {
        byte this[int i] { get; set; }

        byte IsCollision { get; }
        byte[] VideoMemory { get; }

        void Clear();
        void Draw(byte x, byte y, byte[] drawData);
    }
}