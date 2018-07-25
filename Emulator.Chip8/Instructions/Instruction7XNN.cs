namespace Emulator.Chip8.Instructions
{
    [Instruction(0x7000)]
    public class Instruction7XNN : InstructionBase
    {
        public Instruction7XNN(Chip8 chip8) : base(chip8)
        {
        }

        public override void Execute()
        {
            Chip8.Vx += Chip8.NN;
        }
    }
}