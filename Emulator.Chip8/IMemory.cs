namespace Emulator.Chip8
{
    public interface IMemory
    {
        byte this[int i] { get; set; }
        byte[] GetDrawData(byte n, ushort i);
        void LoadRom(byte[] rom);
        void Clear();
    }
}