namespace Emulator.Chip8.Instructions
{
    [Instruction(0x8003)]
    public class Instruction8XY3 : InstructionBase
    {
        public Instruction8XY3(Interpreter interpreter) : base(interpreter)
        {
        }

        public override void Execute()
        {
            Vx ^= Vy;
        }
    }
}