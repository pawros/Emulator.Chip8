namespace Emulator.Chip8
{
    public interface IFileWrapper
    {
        byte[] ReadBytes(string path);
    }
}