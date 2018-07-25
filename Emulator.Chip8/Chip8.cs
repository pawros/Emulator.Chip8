using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Runtime.InteropServices;
using Emulator.Chip8.Events;

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

        public byte DelayTimer { get; set; }
        public byte SoundTimer { get; set; }

        public Stack<ushort> Stack { get; private set; }
        public bool[] Keys { get; set; }
        public bool IsHalted { get; set; }

        public byte N => (byte)(Opcode & 0xF);
        public byte NN => (byte)(Opcode & 0xFF);
        public ushort NNN => (ushort)(Opcode & 0xFFF);

        public byte X => (byte)(Opcode >> 8 & 0xF);
        public byte Y => (byte)(Opcode >> 4 & 0xF);

        public byte Vx
        {
            get => V[X];
            set => V[X] = value;
        }

        public byte Vy
        {
            get => V[Y];
            set => V[Y] = value;
        }

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
            Stack = new Stack<ushort>();
            Keys = new bool[16];
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