namespace Emulator.Chip8.Instructions
{
    [Instruction(0xF01E)]
    public class InstructionFX1E : InstructionBase
    {
        public InstructionFX1E(Chip8 chip8) : base(chip8)
        {
        }

        public override void Execute()
        {
            Chip8.I += Chip8.Vx;
        }
    }
}