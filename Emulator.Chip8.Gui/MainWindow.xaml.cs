using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Threading;
using Emulator.Chip8.Events;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Emulator.Chip8.Gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int frames;

        private GLControl _glcontrol;

        private DateTime lastMeasureTime;

        private const int ScreenSize = 32 * 64;
        private byte[] _screen = new byte[ScreenSize];
        private const int PixelSize = 10;

        private Machine _emulatorMachine = new Machine();
        private Publisher _publisher;

        public MainWindow()
        {
            InitializeComponent();
            _publisher = _emulatorMachine.GetPublisher();
            _publisher.EventPublisher += OnVideoMemoryUpdated;
        
            _glcontrol = new GLControl(new GraphicsMode(32, 64), 2, 0, GraphicsContextFlags.Default);
            _glcontrol.Load += OnLoad;
            _glcontrol.Paint += OnPaint;
            _glcontrol.Dock = DockStyle.Fill;

            this.Host.Child = _glcontrol;

            var timer = new DispatcherTimer {Interval = TimeSpan.FromMilliseconds(1)};
            timer.Tick += OnTick;
            timer.Start();

            var worker = new BackgroundWorker();
            worker.DoWork += RunMachine;
            worker.RunWorkerAsync();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            _glcontrol.MakeCurrent();
            GL.Viewport(0, 0, 640, 320);
            GL.Ortho(0, 640, 320, 0, 1, -1);
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            GL.ClearColor(202, 220, 159, 1);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            DrawScreen();

            _glcontrol.SwapBuffers();

            frames++;
        }

        private void OnVideoMemoryUpdated(object sender, EventArgs e)
        {
            _screen = _emulatorMachine.GetVideoMemory();
            _glcontrol.Invalidate();
        }

        private void RunMachine(object sender, DoWorkEventArgs e)
        {
            _emulatorMachine.Run();
        }

        private void OnTick(object sender, EventArgs e)
        {
            if (DateTime.Now.Subtract(lastMeasureTime) > TimeSpan.FromSeconds(1))
            {
                Title = frames + " fps";
                frames = 0;
                lastMeasureTime = DateTime.Now;
            }

        }

        private void DrawScreen()
        {
            for (var x = 0; x < 64; x++)
            {
                for (var y = 0; y < 32; y++)
                {
                    var offset = y * 64 + x;
                    var pixel = _screen[offset];
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

            GL.Color3(15, 56, 15);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex2(x, y);
            GL.Vertex2(x, y + PixelSize);
            GL.Vertex2(x + PixelSize, y + PixelSize);
            GL.Vertex2(x + PixelSize, y);
            GL.End();
        }
    }
}
