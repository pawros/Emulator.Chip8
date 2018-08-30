namespace Emulator.Chip8.Instructions
{
    [Instruction(0xE0A1)]
    public class InstructionEXA1 : InstructionBase
    {
        public InstructionEXA1(Interpreter interpreter) : base(interpreter)
        {
        }

        public override void Execute()
        {
            if (!Interpreter.Input.Keys[Vx])
            {
                Interpreter.ProgramCounter += 2;
            }
        }
    }
}