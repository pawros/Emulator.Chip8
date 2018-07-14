using System;

namespace Emulator.Chip8
{
    public abstract class Instruction : IInstruction
    {
        protected Chip8 Chip8;

        protected Instruction(Chip8 chip8)
        {
            Chip8 = chip8;
        }

        public abstract void Execute();
    }
}