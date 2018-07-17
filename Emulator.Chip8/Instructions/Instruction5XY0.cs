﻿namespace Emulator.Chip8.Instructions
{
    [Instruction(0x5000)]
    public class Instruction5XY0 : Instruction
    {
        public Instruction5XY0(Chip8 chip8) : base(chip8)
        {
        }

        public override void Execute()
        {
            if (Chip8.Vx == Chip8.Vy)
            {
                Chip8.ProgramCounter += 2;
            }
        }
    }
}