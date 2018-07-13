using System.IO;

namespace Emulator.Chip8
{
    public class Machine
    {
        private const string RomPath = "C:/Dev/SpaceInvaders.ch8";

        private readonly Processor _processor;
        private readonly Chip8 _chip8;
        // private Display _display;

        public Machine()
        {
            _chip8 = new Chip8();
            _processor = new Processor(_chip8);
        }

        public void InsertRom(string path)
        {
            var rom = File.ReadAllBytes(path);
            _chip8.LoadRom(rom);
        }

        public void Run()
        {
            InsertRom(RomPath);

            while (true)
            {
                _processor.ExecuteCycle();
            }
        }
    }
}