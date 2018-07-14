namespace Emulator.Chip8.Instructions
{
    [Instruction(0x6000)]
    public class Instruction6XNN : Instruction
    {
        public Instruction6XNN(Chip8 chip8) : base(chip8)
        {
        }

        public override void Execute()
        {
            Chip8.Vx = Chip8.NN;
        }
    }
}