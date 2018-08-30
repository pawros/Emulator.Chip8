using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emulator.Chip8.Gui.Display;

namespace Emulator.Chip8.Gui.ViewModels
{
    public class EmulatorViewModel : ObservableObject
    {
        private Interpreter interpreter;
        private Task interpreterTask;
        private Renderer renderer;

        public EmulatorDisplayControl EmulatorDisplayControl { get; private set; }

        public EmulatorViewModel()
        {
            InitializeDisplayControl();

            interpreter = new Interpreter();
            interpreter.LoadRom("SpaceInvaders.ch8");
            interpreterTask = Task.Factory.StartNew(RunEmulator);
        }

        private void InitializeDisplayControl()
        {
            EmulatorDisplayControl = new EmulatorDisplayControl();
            EmulatorDisplayControl.Load += OnLoad;
            EmulatorDisplayControl.Paint += OnPaint;
        }

        private void OnLoad(object sender, EventArgs args)
        {
            Debug.WriteLine("EmulatorDisplayControl loaded");
        }

        private void OnPaint(object sender, PaintEventArgs args)
        {
            Debug.WriteLine("EmulatorDisplayControl painted");
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
                await Task.Delay(100);
            }
        }
    }
}