namespace Emulator.Chip8.Instructions
{
    [Instruction(0x9000)]
    public class Instruction9XY0 : InstructionBase
    {
        public Instruction9XY0(Chip8 chip8) : base(chip8)
        {
        }

        public override void Execute()
        {
            if (Chip8.Vx != Chip8.Vy)
            {
                Chip8.IncrementProgramCounter();
            }
        }
    }
}