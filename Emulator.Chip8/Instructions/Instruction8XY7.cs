namespace Emulator.Chip8.Instructions
{
    [Instruction(0x8007)]
    public class Instruction8XY7 : InstructionBase
    {
        public Instruction8XY7(Interpreter interpreter) : base(interpreter)
        {
        }

        public override void Execute()
        {
            Vf = (byte)(Vy >= Vx ? 1 : 0);
            Vx = (byte)(Vy - Vx);
        }
    }
}