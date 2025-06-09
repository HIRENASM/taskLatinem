using System.Text.Json;
using System.Text.Json.Serialization;

public class ChartDataset
{
    [JsonPropertyName("label")]
    public string Label { get; set; }

    [JsonPropertyName("data")]
    public List<double> Data { get; set; }

    [JsonPropertyName("backgroundColor")]
    public object BackgroundColor { get; set; }

    [JsonPropertyName("borderColor")]
    public string BorderColor { get; set; }

    [JsonPropertyName("fill")]
    public bool Fill { get; set; }

    [JsonPropertyName("borderRadius")]
    [JsonConverter(typeof(BorderRadiusJsonConverter))]
    public object? BorderRadius { get; set; }

    [JsonPropertyName("borderSkipped")]
    public object? BorderSkipped { get; set; }

    [JsonPropertyName("borderWidth")]
    public int? BorderWidth { get; set; }

    [JsonPropertyName("spacing")]
    public int? Spacing { get; set; }

    [JsonPropertyName("tension")]
    public double Tension { get; set; }
}

public class ChartViewModel
{
    public string ChartId { get; set; }
    public string ChartTitle { get; set; }
    public string ChartType { get; set; } = "bar";
    public List<string> Labels { get; set; } = new();
    public List<ChartDataset> Datasets { get; set; } = new();

    public string IconClass { get; set; }

}

public class DashboardChartsViewModel
{
    public ChartViewModel PieChart { get; set; }
    public ChartViewModel BarChart { get; set; }
    public ChartViewModel LineChart { get; set; }
    public ChartViewModel StackedBarChart { get; set; }
}

public class BorderRadiusJsonConverter : JsonConverter<object>
{
    public override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // Not needed unless you're deserializing
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
    {
        if (value is int intVal)
        {
            writer.WriteNumberValue(intVal);
        }
        else if (value is Dictionary<string, int> dict)
        {
            writer.WriteStartObject();
            foreach (var kv in dict)
            {
                writer.WriteNumber(kv.Key, kv.Value);
            }
            writer.WriteEndObject();
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}

public class TimelineChartViewModel
{
    public string ChartTitle { get; set; }
    public Dictionary<string, List<AssetStatusBlock>> AssetData { get; set; }
}

public class AssetStatusBlock
{
    [JsonPropertyName("start")]
    public string Start { get; set; }
    [JsonPropertyName("end")]
    public string End { get; set; }
    [JsonPropertyName("status")]
    public string Status { get; set; }
}
