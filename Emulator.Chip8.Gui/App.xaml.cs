﻿using Autofac;
using Emulator.Chip8.Gui.ViewModels;
using Emulator.Chip8.Gui.Views;
using System.Reflection;
using System.Windows;

namespace Emulator.Chip8.Gui
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IContainer Container { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var assembly = Assembly.Load("Emulator.Chip8");
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(assembly).SingleInstance().AsSelf();

            base.OnStartup(e);

            Container = builder.Build();

            var interpreter = Container.Resolve<Interpreter>();
            var window = new EmulatorView { DataContext = new EmulatorViewModel(interpreter) };
            window.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            Container.Dispose();

            base.OnExit(e);
        }
    }
}
