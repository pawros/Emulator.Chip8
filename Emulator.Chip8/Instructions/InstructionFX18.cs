namespace Emulator.Chip8.Instructions
{
    [Instruction(0xF018)]
    public class InstructionFX18 : InstructionBase
    {
        public InstructionFX18(Interpreter interpreter) : base(interpreter)
        {
        }

        public override void Execute()
        {
            Interpreter.SoundTimer = Vx;
        }
    }
}