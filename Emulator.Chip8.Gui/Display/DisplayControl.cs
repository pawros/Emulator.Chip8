using System;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Emulator.Chip8.Gui.Display
{
    public class DisplayControl : GLControl
    {
        private const int ScreenSize = 32 * 64;
        private const int PixelSize = 10;
        private byte[] videoMemory = new byte[ScreenSize];

        private readonly VirtualMachine virtualMachine;

        public DisplayControl(VirtualMachine virtualMachine)
        {
            this.virtualMachine = virtualMachine;
            Initialize();
            SubscribeToEvents();
        }

        public DisplayControl(VirtualMachine virtualMachine, GraphicsMode mode) : base(mode)
        {
            this.virtualMachine = virtualMachine;
            Initialize();
            SubscribeToEvents();
        }

        public DisplayControl(VirtualMachine virtualMachine, GraphicsMode mode, int major, int minor, GraphicsContextFlags flags) : base(mode, major, minor, flags)
        {
            this.virtualMachine = virtualMachine;
            Initialize();
        }

        private void Initialize()
        {
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
            GL.Viewport(0, 0, 640, 320);
            GL.Ortho(0, 640, 320, 0, 1, -1);
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            GL.ClearColor(0.792f, 0.862f, 0.623f, 1);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            DrawScreen();

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

        private void DrawScreen()
        {
            for (var x = 0; x < 64; x++)
            {
                for (var y = 0; y < 32; y++)
                {
                    var offset = y * 64 + x;
                    var pixel = videoMemory[offset];
                    if (pixel != 0)
                    {
                        DrawPixel(x, y);
                    }
                }
            }
        }

        private void DrawPixel(float x, float y)
        {
            x = x * PixelSize;
            y = y * PixelSize;

            GL.Color3(0.058, 0.219, 0.058);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex2(x, y);
            GL.Vertex2(x, y + PixelSize);
            GL.Vertex2(x + PixelSize, y + PixelSize);
            GL.Vertex2(x + PixelSize, y);
            GL.End();
        }
    }
}