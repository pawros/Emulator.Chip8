namespace Emulator.Chip8.Instructions
{
    [Instruction(0x800E)]
    public class Instruction8XYE : InstructionBase
    {
        public Instruction8XYE(Chip8 chip8) : base(chip8)
        {
        }

        public override void Execute()
        {
            Chip8.V[0xF] = (byte) ((Chip8.Vx & 0xF0000000) != 0 ? 1 : 0);
            Chip8.Vx <<= 0x1;
        }
    }
}