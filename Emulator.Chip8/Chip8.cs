﻿using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Runtime.InteropServices;
using Emulator.Chip8.Events;

namespace Emulator.Chip8
{
    public class Chip8
    {
        public Graphics Graphics { get; }
        public ushort Opcode { get; set; }
        public byte[] Memory { get; }
        public byte[] V { get; }
        public ushort I { get; set; }
        public ushort ProgramCounter { get; set; }
        public byte DelayTimer { get; set; }
        public byte SoundTimer { get; set; }
        public Stack<ushort> Stack { get; }
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

        public Publisher Publisher { get; set; }

        public Chip8()
        {
            Publisher = new Publisher();

            Graphics = new Graphics();

            Opcode = 0;
            Memory = new byte[4096];
            V = new byte[16];
            I = 0;
            ProgramCounter = 0x200;
            Stack = new Stack<ushort>();
            Keys = new bool[16];
        }

        public void LoadRom(byte[] rom)
        {
            rom.CopyTo(Memory, 0x200);
        }
    }
}