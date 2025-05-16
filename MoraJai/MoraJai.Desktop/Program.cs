using Avalonia;
using Avalonia.ReactiveUI;

namespace MoraJai;

internal class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);
    }

    public static AppBuilder BuildAvaloniaApp() =>
        AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .UseReactiveUI()
            .LogToTrace();

}