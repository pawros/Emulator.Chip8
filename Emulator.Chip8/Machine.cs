using System.IO;
using Emulator.Chip8.Events;

namespace Emulator.Chip8
{
    public class Machine
    {
        private const string RomPath = "SpaceInvaders.ch8";

        private readonly Processor _processor;
        private readonly Chip8 _chip8;

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

        public byte[] GetVideoMemory()
        {
            return _chip8.Graphics.VideoMemory;
        }

        public void SetKeyPressed(byte index, bool state)
        {
            _chip8.Keys[index] = state;
        }

        public Publisher GetPublisher()
        {
            return _chip8.Publisher;
        }
    }
}