namespace Emulator.Chip8.Instructions
{
    [Instruction(0xA000)]
    public class InstructionANNN : InstructionBase
    {
        public InstructionANNN(Interpreter interpreter) : base(interpreter)
        {
        }

        public override void Execute()
        {
            Interpreter.Register.I = NNN;
        }
    }
}