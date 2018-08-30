namespace Emulator.Chip8.Instructions
{
    [Instruction(0x00E0)]
    public class Instruction00E0 : InstructionBase
    {
        public Instruction00E0(Interpreter interpreter) : base(interpreter)
        {
        }

        public override void Execute()
        {
            Interpreter.Graphics.Clear();
            Interpreter.DrawFlag = true;
        }
    }
}