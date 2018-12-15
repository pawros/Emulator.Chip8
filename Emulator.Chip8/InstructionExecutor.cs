using Emulator.Chip8.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Timers;

namespace Emulator.Chip8
{
    public class InstructionExecutor
    {
        private IDictionary<ushort, Action> instructions;

        #region Private fields

        private readonly Random _random = new Random();

        private readonly Register register;
        private readonly Memory memory;
        private readonly Graphics graphics;
        private readonly Input input;

        private ushort programCounter;
        private ushort opcode;
        private Stack<ushort> stack;

        private Timer timer;
        private byte delayTimer;
        private byte soundTimer;

        private bool isHalted;
        private bool drawFlag;

        #endregion

        #region Register aliases

        private byte N => (byte)(opcode & 0xF);
        private byte NN => (byte)(opcode & 0xFF);
        private ushort NNN => (ushort)(opcode & 0xFFF);

        private byte X => (byte)(opcode >> 8 & 0xF);
        private byte Y => (byte)(opcode >> 4 & 0xF);

        private byte Vx
        {
            get => register.V[X];
            set => register.V[X] = value;
        }

        private byte Vy
        {
            get => register.V[Y];
            set => register.V[Y] = value;
        }

        private byte V0
        {
            get => register.V[0x0];
            set => register.V[0x0] = value;
        }

        private byte Vf
        {
            get => register.V[0xF];
            set => register.V[0xF] = value;
        }

        #endregion

        public InstructionExecutor(
            Register register,
            Memory memory,
            Graphics graphics,
            Input input)
        {
            this.register = register;
            this.memory = memory;
            this.graphics = graphics;
            this.input = input;

            Initialize();
            InitializeInstructions();
            InitializeTimer();
        }

        public void ExecuteCycle()
        {
            FetchOpcode();
            programCounter += 2;
            ExecuteInstruction();
        }

        public void ExecuteInstruction()
        {
            var opcodeKey = OpcodeHelper.GetOpCodeKey(opcode);
            if (instructions.TryGetValue(opcodeKey, out var executeInstruction))
            {
                executeInstruction();
            }
            else
            {
                throw new Exception($"Unknown opcode: {opcode:X4}");
            }
        }

        #region Private methods

        private void Initialize()
        {
            programCounter = 0x200;
            opcode = 0x0;
            stack = new Stack<ushort>();
        }

        private void InitializeInstructions()
        {
            instructions = new Dictionary<ushort, Action>();
            var instructionMethods = GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(x => x.GetCustomAttributes().OfType<InstructionAttribute>().Any());

            foreach (var instructionMethod in instructionMethods)
            {
                var instructionAttribute = (InstructionAttribute)instructionMethod.GetCustomAttribute(typeof(InstructionAttribute));
                instructions.Add(instructionAttribute.OpcodeKey, () => instructionMethod.Invoke(this, null));
            }
        }

        private void InitializeTimer()
        {
            void UpdateTimers(object sender, ElapsedEventArgs e)
            {
                if (delayTimer > 0)
                {
                    delayTimer--;
                }

                if (soundTimer > 0)
                {
                    soundTimer--;
                }
            }

            timer = new Timer(16);
            timer.Elapsed += UpdateTimers;
            timer.Start();
        }

        private void FetchOpcode()
        {
            opcode = (ushort)(memory[programCounter] << 8 | memory[programCounter + 1]);
        }

        #endregion

        #region Instructions

        [Instruction(0x00E0)]
        private void Instruction00E0()
        {
            graphics.Clear();
            drawFlag = true;
        }

        [Instruction(0x00EE)]
        private void Instruction00EE()
        {
            if (stack.Count > 0)
            {
                programCounter = stack.Pop();
            }
        }

        [Instruction(0x0000)]
        private void Instruction0NNN()
        {
            throw new System.NotImplementedException();
        }

        [Instruction(0x1000)]
        private void Instruction1NNN()
        {
            programCounter = NNN;
        }

        [Instruction(0x2000)]
        private void Instruction2NNN()
        {
            stack.Push(programCounter);
            programCounter = NNN;
        }

        [Instruction(0x3000)]
        private void Instruction3XNN()
        {
            if (Vx == NN)
            {
                programCounter += 2;
            }
        }

        [Instruction(0x4000)]
        private void Instruction4XNN()
        {
            if (Vx != NN)
            {
                programCounter += 2;
            }
        }

        [Instruction(0x5000)]
        private void Instruction5XY0()
        {
            if (Vx == Vy)
            {
                programCounter += 2;
            }
        }

        [Instruction(0x6000)]
        private void Instruction6XNN()
        {
            Vx = NN;
        }

        [Instruction(0x7000)]
        private void Instruction7XNN()
        {
            Vx += NN;
        }

        [Instruction(0x8000)]
        private void Instruction8XY0()
        {
            Vx = Vy;
        }

        [Instruction(0x8001)]
        private void Instruction8XY1()
        {
            Vx |= Vy;
        }

        [Instruction(0x8002)]
        private void Instruction8XY2()
        {
            Vx &= Vy;
        }

        [Instruction(0x8003)]
        private void Instruction8XY3()
        {
            Vx ^= Vy;
        }

        [Instruction(0x8004)]
        private void Instruction8XY4()
        {
            Vf = (byte)(Vx + Vy > 255 ? 1 : 0);
            Vx += Vy;
        }

        [Instruction(0x8005)]
        private void Instruction8XY5()
        {
            Vf = (byte)(Vx >= Vy ? 1 : 0);
            Vx -= Vy;
        }
        
        [Instruction(0x8006)]
        private void Instruction8XY6()
        {
            Vf = (byte)(Vx & 0x1);
            Vx >>= 0x1;
        }

        [Instruction(0x8007)]
        private void Instruction8XY7()
        {
            Vf = (byte)(Vy >= Vx ? 1 : 0);
            Vx = (byte)(Vy - Vx);
        }

        [Instruction(0x800E)]
        private void Instruction8XYE()
        {
            Vf = (byte)((Vx & 0xF0000000) != 0 ? 1 : 0);
            Vx <<= 0x1;
        }

        [Instruction(0x9000)]
        private void Instruction9XY0()
        {
            if (Vx != Vy)
            {
                programCounter += 2;
            }
        }

        [Instruction(0xA000)]
        private void InstructionANNN()
        {
            register.I = NNN;
        }

        [Instruction(0xB000)]
        private void InstructionBNNN()
        {
            programCounter = (ushort)(V0 + NNN);

        }

        [Instruction(0xC000)]
        private void InstructionCXNN()
        {
            var randomValue = (byte)_random.Next(0, byte.MaxValue + 1);
            Vx = (byte)(randomValue & NN);
        }

        [Instruction(0xD000)]
        private void InstructionDXYN()
        {
            var drawData = memory.GetDrawData(N, register.I);
            graphics.Draw(Vx, Vy, drawData);
            Vf = graphics.IsCollision;
            drawFlag = true;
        }

        [Instruction(0xE09E)]
        private void InstructionEX9E()
        {
            if (input.Keys[Vx])
            {
                programCounter += 2;
            }
        }

        [Instruction(0xE0A1)]
        private void InstructionEXA1()
        {
            if (!input.Keys[Vx])
            {
                programCounter += 2;
            }
        }

        [Instruction(0xF007)]
        private void InstructionFX07()
        {
            Vx = delayTimer;
        }

        [Instruction(0xF00A)]
        private void InstructionFX0A()
        {
            if (isHalted)
            {
                for (var key = 0; key < input.Keys.Length; key++)
                {
                    if (input.Keys[key])
                    {
                        isHalted = false;
                        Vx = (byte)key;
                        return;
                    }
                }
            }

            isHalted = true;
            programCounter -= 2;
        }

        [Instruction(0xF015)]
        private void InstructionFX15()
        {
            delayTimer = Vx;
        }

        [Instruction(0xF018)]
        private void InstructionFX18()
        {
            soundTimer = Vx;
        }

        [Instruction(0xF01E)]
        private void InstructionFX1E()
        {
            register.I += Vx;
        }

        [Instruction(0xF029)]
        private void InstructionFX29()
        {
            register.I = (ushort)(Vx * 5);
        }

        [Instruction(0xF065)]
        private void InstructionFX65()
        {
            for (var x = 0; x <= X; x++)
            {
                register.V[x] = memory[register.I + x];
            }
        }

        #endregion

    }
}