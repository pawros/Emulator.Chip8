using System;
using System.IO;
using System.Threading;

namespace Emulator.Chip8.Instructions
{
    [Instruction(0xD000)]
    public class InstructionDXYN : Instruction
    {
        public InstructionDXYN(Chip8 chip8) : base(chip8)
        {
        }

        public override void Execute()
        {
            //Console.WriteLine($"DRAW({Chip8.Vx:X2}, {Chip8.Vy:X2}, {Chip8.N:X2})");
            Chip8.V[0xF] = (byte) (Chip8.Display.Draw(
                Chip8.Vx,
                Chip8.Vy,
                Chip8.N,
                Chip8.I,
                Chip8.Memory)
                ? 1
                : 0);

            Chip8.Display.DrawToConsole();
            //Thread.Sleep(33);

            //var sprite = string.Empty;
            //for (var i = 0; i < Chip8.N; i++)
            //{
            //    //Console.WriteLine(Convert.ToString(Chip8.Memory[Chip8.I + i], 2).PadLeft(8, '0'));
            //    var line = Convert.ToString(Chip8.Memory[Chip8.I + i], 2).PadLeft(8, '0').Replace("1", "█").Replace("0", " ") + Environment.NewLine;
            //    sprite += line;
            //}
            //File.WriteAllText("C:/Dev/Display.txt", sprite);
            //Thread.Sleep(1000);

            //Chip8.V[0xF] = 1;
        }
    }
}