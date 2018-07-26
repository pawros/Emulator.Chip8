using System;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics;

namespace Emulator.Chip8.Gui.Display
{
    public class DisplayControl : GLControl
    {
        private byte[] videoMemory;

        private readonly VirtualMachine virtualMachine;
        private readonly DisplayParameters displayParameters;
        private readonly Renderer renderer;

        public DisplayControl(VirtualMachine virtualMachine, DisplayParameters displayParameters)
        {
            this.virtualMachine = virtualMachine;
            this.displayParameters = displayParameters;
            this.renderer = new Renderer(displayParameters);
            Initialize();
            SubscribeToEvents();
        }

        public DisplayControl(VirtualMachine virtualMachine, DisplayParameters displayParameters, GraphicsMode mode) : base(mode)
        {
            this.virtualMachine = virtualMachine;
            this.displayParameters = displayParameters;
            this.renderer = new Renderer(displayParameters);
            Initialize();
            SubscribeToEvents();
        }

        public DisplayControl(VirtualMachine virtualMachine, DisplayParameters displayParameters, GraphicsMode mode, int major, int minor, GraphicsContextFlags flags) : base(mode, major, minor, flags)
        {
            this.virtualMachine = virtualMachine;
            this.displayParameters = displayParameters;
            this.renderer = new Renderer(displayParameters);
            Initialize();
        }

        private void Initialize()
        {
            videoMemory = new byte[displayParameters.Width * displayParameters.Height];

            Load += OnLoad;
            Paint += OnPaint;

            KeyDown += OnKeyDown;
            KeyUp += OnKeyUp;

            Dock = DockStyle.Fill;
            SubscribeToEvents();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            MakeCurrent();
            renderer.SetupScene();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            renderer.ClearScene();
            renderer.RenderScene(videoMemory);
            SwapBuffers();
        }

        private void SubscribeToEvents()
        {
            virtualMachine.Publisher.EventPublisher += OnVideoMemoryUpdated;
        }

        private void OnVideoMemoryUpdated(object sender, EventArgs e)
        {
            videoMemory = virtualMachine.GetVideoMemory();
            Invalidate();
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            virtualMachine.SetKeyPressed(KeyMapping.Mapping[e.KeyCode], false);
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            virtualMachine.SetKeyPressed(KeyMapping.Mapping[e.KeyCode], true);
        }
    }
}