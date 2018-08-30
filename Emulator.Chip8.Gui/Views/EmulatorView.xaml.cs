using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Emulator.Chip8.Gui.ViewModels;

namespace Emulator.Chip8.Gui.Views
{
    /// <summary>
    /// Interaction logic for EmulatorView.xaml
    /// </summary>
    public partial class EmulatorView : Window
    {
        private EmulatorViewModel emulatorViewModel;

        public EmulatorView()
        {
            InitializeComponent();
            
            emulatorViewModel = new EmulatorViewModel();
            this.DataContext = emulatorViewModel;

            Host.Child = emulatorViewModel.EmulatorDisplayControl;



        }
    }
}
