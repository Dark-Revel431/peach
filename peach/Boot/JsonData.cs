namespace peach.Boot;

public class JsonData
{
    public string Title { get; set; } = "peach";
    public string Input { get; set; } = string.Empty;
    public bool Save { get; set; } = true;
    public string Mode { get; set; } = String.Empty;
    public string Process { get; set; } = String.Empty;
    public string StartDirectory { get; set; } = Directory.GetCurrentDirectory();
}
