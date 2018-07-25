using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Timers;
using Emulator.Chip8.Instructions;

namespace Emulator.Chip8
{
    public class Processor
    {
        private readonly Chip8 chip8;
        private Dictionary<ushort, Action> instructions;

        private readonly Timer timer = new Timer(16);

        public Processor(Chip8 chip8)
        {
            this.chip8 = chip8;

            timer.Elapsed += UpdateTimers;
            timer.Start();

            InitializeInstructions();
        }

        public void ExecuteCycle()
        {
            FetchOpCode();
            ExecuteInstruction();
        }

        private void FetchOpCode()
        {
            chip8.Opcode = (ushort)(chip8.Memory[chip8.ProgramCounter] << 8 | chip8.Memory[chip8.ProgramCounter + 1]);
        }

        private void ExecuteInstruction()
        {
            var opcodeKey = OpcodeHelper.GetOpCodeKey(chip8.Opcode);
            chip8.IncrementProgramCounter();
            if (instructions.TryGetValue(opcodeKey, out var action))
            {
                action();
            }
            else
            {
                throw new Exception($"Unknown Opcode: {chip8.Opcode:X4}");
            }
        }

        private void UpdateTimers(object sender, ElapsedEventArgs e)
        {
            if (chip8.DelayTimer > 0)
            {
                chip8.DelayTimer--;
            }

            if (chip8.SoundTimer > 0)
            {
                chip8.SoundTimer--;
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
                var instructionInstance = (IInstruction)Activator.CreateInstance(instructionType, chip8);
                instructions.Add(instructionAttribute.OpcodeKey, instructionInstance.Execute);
            }
        }
    }
}