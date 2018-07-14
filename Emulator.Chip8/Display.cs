using System;
using System.IO;
using System.Text;

namespace Emulator.Chip8
{
    public class Display
    {
        private const int Width = 64;
        private const int Height = 32;

        public byte[] Screen { get; }

        public Display()
        {
            Screen = new byte[Width * Height];
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
                        var offset = (y + line) * 64 + x + pixel;
                        if (Screen[offset] == 1)
                        {
                            collided = true;
                        }

                        Screen[offset] ^= 1;
                    }
                }
            }
            return collided;
        }

        public void DrawToConsole()
        {
            //Console.Clear();
            var builder = new StringBuilder();

            for (var y = 0; y < Height; y++)
            {
                for (var x = 0; x < Width; x++)
                {
                    var offset = y * Width + x;
                    builder.Append(Screen[offset] == 1 ? "█" : " ");
                }

                builder.Append(Environment.NewLine);
            }

            //Console.Write(builder.ToString());
            File.WriteAllText("C:/Dev/Display.txt", builder.ToString());
        }
    }
}