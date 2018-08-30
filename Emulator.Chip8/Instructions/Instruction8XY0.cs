namespace Emulator.Chip8.Instructions
{
    [Instruction(0x8000)]
    public class Instruction8XY0 : InstructionBase
    {
        public Instruction8XY0(Interpreter interpreter) : base(interpreter)
        {
        }

        public override void Execute()
        {
            Vx = Vy;
        }
    }
}