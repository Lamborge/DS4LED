using Avalonia;
using System.Diagnostics;

namespace DS4LED
{
    class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        [STAThread]
        public static void Main(string[] args)
        {
            if (Environment.UserName != "root")
            {
                ProcessStartInfo startInfo = new ProcessStartInfo() { FileName = "pkexec", Arguments = $@"env DISPLAY={Environment.GetEnvironmentVariable("DISPLAY")} XAUTHORITY={Environment.GetEnvironmentVariable("XAUTHORITY")}  {Directory.GetCurrentDirectory()}/DS4LED" }; 
                Process proc = new Process() { StartInfo = startInfo, };
                proc.Start();
                //Environment.Exit(1);
            }
            else
                BuildAvaloniaApp()
                    .StartWithClassicDesktopLifetime(args);
            
        }

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace();
    }
}