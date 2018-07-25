using System;

namespace Emulator.Chip8.Instructions
{
    public abstract class InstructionBase : IInstruction
    {
        protected Chip8 Chip8;

        protected InstructionBase(Chip8 chip8)
        {
            Chip8 = chip8;
        }

        public abstract void Execute();
    }
}