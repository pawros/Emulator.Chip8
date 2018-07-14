namespace Emulator.Chip8.Instructions
{
    //[Instruction(0x4000)]
    public class Instruction4XNN : Instruction
    {
        public Instruction4XNN(Chip8 chip8) : base(chip8)
        {
        }

        public override void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}