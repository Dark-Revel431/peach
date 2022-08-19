namespace peach;

internal static class Data
{
    internal static string Title { get; set; } = "peach";
    internal static string ShellDirectory { get; set; } = string.Empty;
    internal static char Input { get; set; } = '$';
    internal static bool Save { get; set; } = true;
    internal static Modes Mode { get; set; } = Modes.here;
    internal static string Process { get; set; } = string.Empty;
    internal static string Version { get; } = "1.0.0";
    internal static List<string> Commands { get; set; } = new();
}
