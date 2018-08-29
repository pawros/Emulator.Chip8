using System.IO;
using System.Threading;
using System.Threading.Tasks;
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

        private Task task;

        public VirtualMachine()
        {
            chip8 = new Chip8();
            processor = new Processor(chip8);
            task = new Task(() =>
            {
                while (true)
                {
                    processor.ExecuteCycle();
                }

            });
        }

        public void InsertRom(string path)
        {
            var rom = File.ReadAllBytes(path);
            chip8.LoadRom(rom);
        }

        public void Run()
        {
            InsertRom(RomPath);
            task.Start();

            //while (true)
            //{
            //    processor.ExecuteCycle();
            //}
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