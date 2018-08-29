using Emulator.Chip8.Events;
using System.Collections.Generic;

namespace Emulator.Chip8
{
    public class Chip8
    {
        public Publisher Publisher { get; set; }
        public Graphics Graphics { get; }

        public ushort Opcode { get; set; }
        public ushort ProgramCounter { get; set; }
        public ushort I { get; set; }
        public byte[] Memory { get; private set; }
        public byte[] V { get; private set; }

        public Chip8()
        {
            Publisher = new Publisher();
            Graphics = new Graphics();

            Initialize();
        }

        public void Initialize()
        {
            Opcode = 0;
            Memory = new byte[4096];
            V = new byte[16];
            I = 0;
            ProgramCounter = 0x200;
            Graphics.Clear();
        }

        public void LoadRom(byte[] rom)
        {
            rom.CopyTo(Memory, 0x200);
        }

        public void IncrementProgramCounter()
        {
            ProgramCounter += 2;
        }

        public void DecrementProgramCounter()
        {
            ProgramCounter -= 2;
        }
    }
}