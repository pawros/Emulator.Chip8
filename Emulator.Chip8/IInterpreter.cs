using OpenTK.Input;

namespace Emulator.Chip8
{
    public interface IInterpreter
    {
        ushort Opcode { get; }
        byte[] VideoMemory { get; }

        void ExecuteCycle();
        void ExecuteInstruction();
        void LoadRom(string path);
        void SetKeyDown(Key key);
        void SetKeyUp(Key key);
    }
}