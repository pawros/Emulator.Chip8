namespace Emulator.Chip8
{
    public class Register
    {
        public ushort I { get; set; }
        public byte[] V { get; set; }

        public Register()
        {
            I = 0x0;
            V = new byte[16];
        }
    }
}