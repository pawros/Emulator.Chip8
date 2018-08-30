namespace Emulator.Chip8.Instructions
{
    [Instruction(0xF065)]
    public class InstructionFX65 : InstructionBase
    {
        public InstructionFX65(Interpreter interpreter) : base(interpreter)
        {
        }

        public override void Execute()
        {
            for (var x = 0; x <= X; x++)
            {
                Interpreter.Register.V[x] = Interpreter.Memory[Interpreter.Register.I + x];
            }
        }
    }
}