namespace Emulator.Chip8.Instructions
{
    [Instruction(0xF029)]
    public class InstructionFX29 : InstructionBase
    {
        public InstructionFX29(Interpreter interpreter) : base(interpreter)
        {
        }

        public override void Execute()
        {
            Interpreter.Register.I = (ushort)(Vx * 5);
        }
    }
}