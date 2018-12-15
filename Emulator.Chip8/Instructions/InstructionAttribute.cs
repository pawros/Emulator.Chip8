using System;

namespace Emulator.Chip8.Instructions
{
    [AttributeUsage(AttributeTargets.Method)]
    public class InstructionAttribute : Attribute
    {
        public InstructionAttribute(ushort opcodeKey)
        {
            OpcodeKey = opcodeKey;
        }

        public virtual ushort OpcodeKey { get; }
    }
}