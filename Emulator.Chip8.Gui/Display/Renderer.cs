using OpenTK.Graphics.OpenGL;

namespace Emulator.Chip8.Gui.Display
{
    public class Renderer
    {
        private readonly DisplayParameters displayParameters;

        public Renderer(DisplayParameters displayParameters)
        {
            this.displayParameters = displayParameters;
        }

        public void SetupScene()
        {
            GL.Viewport(0, 0, displayParameters.Width * displayParameters.Scale, displayParameters.Height * displayParameters.Scale);
            GL.Ortho(0, displayParameters.Width * displayParameters.Scale, displayParameters.Height * displayParameters.Scale, 0, 1, -1);
        }

        public void ClearScene()
        {
            GL.ClearColor(displayParameters.BackgroundColor);
            GL.Clear(ClearBufferMask.ColorBufferBit);
        }

        public void RenderScene(byte[] videoMemory)
        {
            for (var x = 0; x < displayParameters.Width; x++)
            {
                for (var y = 0; y < displayParameters.Height; y++)
                {
                    var offset = y * displayParameters.Width + x;
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
            x = x * displayParameters.Scale;
            y = y * displayParameters.Scale;

            GL.Color3(displayParameters.ForegroundColor);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex2(x, y);
            GL.Vertex2(x, y + displayParameters.Scale);
            GL.Vertex2(x + displayParameters.Scale, y + displayParameters.Scale);
            GL.Vertex2(x + displayParameters.Scale, y);
            GL.End();
        }
    }
}