namespace Emulator.Chip8.Instructions
{
    [Instruction(0xF007)]
    public class InstructionFX07 : InstructionBase
    {
        public InstructionFX07(Interpreter interpreter) : base(interpreter)
        {
        }

        public override void Execute()
        {
            Vx = Interpreter.DelayTimer;
        }
    }
}