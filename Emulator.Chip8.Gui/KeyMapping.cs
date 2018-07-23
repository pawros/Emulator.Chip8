using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Input;

namespace Emulator.Chip8.Gui
{
    public static class KeyMapping
    {
        public static readonly Dictionary<Keys, byte> Mapping = new Dictionary<Keys, byte>
        {
            [Keys.D1] = 0x0,
            [Keys.D2] = 0x1,
            [Keys.D3] = 0x2,
            [Keys.D4] = 0x3,
            [Keys.Q] = 0x4,
            [Keys.W] = 0x5,
            [Keys.E] = 0x6,
            [Keys.R] = 0x7,
            [Keys.A] = 0x8,
            [Keys.S] = 0x9,
            [Keys.D] = 0xA,
            [Keys.F] = 0xB,
            [Keys.Z] = 0xC,
            [Keys.X] = 0xD,
            [Keys.C] = 0xE,
            [Keys.V] = 0xF,
        };


    }
}