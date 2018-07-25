namespace Emulator.Chip8.Instructions
{
    [Instruction(0x8007)]
    public class Instruction8XY7 : InstructionBase
    {
        public Instruction8XY7(Chip8 chip8) : base(chip8)
        {
        }

        public override void Execute()
        {
            Chip8.V[0xF] = (byte)(Chip8.Vy >= Chip8.Vx ? 1 : 0);
            Chip8.Vx = (byte)(Chip8.Vy - Chip8.Vx);
        }
    }
}