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
            Data.Data.Title = JsonObject.Title;
            Data.Data.Save = JsonObject.Save;

            if (!string.IsNullOrWhiteSpace(JsonObject.Input))
            {
                Data.Data.Input = JsonObject.Input[0];
            }
            else
            {
                Data.Data.Input = '$';
            }

            Data.Data.Mode = JsonObject.Mode switch
            {
                "status" => Modes.status,
                "hide" => Modes.hide,
                _ => Modes.here,
            };

            if (string.IsNullOrWhiteSpace(JsonObject.Process))
            {
                if (Environment.OSVersion.VersionString.Contains("Windows"))
                {
                    Data.Data.Process = "cmd";
                }
                else
                {
                    Data.Data.Process = "bash";
                }
            }
            else
            {
                Data.Data.Process = JsonObject.Process;
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
