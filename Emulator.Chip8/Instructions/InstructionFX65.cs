namespace Emulator.Chip8.Instructions
{
    [Instruction(0xF065)]
    public class InstructionFX65 : Instruction
    {
        public InstructionFX65(Chip8 chip8) : base(chip8)
        {
        }

        public override void Execute()
        {
            for (var x = 0; x <= Chip8.X; x++)
            {
                Chip8.V[x] = Chip8.Memory[Chip8.I + x];
            }
        }
    }
}