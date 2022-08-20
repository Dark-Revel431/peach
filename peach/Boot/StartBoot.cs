namespace peach.Boot;

internal class StartBoot
{
    internal static void Boot()
    {
        Data.Data.ShellDirectory = Directory.GetCurrentDirectory();
        
        ParseConfig.Parse();
        Shell.Shell.Start();
    }
}
