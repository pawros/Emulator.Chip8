using System.Linq;

namespace Emulator.Chip8
{
    public static class OpcodeHelper
    {
        private static readonly ushort[] OpcodeBranched4B = { 0x0000, 0xE000, 0xF000 };
        private static readonly ushort[] OpcodeBranched8B = { 0x8000 };

        public static ushort GetOpCodeKey(ushort opcode)
        {
            var opcodeKey = (ushort)(opcode & 0xF000);

            if (OpcodeBranched8B.Contains(opcodeKey))
            {
                return (ushort)(opcode & 0xFF);
            }

            if (OpcodeBranched4B.Contains(opcodeKey))
            {
                return (ushort)(opcode & 0xF0FF);
            }

            return opcodeKey;
        }
    }
}