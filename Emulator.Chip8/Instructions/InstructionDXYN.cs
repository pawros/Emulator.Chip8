﻿using System;
using System.IO;
using System.Threading;
using Emulator.Chip8.Events;

namespace Emulator.Chip8.Instructions
{
    [Instruction(0xD000)]
    public class InstructionDXYN : InstructionBase
    {
        public InstructionDXYN(Chip8 chip8) : base(chip8)
        {
        }

        public override void Execute()
        {
            Chip8.V[0xF] = (byte) (Chip8.Graphics.Draw(
                Chip8.Vx,
                Chip8.Vy,
                Chip8.N,
                Chip8.I,
                Chip8.Memory)
                ? 1
                : 0);

            Chip8.Publisher.Publish(EventArgs.Empty);
        }
    }
}