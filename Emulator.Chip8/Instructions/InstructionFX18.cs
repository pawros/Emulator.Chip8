namespace Emulator.Chip8.Instructions
{
    [Instruction(0xF018)]
    public class InstructionFX18 : InstructionBase
    {
        public InstructionFX18(Chip8 chip8) : base(chip8)
        {
        }

        public override void Execute()
        {
            Chip8.SoundTimer = Chip8.Vx;
        }
    }
}