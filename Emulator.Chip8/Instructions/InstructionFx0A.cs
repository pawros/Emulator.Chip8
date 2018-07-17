namespace Emulator.Chip8.Instructions
{
    [Instruction(0xF00A)]
    public class InstructionFx0A : Instruction
    {
        public InstructionFx0A(Chip8 chip8) : base(chip8)
        {
        }

        public override void Execute()
        {
            if(Chip8.IsHalted)
            {
                for (var key = 0; key < Chip8.Keys.Length; key++)
                {
                    
                }
            }

            Chip8.IsHalted = true;
            Chip8.ProgramCounter -= 2;
        }
    }
}