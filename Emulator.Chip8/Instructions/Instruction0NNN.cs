namespace Emulator.Chip8.Instructions
{
    //[Instruction(0x0000)]
    public class Instruction0NNN : Instruction
    {
        public Instruction0NNN(Chip8 chip8) : base(chip8)
        {
        }

        public override void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}