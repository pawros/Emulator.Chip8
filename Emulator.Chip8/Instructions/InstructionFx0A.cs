using System.Threading;

namespace Emulator.Chip8.Instructions
{
    [Instruction(0xF00A)]
    public class InstructionFX0A : InstructionBase
    {
        public InstructionFX0A(Chip8 chip8) : base(chip8)
        {
        }

        public override void Execute()
        {
            Thread.Sleep(16);
            if (Chip8.IsHalted)
            {
                for (var key = 0; key < Chip8.Keys.Length; key++)
                {
                    if (Chip8.Keys[key])
                    {
                        Chip8.IsHalted = false;
                        Chip8.Vx = (byte)key;
                        return;
                    }
                }
            }

            Chip8.IsHalted = true;
            Chip8.DecrementProgramCounter();
        }
    }
}