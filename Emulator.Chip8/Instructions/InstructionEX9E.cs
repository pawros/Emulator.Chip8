using System.Threading;

namespace Emulator.Chip8.Instructions
{
    [Instruction(0xE09E)]
    public class InstructionEX9E : InstructionBase
    {
        public InstructionEX9E(Chip8 chip8) : base(chip8)
        {
        }

        public override void Execute()
        {
            Thread.Sleep(16);
            if (Chip8.Keys[Chip8.Vx])
            {
                Chip8.IncrementProgramCounter();
            }
        }
    }
}