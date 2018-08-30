using Emulator.Chip8.Gui.Display;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics;

namespace Emulator.Chip8.Gui.ViewModels
{
    public class EmulatorViewModel : ObservableObject
    {
        private Interpreter interpreter;
        private Task interpreterTask;
        private Renderer renderer;

        public GLControl EmulatorDisplayControl { get; private set; }

        public string Opcode
        {
            get => Get<string>();
            set => Set(value);
        }

        public EmulatorViewModel()
        {
            InitializeDisplayControl();

            renderer = new Renderer(new DisplayParameters());
            interpreter = new Interpreter();
            interpreter.LoadRom("SpaceInvaders.ch8");
            interpreterTask = Task.Factory.StartNew(RunEmulator);
        }

        private void InitializeDisplayControl()
        {
            EmulatorDisplayControl = new GLControl(new GraphicsMode(32, 64), 2, 0, GraphicsContextFlags.Default);
            EmulatorDisplayControl.Dock = DockStyle.Fill;
            EmulatorDisplayControl.Load += OnLoad;
            EmulatorDisplayControl.Paint += OnPaint;
        }

        private void OnLoad(object sender, EventArgs args)
        {
            EmulatorDisplayControl.MakeCurrent();
            renderer.SetupScene();
        }

        private void OnPaint(object sender, PaintEventArgs args)
        {
            renderer.ClearScene();
            renderer.RenderScene(interpreter.Graphics.GetVideoMemory());
            EmulatorDisplayControl.SwapBuffers();
        }

        private async void RunEmulator()
        {
            while (true)
            {
                interpreter.ExecuteCycle();
                if (interpreter.DrawFlag)
                {
                    interpreter.DrawFlag = false;
                    EmulatorDisplayControl.Invalidate();
                }

                Update();
                await Task.Delay(0);
            }
        }

        private void Update()
        {
            Opcode = $"{interpreter.Opcode:X4}";
        }
    }
}