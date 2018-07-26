using Emulator.Chip8.Gui.Display;
using OpenTK.Graphics;
using System.ComponentModel;
using System.Windows;

namespace Emulator.Chip8.Gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly VirtualMachine virtualMachine;

        public MainWindow()
        {
            InitializeComponent();

            var displayParameters = new DisplayParameters();
            virtualMachine = new VirtualMachine();
            var displayControl = new DisplayControl(virtualMachine, displayParameters, new GraphicsMode(displayParameters.Height, displayParameters.Width), 2, 0, GraphicsContextFlags.Default);
            Host.Child = displayControl;

            var worker = new BackgroundWorker();
            worker.DoWork += RunMachine;
            worker.RunWorkerAsync();
        }

        private void RunMachine(object sender, DoWorkEventArgs e)
        {
            virtualMachine.Run();
        }
    }
}
