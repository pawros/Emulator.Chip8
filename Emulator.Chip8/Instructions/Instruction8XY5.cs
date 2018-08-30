namespace Emulator.Chip8.Instructions
{
    [Instruction(0x8005)]
    public class Instruction8XY5 : InstructionBase
    {
        public Instruction8XY5(Interpreter interpreter) : base(interpreter)
        {
        }

        public override void Execute()
        {
            Vf = (byte)(Vx >= Vy ? 1 : 0);
            Vx -= Vy;
        }
    }
}