namespace Emulator.Chip8.Instructions
{
    [Instruction(0x800E)]
    public class Instruction8XYE : InstructionBase
    {
        public Instruction8XYE(Interpreter interpreter) : base(interpreter)
        {
        }

        public override void Execute()
        {
            Vf = (byte) ((Vx & 0xF0000000) != 0 ? 1 : 0);
            Vx <<= 0x1;
        }
    }
}