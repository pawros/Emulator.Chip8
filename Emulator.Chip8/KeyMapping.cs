using System.Collections.Generic;
using OpenTK.Input;

namespace Emulator.Chip8
{
    public static class KeyMapping
    {
        public static readonly Dictionary<Key, byte> Mapping = new Dictionary<Key, byte>
        {
            [Key.Number1] = 0x0,
            [Key.Number2] = 0x1,
            [Key.Number3] = 0x2,
            [Key.Number4] = 0x3,
            [Key.Q] = 0x4,
            [Key.W] = 0x5,
            [Key.E] = 0x6,
            [Key.R] = 0x7,
            [Key.A] = 0x8,
            [Key.S] = 0x9,
            [Key.D] = 0xA,
            [Key.F] = 0xB,
            [Key.Z] = 0xC,
            [Key.X] = 0xD,
            [Key.C] = 0xE,
            [Key.V] = 0xF,
        };


    }
}