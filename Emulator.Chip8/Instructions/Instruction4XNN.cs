namespace Emulator.Chip8.Instructions
{
    [Instruction(0x4000)]
    public class Instruction4XNN : InstructionBase
    {
        public Instruction4XNN(Chip8 chip8) : base(chip8)
        {
        }

        public override void Execute()
        {
            if (Chip8.Vx != Chip8.NN)
            {
                Chip8.IncrementProgramCounter();
            }
        }
    }
}