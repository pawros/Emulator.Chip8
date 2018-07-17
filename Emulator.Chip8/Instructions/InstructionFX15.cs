namespace Emulator.Chip8.Instructions
{
    [Instruction(0xF015)]
    public class InstructionFX15 : Instruction
    {
        public InstructionFX15(Chip8 chip8) : base(chip8)
        {
        }

        public override void Execute()
        {
            Chip8.DelayTimer = Chip8.Vx;
        }
    }
}