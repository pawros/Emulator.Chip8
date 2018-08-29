namespace Emulator.Chip8.Instructions
{
    [Instruction(0x00EE)]
    public class Instruction00EE : InstructionBase
    { 
        public Instruction00EE(Interpreter interpreter) : base(interpreter)
        {
        }

        public override void Execute()
        {
            if (Interpreter.Stack.Count > 0)
            {
                Interpreter.ProgramCounter = Interpreter.Stack.Pop();
            }
        }
    }
}