namespace Emulator.Chip8.Instructions
{
    [Instruction(0x7000)]
    public class Instruction7XNN : InstructionBase
    {
        public Instruction7XNN(Interpreter interpreter) : base(interpreter)
        {
        }

        public override void Execute()
        {
            Vx += NN;
        }
    }
}