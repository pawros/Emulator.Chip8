namespace Emulator.Chip8.Instructions
{
    [Instruction(0xB000)]
    public class InstructionBNNN : InstructionBase
    {
        public InstructionBNNN(Chip8 chip8) : base(chip8)
        {
        }

        public override void Execute()
        {
            Chip8.ProgramCounter = (ushort)(Chip8.V[0x0] + Chip8.NNN);
        }
    }
}