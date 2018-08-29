namespace Emulator.Chip8.Instructions
{
    [Instruction(0x8006)]
    public class Instruction8XY6 : InstructionBase
    {
        public Instruction8XY6(Interpreter interpreter) : base(interpreter)
        {
        }

        public override void Execute()
        {
            Vf = (byte) (Vx & 0x1);
            Vx >>= 0x1;
        }
    }
}