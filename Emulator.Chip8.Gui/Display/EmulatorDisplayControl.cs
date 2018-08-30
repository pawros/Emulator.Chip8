using System;
using System.Windows;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics;

namespace Emulator.Chip8.Gui.Display
{
    public class EmulatorDisplayControl : GLControl
    {

    }
}

///// <summary>
///// The start angle property. Defines where the progress start.
///// Requires value from 0 to 360 degrees.
///// </summary>
//public static readonly DependencyProperty StartAngleProperty = DependencyProperty.Register(
//    "StartAngle",
//    typeof(double),
//    typeof(CircularProgressBar),
//    new PropertyMetadata(0d, OnStartAngleChanged, CoerceStartAngle));

///// <summary>
///// Gets or sets the start angle (in degrees).
///// </summary>
///// <value>
///// The start angle.
///// </value>
//public double StartAngle
//{
//    get { return (double)GetValue(CircularProgressBar.StartAngleProperty); }
//    set { SetValue(CircularProgressBar.StartAngleProperty, value); }
//}

//private void Initialize()
//{
//    videoMemory = new byte[displayParameters.Width * displayParameters.Height];

//    Load += OnLoad;
//    Paint += OnPaint;

//    KeyDown += OnKeyDown;
//    KeyUp += OnKeyUp;

//    Dock = DockStyle.Fill;
//    SubscribeToEvents();
//}

//private void OnLoad(object sender, EventArgs e)
//{
//    MakeCurrent();
//    renderer.SetupScene();
//}

//private void OnPaint(object sender, PaintEventArgs e)
//{
//    renderer.ClearScene();
//    renderer.RenderScene(videoMemory);
//    SwapBuffers();
//}

//private void SubscribeToEvents()
//{
//    virtualMachine.Publisher.EventPublisher += OnVideoMemoryUpdated;
//}

//private void OnVideoMemoryUpdated(object sender, EventArgs e)
//{
//    videoMemory = virtualMachine.GetVideoMemory();
//    Invalidate();
//}

//private void OnKeyUp(object sender, KeyEventArgs e)
//{
//    virtualMachine.SetKeyPressed(KeyMapping.Mapping[e.KeyCode], false);
//}

//private void OnKeyDown(object sender, KeyEventArgs e)
//{
//    virtualMachine.SetKeyPressed(KeyMapping.Mapping[e.KeyCode], true);
//}