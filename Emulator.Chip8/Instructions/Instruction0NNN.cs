namespace Emulator.Chip8.Instructions
{
    //[Instruction(0x0000)]
    public class Instruction0NNN : InstructionBase
    {
        public Instruction0NNN(Interpreter interpreter) : base(interpreter)
        {
        }

        public override void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}