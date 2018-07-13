﻿namespace Emulator.Chip8.Instructions
{
    [Instruction(0x00E0)]
    public class Instruction00E0 : Instruction
    {
        public Instruction00E0(Chip8 chip8) : base(chip8)
        {
        }
    }
}