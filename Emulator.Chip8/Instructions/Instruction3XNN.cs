namespace Emulator.Chip8.Instructions
{
    [Instruction(0x3000)]
    public class Instruction3XNN : Instruction
    {
        public Instruction3XNN(Chip8 chip8) : base(chip8)
        {
        }

        public override void Execute()
        {
            if (Chip8.Vx == Chip8.NN)
            {
                Chip8.ProgramCounter += 2;
            }
        }
    }
}