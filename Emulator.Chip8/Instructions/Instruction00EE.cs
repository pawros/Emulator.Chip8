namespace Emulator.Chip8.Instructions
{
    [Instruction(0x00EE)]
    public class Instruction00EE : Instruction
    {
        public Instruction00EE(Chip8 chip8) : base(chip8)
        {
        }

        public override void Execute()
        {
            if (Chip8.Stack.Count > 0)
            {
                Chip8.ProgramCounter = Chip8.Stack.Pop();
            }
        }
    }
}