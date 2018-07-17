namespace Emulator.Chip8.Instructions
{
    [Instruction(0x8004)]
    public class Instruction8XY4 : Instruction
    {
        public Instruction8XY4(Chip8 chip8) : base(chip8)
        {
        }

        public override void Execute()
        {
            Chip8.V[0xF] = (byte) (Chip8.Vx + Chip8.Vy > 255 ? 1 : 0);
            Chip8.Vx += Chip8.Vy;
        }
    }
}