using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using MoraJai.Core;
using MoraJai.ViewModels;
using MoraJai.Views;

namespace MoraJai;

public class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Create a new game board with size 3 (or your preferred size)
            var board = new Board(3);
            var boardViewModel = new BoardViewModel(board);
            
            desktop.MainWindow = new MainWindow
            {
                DataContext = boardViewModel
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}