using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Runtime.InteropServices;

namespace Emulator.Chip8
{
    public class Chip8
    {
        public Display Display { get; }
        public ushort Opcode { get; set; }
        public byte[] Memory { get; }
        public byte[] V { get; }
        public ushort I { get; set; }
        public ushort ProgramCounter { get; set; }
        public byte DelayTimer { get; set; }
        public byte SoundTimer { get; set; }
        public Stack<ushort> Stack { get; }
        public byte[] Keys { get; set; }


        public byte N => (byte)(Opcode & 0xF);
        public byte NN => (byte)(Opcode & 0xFF);
        public ushort NNN => (ushort)(Opcode & 0xFFF);
        public byte Vx
        {
            get => V[Opcode >> 8 & 0xF];
            set => V[Opcode >> 8 & 0xF] = value;
        }

        public byte Vy
        {
            get => V[Opcode >> 4 & 0xF];
            set => V[Opcode >> 4 & 0xF] = value;
        }

        public Chip8()
        {
            Display = new Display();

            Opcode = 0;
            Memory = new byte[4096];
            V = new byte[16];
            I = 0;
            ProgramCounter = 0x200;
            Stack = new Stack<ushort>();
            Keys = new byte[16];
        }

        public void LoadRom(byte[] rom)
        {
            rom.CopyTo(Memory, 0x200);
        }
    }
}