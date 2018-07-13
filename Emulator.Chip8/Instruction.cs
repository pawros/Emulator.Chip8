using System;

namespace Emulator.Chip8
{
    public abstract class Instruction : IInstruction
    {
        protected Chip8 Chip8;

        protected Instruction(Chip8 chip8)
        {
            Chip8 = chip8;
        }

        public virtual void Execute()
        {
            Chip8.ProgramCounter += 2;
            const string format = "{0:X4}\t{1:X4}\t{2:X2}\t{3:X2}";
            Console.WriteLine(format,
                Chip8.Opcode,
                OpcodeHelper.GetOpCodeKey(Chip8.Opcode),
                OpcodeHelper.GetX(Chip8.Opcode),
                OpcodeHelper.GetY(Chip8.Opcode)
                );
        }
    }
}