using System;

namespace Emulator.Chip8.Instructions
{
    [Instruction(0xC000)]
    public class InstructionCXNN : InstructionBase
    {
        private readonly Random _random = new Random();

        public InstructionCXNN(Chip8 chip8) : base(chip8)
        {
        }

        public override void Execute()
        {
            var randomValue = (byte)_random.Next(0, 256);
            Chip8.Vx = (byte)(randomValue & Chip8.NN);

        }
    }
}