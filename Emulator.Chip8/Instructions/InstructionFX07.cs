namespace Emulator.Chip8.Instructions
{
    [Instruction(0xF007)]
    public class InstructionFX07 : InstructionBase
    {
        public InstructionFX07(Chip8 chip8) : base(chip8)
        {
        }

        public override void Execute()
        {
            Chip8.Vx = Chip8.DelayTimer;
        }
    }
}