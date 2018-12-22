using System;
using System.IO;
using System.Text;

namespace Emulator.Chip8
{
    public class Graphics : IGraphics
    {
        private const int Width = 64;
        private const int Height = 32;

        public byte[] VideoMemory { get; } = new byte[Width * Height];

        public byte this[int i]
        {
            get => VideoMemory[i];
            set => VideoMemory[i] = value;
        }

        public byte IsCollision { get; private set; }

        public void Draw(byte x, byte y, byte[] drawData)
        {
            IsCollision = 0x0;

            for (var line = 0; line < drawData.Length; line++)
            {
                for (var pixel = 0; pixel < 8; pixel++)
                {
                    if ((drawData[line] & (0x80 >> pixel)) != 0)
                    {
                        var offset = (y + line) * Width + x + pixel;
                        if (offset < VideoMemory.Length)
                        {
                            if (VideoMemory[offset] == 1)
                            {
                                IsCollision = 0x1;
                            }

                            VideoMemory[offset] ^= 1;
                        }
                    }
                }
            }
        }

        public void Clear()
        {
            Array.Clear(VideoMemory, 0, Width * Height);
        }
    }
}