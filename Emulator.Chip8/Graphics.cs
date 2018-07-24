using System;
using System.IO;
using System.Text;

namespace Emulator.Chip8
{
    public class Graphics
    {
        private const int Width = 64;
        private const int Height = 32;

        public byte[] VideoMemory { get; }

        public Graphics()
        {
            VideoMemory = new byte[Width * Height];
        }

        public bool Draw(byte x, byte y, byte n, ushort i, byte[] memory)
        {
            var collided = false;
            for (var line = 0; line < n; line++)
            {
                var row = memory[i + line];
                for (var pixel = 0; pixel < 8; pixel++)
                {
                    if ((row & (0x80 >> pixel)) != 0)
                    {
                        var offset = (y + line) * Width + x + pixel;
                        if (offset < VideoMemory.Length)
                        {
                            if (VideoMemory[offset] == 1)
                            {
                                collided = true;
                            }

                            VideoMemory[offset] ^= 1;
                        }
                    }
                }
            }
            return collided;
        }

        public void Clear()
        {
            Array.Clear(VideoMemory, 0, Width * Height);
        }
    }
}