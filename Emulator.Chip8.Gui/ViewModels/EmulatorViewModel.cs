using Emulator.Chip8.Gui.Display;
using OpenTK;
using OpenTK.Graphics;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK.Input;

namespace Emulator.Chip8.Gui.ViewModels
{
    public class EmulatorViewModel : BaseViewModel
    {
        private const double FramesPerSecond = 60.0;

        private readonly Interpreter interpreter;
        private Task renderWindowTask;
        private readonly Renderer renderer;

        private GameWindow renderWindow;
        
        public string Opcode
        {
            get => Get<string>();
            set => Set(value);
        }

        public int ClockSpeed
        {
            get => Get<int>();
            set => Set(value);
        }

        public UiCommand NextCycle { get; }

        public UiCommand IncreaseSpeed { get; }
        public UiCommand DecreaseSpeed { get; }

        public EmulatorViewModel(Interpreter interpreter)
        {
            renderer = new Renderer(new DisplayParameters());
            this.interpreter = interpreter;
            this.interpreter.LoadRom("SpaceInvaders.ch8");

            ClockSpeed = 600;

            renderWindowTask = Task.Factory.StartNew(RunRenderWindow);

            NextCycle = new UiCommand(() =>
            {
                interpreter.ExecuteCycle();
                Update();
            });

            IncreaseSpeed = new UiCommand(() =>
            {
                ClockSpeed += 50;
            });

            DecreaseSpeed = new UiCommand(() =>
            {
                ClockSpeed -= 50;
            });
        }

        private void RunEmulator()
        {
            while (true)
            {
                interpreter.ExecuteCycle();
                Update();
            }
        }

        private void RunRenderWindow()
        {
            renderWindow = new GameWindow(640, 320);
            renderWindow.Load += RenderWindowOnLoad;
            renderWindow.UpdateFrame += RenderWindowOnUpdateFrame;
            renderWindow.RenderFrame += RenderWindowOnRenderFrame;

            renderWindow.KeyDown += RenderWindowOnKeyDown;
            renderWindow.KeyUp += RenderWindowOnKeyUp;

            renderWindow.Run(1.0 / FramesPerSecond);
        }
        
        private void RenderWindowOnKeyDown(object sender, KeyboardKeyEventArgs e)
        {
            interpreter.SetKeyDown(e.Key);
        }

        private void RenderWindowOnKeyUp(object sender, KeyboardKeyEventArgs e)
        {
            interpreter.SetKeyUp(e.Key);
        }

        private void RenderWindowOnLoad(object sender, EventArgs e)
        {
            renderWindow.MakeCurrent();
            renderer.SetupScene();
        }

        private void RenderWindowOnUpdateFrame(object sender, FrameEventArgs e)
        {
            var cycles = 0;
            while (cycles < ClockSpeed / FramesPerSecond)
            {
                interpreter.ExecuteCycle();
                Update();
                cycles++;
            }
        }

        private void RenderWindowOnRenderFrame(object sender, FrameEventArgs e)
        {
            renderer.ClearScene();
            renderer.RenderScene(interpreter.VideoMemory);
            renderWindow.SwapBuffers();
        }

        private void Update()
        {
            Opcode = $"{interpreter.Opcode:X4}";
        }
    }
}