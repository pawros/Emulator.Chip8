namespace Emulator.Chip8
{
    public interface IRegister
    {
        ushort I { get; set; }
        byte[] V { get; }
    }
}