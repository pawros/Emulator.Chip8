﻿namespace Emulator.Chip8.Instructions
{
    [Instruction(0xE0A1)]
    public class InstructionEXA1 : Instruction
    {
        public InstructionEXA1(Chip8 chip8) : base(chip8)
        {
        }

        public override void Execute()
        {
            if (Chip8.Keys[Chip8.Vx] != 0)
            {
                Chip8.ProgramCounter += 2;
            }
        }
    }
}