namespace Emulator.Chip8.Instructions
{
    [Instruction(0xF029)]
    public class InstructionFX29 : InstructionBase
    {
        public InstructionFX29(Chip8 chip8) : base(chip8)
        {
        }

        public override void Execute()
        {
            Chip8.I = (ushort)(Chip8.Vx * 5);
        }
    }
}