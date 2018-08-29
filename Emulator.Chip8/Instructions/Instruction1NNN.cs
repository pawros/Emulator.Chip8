namespace Emulator.Chip8.Instructions
{
    [Instruction(0x1000)]
    public class Instruction1NNN : InstructionBase
    {
        public Instruction1NNN(Interpreter interpreter) : base(interpreter)
        {
        }

        public override void Execute()
        {
            Interpreter.ProgramCounter = NNN;
        }
    }
}