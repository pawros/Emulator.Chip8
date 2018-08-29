using System;

namespace Emulator.Chip8
{
    public class Memory
    {
        private const int MemorySize = 4096;
        private readonly byte[] memoryArray = new byte[MemorySize];

        public byte this[int i]
        {
            get => memoryArray[i];
            set => memoryArray[i] = value;
        }

        public byte[] GetDrawData(byte n, ushort i)
        {
            var drawData = new byte[n];
            Array.Copy(memoryArray, i, drawData, 0, n);
            return drawData;
        }

        public void Clear()
        {
            Array.Clear(memoryArray, 0, MemorySize);
        }
    }
}