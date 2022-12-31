using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Backend.Dtos;

public class TimeOnlyJsonConverter : JsonConverter<TimeOnly>
{
    private readonly string serializationFormat;

    public TimeOnlyJsonConverter() : this(null)
    { }

    public TimeOnlyJsonConverter(string serializationFormat)
    {
        this.serializationFormat = serializationFormat ?? "HH:mm:ss.fff";
    }

    public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return TimeOnly.Parse(reader.GetString());
    }

    public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(serializationFormat));
    }
}
