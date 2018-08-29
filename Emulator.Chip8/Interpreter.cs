using Emulator.Chip8.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Timers;

namespace Emulator.Chip8
{
    public class Interpreter
    {
        private Dictionary<ushort, Action> instructions;
        private readonly Timer timer = new Timer(16);

        public ushort ProgramCounter;
        public ushort Opcode { get; private set; }
        public Stack<ushort> Stack { get; }

        public Register Register { get; }
        public Memory Memory { get; }
        public Graphics Graphics { get; }
        public Input Input { get; }

        public byte DelayTimer { get; set; }
        public byte SoundTimer { get; set; }

        public bool IsHalted { get; set; }

        public Interpreter()
        {
            ProgramCounter = 0x200;
            Opcode = 0x0;
            Stack = new Stack<ushort>();

            Register = new Register();
            Memory = new Memory();
            Graphics = new Graphics();
            Input = new Input();

            InitializeInstructions();
            InitializeTimer();
        }

        private void FetchOpcode()
        {
            Opcode = (ushort)(Memory[ProgramCounter] << 8 | Memory[ProgramCounter + 1]);
        }

        public void ExecuteCycle()
        {
            ProgramCounter += 2;
            ExecuteInstruction();
        }

        public void ExecuteInstruction()
        {
            var opcodeKey = OpcodeHelper.GetOpCodeKey(Opcode);
            if (instructions.TryGetValue(opcodeKey, out var executeInstruction))
            {
                executeInstruction();
            }
            else
            {
                throw new Exception($"Unknown opcode: {Opcode:X4}");
            }
        }
        
        private void InitializeInstructions()
        {
            instructions = new Dictionary<ushort, Action>();

            var instructionsTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => type.IsDefined(typeof(InstructionAttribute)))
                .ToArray();

            foreach (var instructionType in instructionsTypes)
            {
                var instructionAttribute = (InstructionAttribute)Attribute.GetCustomAttribute(instructionType, typeof(InstructionAttribute));
                var instructionInstance = (IInstruction)Activator.CreateInstance(instructionType, this);
                instructions.Add(instructionAttribute.OpcodeKey, instructionInstance.Execute);
            }
        }

        private void InitializeTimer()
        {
            timer.Elapsed += UpdateTimers;
            timer.Start();
        }

        private void UpdateTimers(object sender, ElapsedEventArgs e)
        {
            if (DelayTimer > 0)
            {
                DelayTimer--;
            }

            if (SoundTimer > 0)
            {
                SoundTimer++;
            }
        }
    }
}
