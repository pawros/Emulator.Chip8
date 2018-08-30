using System;
using System.IO;
using System.Text;

namespace Emulator.Chip8
{
    public class Graphics
    {
        private const int Width = 64;
        private const int Height = 32;

        private readonly byte[] videoMemoryArray = new byte[Width * Height];

        public byte this[int i]
        {
            get => videoMemoryArray[i];
            set => videoMemoryArray[i] = value;
        }

        public byte IsCollision { get; private set; }

        public byte[] GetVideoMemory()
        {
            return videoMemoryArray;
        }

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
                        if (offset < videoMemoryArray.Length)
                        {
                            if (videoMemoryArray[offset] == 1)
                            {
                                IsCollision = 0x1;
                            }

                            videoMemoryArray[offset] ^= 1;
                        }
                    }
                }
            }
        }

        public void Clear()
        {
            Array.Clear(videoMemoryArray, 0, Width * Height);
        }
    }
}