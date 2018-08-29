namespace Emulator.Chip8.Instructions
{
    [Instruction(0x6000)]
    public class Instruction6XNN : InstructionBase
    {
        public Instruction6XNN(Interpreter interpreter) : base(interpreter)
        {
        }

        public override void Execute()
        {
            Vx = NN;
        }
    }
}