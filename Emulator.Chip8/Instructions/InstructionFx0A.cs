namespace Emulator.Chip8.Instructions
{
    [Instruction(0xF00A)]
    public class InstructionFX0A : InstructionBase
    {
        public InstructionFX0A(Interpreter interpreter) : base(interpreter)
        {
        }

        public override void Execute()
        {
            //Thread.Sleep(16);
            if (Interpreter.IsHalted)
            {
                for (var key = 0; key < Interpreter.Input.Keys.Length; key++)
                {
                    if (Interpreter.Input.Keys[key])
                    {
                        Interpreter.IsHalted = false;
                        Vx = (byte)key;
                        return;
                    }
                }
            }

            Interpreter.IsHalted = true;
            Interpreter.ProgramCounter -= 2;
        }
    }
}