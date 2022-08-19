namespace peach.Boot;

internal class ParseConfig
{
    internal static void Parse()
    {
        if (!File.Exists("peach/peach.json"))
        {
            throw new FileNotFoundException("\"peach.json\" not found.");
        }

        JsonData? JsonObject = JsonConvert.DeserializeObject<JsonData>("peach.json");

        if (JsonObject != null)
        {
            Data.Title = JsonObject.Title;
            Data.Save = JsonObject.Save;

            if (!string.IsNullOrWhiteSpace(JsonObject.Input))
            {
                Data.Input = JsonObject.Input[0];
            }
            else
            {
                Data.Input = '$';
            }

            Data.Mode = JsonObject.Mode switch
            {
                "status" => Modes.status,
                "hide" => Modes.hide,
                _ => Modes.here,
            };

            if (string.IsNullOrWhiteSpace(JsonObject.Process))
            {
                if (Environment.OSVersion.VersionString.Contains("Windows"))
                {
                    Data.Process = "cmd";
                }
                else
                {
                    Data.Process = "bash";
                }
            }
            else
            {
                Data.Process = JsonObject.Process;
            }

            if (Directory.Exists(JsonObject.StartDirectory))
            {
                Directory.SetCurrentDirectory(JsonObject.StartDirectory);
            }
        }
        else
        {
            throw new Exception("JsonObject is null.");
        }
    }
}
