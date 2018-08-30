namespace Emulator.Chip8.Instructions
{
    [Instruction(0x2000)]
    public class Instruction2NNN : InstructionBase
    {
        public Instruction2NNN(Interpreter interpreter) : base(interpreter)
        {
        }

        public override void Execute()
        {
            Interpreter.Stack.Push(Interpreter.ProgramCounter);
            Interpreter.ProgramCounter = NNN;
        }
    }
}