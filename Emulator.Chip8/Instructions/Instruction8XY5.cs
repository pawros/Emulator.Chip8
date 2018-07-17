namespace Emulator.Chip8.Instructions
{
    [Instruction(0x8005)]
    public class Instruction8XY5 : Instruction
    {
        public Instruction8XY5(Chip8 chip8) : base(chip8)
        {
        }

        public override void Execute()
        {
            Chip8.V[0xF] = (byte)(Chip8.Vx >= Chip8.Vy ? 1 : 0);
            Chip8.Vx -= Chip8.Vy;
        }
    }
}