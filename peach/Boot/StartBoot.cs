namespace peach.Boot;

internal class StartBoot
{
    internal static void Boot()
    {
        Data.ShellDirectory = Directory.GetCurrentDirectory();
        
        ParseConfig.Parse();
        Shell.Start();
    }
}
