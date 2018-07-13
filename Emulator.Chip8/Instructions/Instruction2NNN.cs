namespace Emulator.Chip8.Instructions
{
    [Instruction(0x2000)]
    public class Instruction2NNN : Instruction
    {
        public Instruction2NNN(Chip8 chip8) : base(chip8)
        {
        }
    }
}