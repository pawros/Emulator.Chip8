namespace Emulator.Chip8
{
    public class Register : IRegister
    {
        public ushort I { get; set; }
        public byte[] V { get; }

        public Register()
        {
            I = 0x0;
            V = new byte[16];
        }
    }
}