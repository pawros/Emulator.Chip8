namespace Emulator.Chip8.Instructions
{
    [Instruction(0x9000)]
    public class Instruction9XY0 : InstructionBase
    {
        public Instruction9XY0(Interpreter interpreter) : base(interpreter)
        {
        }

        public override void Execute()
        {
            if (Vx != Vy)
            {
                Interpreter.ProgramCounter += 2;
            }
        }
    }
}