namespace Emulator.Chip8.Instructions
{
    [Instruction(0xF015)]
    public class InstructionFX15 : InstructionBase
    {
        public InstructionFX15(Interpreter interpreter) : base(interpreter)
        {
        }

        public override void Execute()
        {
            Interpreter.DelayTimer = Vx;
        }
    }
}