using System.IO;
using Emulator.Chip8.Events;

namespace Emulator.Chip8
{
    public class VirtualMachine
    {
        private const string RomPath = "SpaceInvaders.ch8";
        //private const string RomPath = "Breakout.ch8";

        private readonly Processor processor;
        private readonly Chip8 chip8;

        public Publisher Publisher => chip8.Publisher;

        public VirtualMachine()
        {
            chip8 = new Chip8();
            processor = new Processor(chip8);
        }

        public void InsertRom(string path)
        {
            var rom = File.ReadAllBytes(path);
            chip8.LoadRom(rom);
        }

        public void Run()
        {
            InsertRom(RomPath);

            while (true)
            {
                processor.ExecuteCycle();
            }
        }

        public byte[] GetVideoMemory()
        {
            return chip8.Graphics.VideoMemory;
        }

        public void SetKeyPressed(byte index, bool state)
        {
            chip8.Keys[index] = state;
        }
    }
}