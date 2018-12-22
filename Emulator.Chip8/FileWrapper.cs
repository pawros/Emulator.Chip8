using System.IO;

namespace Emulator.Chip8
{
    public class FileWrapper : IFileWrapper
    {
        public byte[] ReadBytes(string path)
        {
            return File.ReadAllBytes(path);
        }
    }
}