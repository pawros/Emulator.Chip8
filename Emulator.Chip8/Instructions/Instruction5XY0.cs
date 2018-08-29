namespace Emulator.Chip8.Instructions
{
    [Instruction(0x5000)]
    public class Instruction5XY0 : InstructionBase
    {
        public Instruction5XY0(Interpreter interpreter) : base(interpreter)
        {
        }

        public override void Execute()
        {
            if (Vx == Vy)
            {
                Interpreter.ProgramCounter += 2;
            }
        }
    }
}