namespace Emulator.Chip8.Instructions
{
    public abstract class InstructionBase : IInstruction
    {
        protected Interpreter Interpreter;

        protected InstructionBase(Interpreter interpreter)
        {
            Interpreter = interpreter;
        }

        protected byte N => (byte)(Interpreter.Opcode & 0xF);
        protected byte NN => (byte)(Interpreter.Opcode & 0xFF);
        protected ushort NNN => (ushort)(Interpreter.Opcode & 0xFFF);

        protected byte X => (byte)(Interpreter.Opcode >> 8 & 0xF);
        protected byte Y => (byte)(Interpreter.Opcode >> 4 & 0xF);

        protected byte Vx
        {
            get => Interpreter.Register.V[X];
            set => Interpreter.Register.V[X] = value;
        }

        protected byte Vy
        {
            get => Interpreter.Register.V[Y];
            set => Interpreter.Register.V[Y] = value;
        }

        protected byte V0
        {
            get => Interpreter.Register.V[0x0];
            set => Interpreter.Register.V[0x0] = value;
        }

        protected byte Vf
        {
            get => Interpreter.Register.V[0xF];
            set => Interpreter.Register.V[0xF] = value;
        }

        public abstract void Execute();
    }
}