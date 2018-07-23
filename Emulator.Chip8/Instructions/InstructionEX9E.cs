namespace Emulator.Chip8.Instructions
{
    [Instruction(0xE09E)]
    public class InstructionEX9E : Instruction
    {
        public InstructionEX9E(Chip8 chip8) : base(chip8)
        {
        }

        public override void Execute()
        {
            if (Chip8.Keys[Chip8.Vx])
            {
                Chip8.ProgramCounter += 2;
            }
        }
    }
}