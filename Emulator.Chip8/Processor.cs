using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Timers;

namespace Emulator.Chip8
{
    public class Processor
    {
        private readonly Chip8 _chip8;
        private Dictionary<ushort, Action> _instructions;

        private int _cycleCouter;

        private readonly Timer _timer = new Timer(16);

        public Processor(Chip8 chip8)
        {
            _chip8 = chip8;

            _timer.Elapsed += UpdateTimers;
            _timer.Start();

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
            _chip8.ProgramCounter += 2;
            if (_instructions.TryGetValue(opcodeKey, out var action))
            {
                action();
            }
            else
            {
                throw new Exception($"Unknown Opcode: {_chip8.Opcode:X4}\tCycle: {_cycleCouter}");
            }
        }

        private void UpdateTimers(object sender, ElapsedEventArgs e)
        {
            if (_chip8.DelayTimer > 0)
            {
                _chip8.DelayTimer--;
            }

            if (_chip8.SoundTimer > 0)
            {
                _chip8.SoundTimer--;
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
                _instructions.Add(instructionAttribute.OpcodeKey, instructionInstance.Execute);
            }
        }
    }
}