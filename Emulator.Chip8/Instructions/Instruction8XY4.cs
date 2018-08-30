namespace Emulator.Chip8.Instructions
{
    [Instruction(0x8004)]
    public class Instruction8XY4 : InstructionBase
    {
        public Instruction8XY4(Interpreter interpreter) : base(interpreter)
        {
        }

        public override void Execute()
        {
            Vf = (byte) (Vx + Vy > 255 ? 1 : 0);
            Vx += Vy;
        }
    }
}