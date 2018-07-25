namespace Emulator.Chip8.Instructions
{
    [Instruction(0xA000)]
    public class InstructionANNN : InstructionBase
    {
        public InstructionANNN(Chip8 chip8) : base(chip8)
        {
        }

        public override void Execute()
        {
            Chip8.I = Chip8.NNN;
        }
    }
}