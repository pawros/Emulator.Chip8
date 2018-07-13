using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Emulator.Chip8.Instructions;

namespace Emulator.Chip8
{
    class Program
    {
        static void Main(string[] args)
        {
            var machine = new Machine();
            machine.Run();
        }
    }
}
