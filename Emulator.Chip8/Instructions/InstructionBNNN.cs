namespace Emulator.Chip8.Instructions
{
    [Instruction(0xB000)]
    public class InstructionBNNN : InstructionBase
    {
        public InstructionBNNN(Interpreter interpreter) : base(interpreter)
        {
        }

        public override void Execute()
        {
            Interpreter.ProgramCounter = (ushort)(V0 + NNN);
        }
    }
}