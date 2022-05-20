namespace KeyboardMouseMover;

public static class Program
{
    internal static readonly TrayIcon TrayIcon = new();
    internal static readonly MouseMover MouseMover = new();
    internal static readonly KeyboardListener KeyboardListener = new(MouseMover);
    
    
    [STAThread]
    public static void Main()
    {
        ApplicationConfiguration.Initialize();
        
        TrayIcon.Show();
        KeyboardListener.Start();
        
        Application.ApplicationExit += (sender, args) => BeforeExit(); 
        Application.Run();
        
        Exit();
    }

    private static void BeforeExit()
    {
        KeyboardListener.Stop();
        TrayIcon.Dispose();
    }

    public static void Exit()
    {
        BeforeExit();

        if (Application.AllowQuit)
        {
            Application.Exit();
            Application.DoEvents();
        }

        Environment.Exit(0);
    }
}