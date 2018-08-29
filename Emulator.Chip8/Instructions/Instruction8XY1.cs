namespace Emulator.Chip8.Instructions
{
    [Instruction(0x8001)]
    public class Instruction8XY1 : InstructionBase
    {
        public Instruction8XY1(Interpreter interpreter) : base(interpreter)
        {
        }

        public override void Execute()
        {
            Vx |= Vy;
        }
    }
}