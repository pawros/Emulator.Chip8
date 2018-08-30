namespace Emulator.Chip8.Instructions
{
    [Instruction(0xF01E)]
    public class InstructionFX1E : InstructionBase
    {
        public InstructionFX1E(Interpreter interpreter) : base(interpreter)
        {
        }

        public override void Execute()
        {
            Interpreter.Register.I += Vx;
        }
    }
}