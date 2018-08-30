namespace Emulator.Chip8.Instructions
{
    [Instruction(0xE09E)]
    public class InstructionEX9E : InstructionBase
    {
        public InstructionEX9E(Interpreter interpreter) : base(interpreter)
        {
        }

        public override void Execute()
        {
            if (Interpreter.Input.Keys[Vx])
            {
                Interpreter.ProgramCounter += 2;
            }
        }
    }
}