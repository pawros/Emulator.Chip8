namespace Emulator.Chip8.Instructions
{
    [Instruction(0x2000)]
    public class Instruction2NNN : InstructionBase
    {
        public Instruction2NNN(Chip8 chip8) : base(chip8)
        {
        }

        public override void Execute()
        {
            Chip8.Stack.Push(Chip8.ProgramCounter);
            Chip8.ProgramCounter = Chip8.NNN;
        }
    }
}