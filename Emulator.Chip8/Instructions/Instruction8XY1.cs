namespace Emulator.Chip8.Instructions
{
    [Instruction(0x8001)]
    public class Instruction8XY1 : InstructionBase
    {
        public Instruction8XY1(Chip8 chip8) : base(chip8)
        {
        }

        public override void Execute()
        {
            Chip8.Vx |= Chip8.Vy;
        }
    }
}