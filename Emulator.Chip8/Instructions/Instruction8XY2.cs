namespace Emulator.Chip8.Instructions
{
    [Instruction(0x8002)]
    public class Instruction8XY2 : InstructionBase
    {
        public Instruction8XY2(Interpreter interpreter) : base(interpreter)
        {
        }

        public override void Execute()
        {
            Vx &= Vy;
        }
    }
}