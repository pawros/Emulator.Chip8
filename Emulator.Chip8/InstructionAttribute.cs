using System;

namespace Emulator.Chip8
{
    [AttributeUsage(AttributeTargets.Class)]
    public class InstructionAttribute : Attribute
    {
        public InstructionAttribute(ushort opCodeKey)
        {
            this.OpCodeKey = opCodeKey;
        }

        public virtual ushort OpCodeKey { get; }
    }
}