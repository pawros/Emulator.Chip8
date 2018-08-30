using System.Drawing;

namespace Emulator.Chip8.Gui.Display
{
    public class DisplayParameters
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Scale { get; set; }
        public int Size { get; set; }
        public Color BackgroundColor { get; set; }
        public Color ForegroundColor { get; set; }

        public DisplayParameters()
        {
            Width = 64;
            Height = 32;
            Size = Width * Height;
            Scale = 10;
            BackgroundColor = Color.FromArgb(202, 220, 159);
            ForegroundColor = Color.FromArgb(15, 56, 15);
        }
    }
}