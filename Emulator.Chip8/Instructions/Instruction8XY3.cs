namespace Emulator.Chip8.Instructions
{
    [Instruction(0x8003)]
    public class Instruction8XY3 : Instruction
    {
        public Instruction8XY3(Chip8 chip8) : base(chip8)
        {
        }

        public override void Execute()
        {
            Chip8.Vx ^= Chip8.Vy;
        }
    }
}