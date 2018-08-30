namespace Emulator.Chip8.Instructions
{
    [Instruction(0xD000)]
    public class InstructionDXYN : InstructionBase
    {
        public InstructionDXYN(Interpreter interpreter) : base(interpreter)
        {
        }

        public override void Execute()
        {
            var drawData = Interpreter.Memory.GetDrawData(N, Interpreter.Register.I);
            Interpreter.Graphics.Draw(Vx, Vy, drawData);
            Vf = Interpreter.Graphics.IsCollision;
            Interpreter.DrawFlag = true;
        }
    }
}