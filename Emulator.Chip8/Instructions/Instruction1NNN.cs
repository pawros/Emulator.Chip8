namespace Emulator.Chip8.Instructions
{
    [Instruction(0x1000)]
    public class Instruction1NNN : InstructionBase
    {
        public Instruction1NNN(Chip8 chip8) : base(chip8)
        {
        }

        public override void Execute()
        {
            Chip8.ProgramCounter = Chip8.NNN;
        }
    }
}