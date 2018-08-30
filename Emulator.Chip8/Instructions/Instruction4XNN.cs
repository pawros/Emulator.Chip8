namespace Emulator.Chip8.Instructions
{
    [Instruction(0x4000)]
    public class Instruction4XNN : InstructionBase
    {
        public Instruction4XNN(Interpreter interpreter) : base(interpreter)
        {
        }

        public override void Execute()
        {
            if (Vx != NN)
            {
                Interpreter.ProgramCounter += 2;
            }
        }
    }
}