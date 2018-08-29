using System;

namespace Emulator.Chip8.Instructions
{
    [Instruction(0xC000)]
    public class InstructionCXNN : InstructionBase
    {
        private readonly Random _random = new Random();

        public InstructionCXNN(Interpreter interpreter) : base(interpreter)
        {
        }

        public override void Execute()
        {
            var randomValue = (byte)_random.Next(0, byte.MaxValue + 1);
            Vx = (byte)(randomValue & NN);

        }
    }
}