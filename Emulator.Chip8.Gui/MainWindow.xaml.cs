using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Forms;
using KeyEventArgs = System.Windows.Forms.KeyEventArgs;

namespace Emulator.Chip8.Gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int ScreenSize = 32 * 64;
        private const int PixelSize = 10;

        private readonly GLControl glcontrol;

        private byte[] videoMemory = new byte[ScreenSize];

        private readonly VirtualMachine virtualMachine = new VirtualMachine();

        public MainWindow()
        {
            InitializeComponent();
            var publisher = virtualMachine.GetPublisher();
            publisher.EventPublisher += OnVideoMemoryUpdated;

            glcontrol = new GLControl(new GraphicsMode(32, 64), 2, 0, GraphicsContextFlags.Default);
            glcontrol.Load += OnLoad;
            glcontrol.Paint += OnPaint;
            glcontrol.Dock = DockStyle.Fill;

            glcontrol.KeyDown += OnKeyDown;
            glcontrol.KeyUp += OnKeyUp;

            Host.Child = glcontrol;

            var worker = new BackgroundWorker();
            worker.DoWork += RunMachine;
            worker.RunWorkerAsync();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            glcontrol.MakeCurrent();
            GL.Viewport(0, 0, 640, 320);
            GL.Ortho(0, 640, 320, 0, 1, -1);
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            GL.ClearColor(0.792f, 0.862f, 0.623f, 1);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            DrawScreen();

            glcontrol.SwapBuffers();
        }

        private void OnVideoMemoryUpdated(object sender, EventArgs e)
        {
            videoMemory = virtualMachine.GetVideoMemory();
            glcontrol.Invalidate();
        }

        private void RunMachine(object sender, DoWorkEventArgs e)
        {
            virtualMachine.Run();
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

        private void OnKeyDown(object sender, KeyEventArgs e)
        {    
            virtualMachine.SetKeyPressed(KeyMapping.Mapping[e.KeyCode], true);
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            virtualMachine.SetKeyPressed(KeyMapping.Mapping[e.KeyCode], false);
        }
    }
}
