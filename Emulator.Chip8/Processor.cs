using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Emulator.Chip8
{
    public class Processor
    {
        private readonly Chip8 _chip8;
        private Dictionary<ushort, Action> _instructions;

        private int _cycleCouter;

        public Processor(Chip8 chip8)
        {
            _chip8 = chip8;

            InitializeInstructions();
        }

        public void ExecuteCycle()
        {
            _cycleCouter++;

            FetchOpCode();
            ExecuteInstruction();
        }

        private void FetchOpCode()
        {
            _chip8.Opcode = (ushort)(_chip8.Memory[_chip8.ProgramCounter] << 8 | _chip8.Memory[_chip8.ProgramCounter + 1]);
        }

        private void ExecuteInstruction()
        {
            var opcodeKey = OpcodeHelper.GetOpCodeKey(_chip8.Opcode);

            if (_instructions.TryGetValue(opcodeKey, out var action))
            {
                action();
            }
            else
            {
                throw new Exception($"Unknown OpCodeKey: {_chip8.Opcode:X4}\tCycle: {_cycleCouter}");
            }
        }

        private void InitializeInstructions()
        {
            _instructions = new Dictionary<ushort, Action>();

            var instructionsTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => type.IsDefined(typeof(InstructionAttribute)))
                .ToArray();

            foreach (var instructionType in instructionsTypes)
            {
                var instructionAttribute = (InstructionAttribute)Attribute.GetCustomAttribute(instructionType, typeof(InstructionAttribute));
                var instructionInstance = (IInstruction)Activator.CreateInstance(instructionType, _chip8);
                _instructions.Add(instructionAttribute.OpCodeKey, instructionInstance.Execute);
            }
        }
    }
}