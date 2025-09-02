using System.Text.Json;

namespace GameStore.Utils.Extensions;

public static class SerializationExtensions
{
    public static string SerializeToJson(this object model, JsonSerializerOptions? options = null) =>
        JsonSerializer.Serialize(model);

    public static TType? DeserializeFromJson<TType>(this string json, JsonSerializerOptions? options = null) =>
        string.IsNullOrWhiteSpace(json) ? default : JsonSerializer.Deserialize<TType>(json, options);
}