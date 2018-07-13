using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Runtime.InteropServices;

namespace Emulator.Chip8
{
    public class Chip8
    {
        public ushort Opcode { get; set; }

        public byte[] Memory { get; }

        public byte[] V  { get; }

        public ushort I { get; set; }

        public ushort ProgramCounter { get; set; }

        public Chip8()
        {
            Opcode = 0;
            Memory = new byte[4096];
            V = new byte[16];
            ProgramCounter = 0x200;
            I = 0;
        }

        public void LoadRom(byte[] rom)
        {
            rom.CopyTo(Memory, 0x200);
        }
    }
}