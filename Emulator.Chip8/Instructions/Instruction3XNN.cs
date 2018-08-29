namespace Emulator.Chip8.Instructions
{
    [Instruction(0x3000)]
    public class Instruction3XNN : InstructionBase
    {
        public Instruction3XNN(Interpreter interpreter) : base(interpreter)
        {
        }

        public override void Execute()
        {
            if (Vx == NN)
            {
                Interpreter.ProgramCounter += 2;
            }
        }
    }
}