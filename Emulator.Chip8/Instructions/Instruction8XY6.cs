namespace Emulator.Chip8.Instructions
{
    [Instruction(0x8006)]
    public class Instruction8XY6 : Instruction
    {
        public Instruction8XY6(Chip8 chip8) : base(chip8)
        {
        }

        public override void Execute()
        {
            Chip8.V[0xF] = (byte) (Chip8.Vx & 0x1);
            Chip8.Vx = (byte) (Chip8.Vy >> 1);
        }
    }
}